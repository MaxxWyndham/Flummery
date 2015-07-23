using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Flummery
{
    public enum MouseMode
    {
        Select,
        Pan,
        Zoom,
        Rotate
    }

    public class ViewportManager
    {
        public static ViewportManager Current;

        bool bHasFocus = false;

        private bool isMouseDown = false;
        private Vector2 previousMouseDragPosition;
        private MouseMode mode = MouseMode.Select;

        public bool HasFocus { get { return bHasFocus; } set { bHasFocus = value; } }
        public MouseMode Mode { get { return mode; } set { mode = value; } }

        int actionScaling = 3;
        float[] actionScales = new float[] { 0.01f, 0.1f, 0.5f, 1.0f, 5.0f, 10.0f };
        List<Viewport> viewports = new List<Viewport>();
        Viewport active;

        public delegate void MouseMoveHandler(object sender, ViewportMouseMoveEventArgs e);
        public delegate void MouseDownHandler(object sender, ViewportMouseMoveEventArgs e);
        public delegate void MouseUpHandler(object sender, ViewportMouseMoveEventArgs e);
        public delegate void MouseScrollHandler(object sender, ViewportMouseMoveEventArgs e);

        public event MouseMoveHandler OnMouseMove;
        public event MouseDownHandler OnMouseDown;

        public ViewportManager()
        {
            var top = new Viewport { Name = "Top", Position = Viewport.Quadrant.TopLeft, ProjectionMode = ProjectionType.Orthographic };
            top.Camera.SetPosition(0, 15, 0);
            top.Camera.SetRotation(0, MathHelper.DegreesToRadians(-90), 0);

            var right = new Viewport { Name = "Side", Position = Viewport.Quadrant.TopRight, ProjectionMode = ProjectionType.Orthographic };
            right.Camera.SetPosition(15, 0, 0);
            right.Camera.SetRotation(MathHelper.DegreesToRadians(90), 0, 0);

            var front = new Viewport { Name = "Front", Position = Viewport.Quadrant.BottomLeft, ProjectionMode = ProjectionType.Orthographic };
            front.Camera.SetPosition(0, 0, 15);

            var threedee = new Viewport { Name = "3D", Position = Viewport.Quadrant.BottomRight };
            threedee.Camera.SetPosition(0, 15, 15);
            threedee.Camera.SetRotation(0, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(-45));

            viewports.Add(top);
            viewports.Add(right);
            viewports.Add(front);
            viewports.Add(threedee);

            active = threedee;

            InputManager.Current.RegisterBinding('*', KeyBinding.KeysActionScaleUp, ActionScaleUp);
            InputManager.Current.RegisterBinding('/', KeyBinding.KeysActionScaleDown, ActionScaleDown);
            InputManager.Current.RegisterBinding(Properties.Settings.Default.KeysCameraFrame, KeyBinding.KeysCameraFrame, Frame);

            Current = this;
        }

        public Viewport Active { get { return active; } }

        public void Initialise()
        {
            if (!FlummeryApplication.Active) { return; }
            foreach (var viewport in viewports) { viewport.Resize(); }
        }

        public void AddViewport(Viewport viewport)
        {
            viewports.Add(viewport);
        }

        public void Maximise(Viewport chosen)
        {
            foreach (var viewport in viewports) { viewport.Enabled = false; }

            chosen.Enabled = true;
            chosen.SetWidthHeightPosition(Viewport.Size.Full, Viewport.Size.Full, Viewport.Quadrant.BottomLeft);

            foreach (var viewport in viewports) { viewport.Resize(); }
        }

        public void Minimise(Viewport chosen)
        {
            foreach (var viewport in viewports) { viewport.Enabled = true; }
            chosen.ResetWidthHeightPosition();
            foreach (var viewport in viewports) { viewport.Resize(); }
        }

        public void ActionScaleUp()
        {
            if (actionScaling + 1 < actionScales.Length)
            {
                actionScaling++;
                SetActionScale(actionScales[actionScaling]);
                FlummeryApplication.UI.SetActionScalingText("Action Scaling: " + actionScales[actionScaling].ToString("0.000"));
            }
        }

        public void ActionScaleDown()
        {
            if (actionScaling - 1 > -1)
            {
                actionScaling--;
                SetActionScale(actionScales[actionScaling]);
                FlummeryApplication.UI.SetActionScalingText("Action Scaling: " + actionScales[actionScaling].ToString("0.000"));
            }
        }

        public void SetActionScale(float scale)
        {
            foreach (var viewport in viewports) { viewport.Camera.SetActionScale(scale); }
        }

        public void MouseMove(int X, int Y)
        {
            if (!active.Enabled) { return; }

            if (!isMouseDown)
            {
                foreach (var viewport in viewports)
                {
                    if (!viewport.Enabled) { continue; }

                    if (viewport.IsActive(X, Y))
                    {
                        viewport.Active = true;
                        active = viewport;

                        if (OnMouseMove != null) { OnMouseMove(this, new ViewportMouseMoveEventArgs(viewport.ConvertScreenToWorldCoords(X, Y))); }
                    }
                    else
                    {
                        viewport.Active = false;
                    }
                }

                return;
            }

            Drag(new ViewportMouseDragEventArgs(previousMouseDragPosition, new Vector2(X, Y)));

            previousMouseDragPosition = new Vector2(X, Y);
        }

        public void MouseDown(int X, int Y)
        {
            isMouseDown = true;

            if (OnMouseDown != null) { OnMouseDown(this, new ViewportMouseMoveEventArgs(this.Active.ConvertScreenToWorldCoords(X, Y))); }

            previousMouseDragPosition = new Vector2(X, Y);
        }

        public void MouseUp(int X, int Y)
        {
            isMouseDown = false;
        }

        public void MouseScroll(int delta)
        {
            float fDelta = (float)(delta) * active.Camera.ZoomSpeed;
            if (!active.Enabled) { return; }

            if (isMouseDown)
            {
                if (delta > 0)
                {
                    ActionScaleUp();
                }
                else
                {
                    ActionScaleDown();
                }
                return;
            }

            active.Camera.Zoom -= fDelta;
        }

        public void Drag(ViewportMouseDragEventArgs e)
        {
            if (!active.Enabled) { return; }

            float diffX = -(e.CurrentPosition.X - e.PreviousPosition.X);
            float diffY = (e.CurrentPosition.Y - e.PreviousPosition.Y);

            float modifiedDiffX = diffX * 0.01f * active.Camera.Zoom;
            float modifiedDiffY = diffY * 0.01f * active.Camera.Zoom;

            switch (mode)
            {
                case MouseMode.Select:
                    break;

                case MouseMode.Pan:
                    active.Camera.Translate(modifiedDiffX, modifiedDiffY);
                    break;

                case MouseMode.Zoom:
                    float zoom = ((diffX * 2) - diffY) * active.Camera.ZoomSpeed;

                    active.Camera.Zoom += zoom;
                    break;

                case MouseMode.Rotate:
                    if (active.ProjectionMode == ProjectionType.Perspective)
                    {
                        active.Camera.Rotate(diffX, diffY);
                    }
                    break;
            }
        }

        public void Frame()
        {
            if (SceneManager.Current.Models.Count == 0) { return; }

            var mesh = SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Mesh;

            if (mesh != null)
            {
                foreach (var viewport in viewports)
                {
                    viewport.Camera.Frame(mesh);
                }
            }
        }

        public void Update(float dt)
        {
            foreach (var viewport in viewports)
            {
                if (!viewport.Enabled) { continue; }

                viewport.Update(dt);
            }
        }

        public void Draw()
        {
            foreach (var viewport in viewports)
            {
                if (!viewport.Enabled) { continue; }

                viewport.Draw(SceneManager.Current);
                viewport.DrawOverlay();
            }
        }
    }

    public class ViewportMouseMoveEventArgs : EventArgs
    {
        public Vector3 Position { get; private set; }

        public ViewportMouseMoveEventArgs(Vector3 position)
        {
            Position = position;
        }
    }

    public class ViewportMouseUpEventArgs : EventArgs
    {
        public Vector3 Position { get; private set; }

        public ViewportMouseUpEventArgs(Vector3 position)
        {
            Position = position;
        }
    }

    public class ViewportMouseDownEventArgs : EventArgs
    {
        public Vector3 Position { get; private set; }

        public ViewportMouseDownEventArgs(Vector3 position)
        {
            Position = position;
        }
    }

    public class ViewportMouseDragEventArgs : EventArgs
    {
        public Vector2 PreviousPosition { get; private set; }
        public Vector2 CurrentPosition { get; private set; }

        public ViewportMouseDragEventArgs(Vector2 previousPosition, Vector2 currentPosition)
        {
            PreviousPosition = previousPosition;
            CurrentPosition = currentPosition;
        }
    }
}
