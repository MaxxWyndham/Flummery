using System;
using System.Collections.Generic;

using OpenTK;

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

        public bool HasFocus
        {
            get => bHasFocus;
            set => bHasFocus = value;
        }

        public MouseMode Mode
        {
            get => mode;
            set => mode = value;
        }

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
            Viewport top = new Viewport { Name = "Top", Position = Viewport.Quadrant.TopLeft, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitY };
            top.Camera.SetRotation(0, MathHelper.DegreesToRadians(-90), MathHelper.DegreesToRadians(180));

            Viewport right = new Viewport { Name = "Side", Position = Viewport.Quadrant.TopRight, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitX };
            right.Camera.SetRotation(MathHelper.DegreesToRadians(-90), 0, 0);

            Viewport front = new Viewport { Name = "Front", Position = Viewport.Quadrant.BottomLeft, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitZ };
            front.Camera.SetRotation(MathHelper.DegreesToRadians(180), 0, 0);

            Viewport threedee = new Viewport { Name = "3D", Position = Viewport.Quadrant.BottomRight };
            threedee.Camera.SetRotation(0, MathHelper.DegreesToRadians(-135), MathHelper.DegreesToRadians(135));

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

        public Viewport Active => active;

        public void Initialise()
        {
            if (!FlummeryApplication.Active) { return; }
            foreach (Viewport viewport in viewports) { viewport.Resize(); }
        }

        public void AddViewport(Viewport viewport)
        {
            viewports.Add(viewport);
        }

        public void Maximise(Viewport chosen)
        {
            foreach (Viewport viewport in viewports) { viewport.Enabled = false; }

            chosen.Enabled = true;
            chosen.SetWidthHeightPosition(Viewport.Size.Full, Viewport.Size.Full, Viewport.Quadrant.BottomLeft);

            foreach (Viewport viewport in viewports) { viewport.Resize(); }
        }

        public void Minimise(Viewport chosen)
        {
            foreach (Viewport viewport in viewports) { viewport.Enabled = true; }
            chosen.ResetWidthHeightPosition();
            foreach (Viewport viewport in viewports) { viewport.Resize(); }
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
            foreach (Viewport viewport in viewports) { viewport.Camera.SetActionScale(scale); }
        }

        public void MouseMove(int X, int Y)
        {
            if (!active.Enabled) { return; }

            if (!isMouseDown)
            {
                foreach (Viewport viewport in viewports)
                {
                    if (!viewport.Enabled) { continue; }

                    if (viewport.IsActive(X, Y))
                    {
                        viewport.Active = true;
                        active = viewport;

                        OnMouseMove?.Invoke(this, new ViewportMouseMoveEventArgs(viewport.ConvertScreenToWorldCoords(X, Y)));
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

            OnMouseDown?.Invoke(this, new ViewportMouseMoveEventArgs(Active.ConvertScreenToWorldCoords(X, Y)));
            previousMouseDragPosition = new Vector2(X, Y);
        }

        public void MouseUp(int X, int Y)
        {
            isMouseDown = false;
        }

        public void MouseScroll(int delta)
        {
            float fDelta = delta * active.Camera.ZoomSpeed;
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

            ModelMesh mesh = SceneManager.Current.Models[SceneManager.Current.SelectedModelIndex].Bones[SceneManager.Current.SelectedBoneIndex].Mesh;

            if (mesh != null)
            {
                foreach (Viewport viewport in viewports)
                {
                    viewport.Camera.Frame(mesh);
                }
            }
        }

        public void Update(float dt)
        {
            foreach (Viewport viewport in viewports)
            {
                if (!viewport.Enabled) { continue; }

                viewport.Update(dt);
            }
        }

        public void Draw()
        {
            foreach (Viewport viewport in viewports)
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