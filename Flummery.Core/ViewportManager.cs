using System;
using System.Collections.Generic;

using Flummery.Core.Collision;

using ToxicRagers.Helpers;

namespace Flummery.Core
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

        private bool isMouseDown = false;
        private Vector2 mousePosition = Vector2.Zero;
        private Vector2 previousMouseDragPosition = Vector2.Zero;

        public bool HasFocus { get; set; } = false;

        public MouseMode Mode { get; set; } = MouseMode.Select;

        int actionScaling = 3;
        float[] actionScales = new float[] { 0.01f, 0.1f, 0.5f, 1.0f, 5.0f, 10.0f };
        List<Viewport> viewports = new List<Viewport>();
        Viewport active;

        private int width;
        private int height;

        public delegate void MouseMoveHandler(object sender, ViewportMouseMoveEventArgs e);
        public delegate void MouseDownHandler(object sender, ViewportMouseDownEventArgs e);
        public delegate void MouseUpHandler(object sender, ViewportMouseUpEventArgs e);
        public delegate void MouseScrollHandler(object sender, ViewportMouseScrollEventArgs e);

        public event MouseMoveHandler OnMouseMove;
        public event MouseDownHandler OnMouseDown;
        public event MouseUpHandler OnMouseUp;
        public event MouseScrollHandler OnMouseScroll;

        public ViewportManager()
        {
            Viewport top = new Viewport { Name = "Top", Position = Viewport.Quadrant.TopLeft, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitY };
            top.Camera.SetRotation(0, Maths.DegreesToRadians(-90), Maths.DegreesToRadians(180));

            Viewport right = new Viewport { Name = "Side", Position = Viewport.Quadrant.TopRight, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitX };
            right.Camera.SetRotation(Maths.DegreesToRadians(-90), 0, 0);

            Viewport front = new Viewport { Name = "Front", Position = Viewport.Quadrant.BottomLeft, ProjectionMode = ProjectionType.Orthographic, Axis = Vector3.UnitZ };
            front.Camera.SetRotation(Maths.DegreesToRadians(180), 0, 0);

            Viewport threedee = new Viewport { Name = "3D", Position = Viewport.Quadrant.BottomRight };
            threedee.Camera.SetRotation(0, Maths.DegreesToRadians(-135), Maths.DegreesToRadians(135));

            viewports.Add(top);
            viewports.Add(right);
            viewports.Add(front);
            viewports.Add(threedee);

            active = threedee;

            InputManager.Current.RegisterInputAction(ActionScaleUp, "ActionScaleUp", "Increases the current Action Scaling", "Camera Controls");
            InputManager.Current.RegisterInputAction(ActionScaleDown, "ActionScaleDown", "Decreases the current Action Scaling", "Camera Controls");
            InputManager.Current.RegisterInputAction(Frame, "CameraFrame", "Frames the currectly selected mesh", "Camera Controls");

            Current = this;
        }

        public Viewport Active => active;

        public void Initialise(int w, int h)
        {
            width = w;
            height = h;

            SceneManager.Current.Renderer.Hint("PolygonSmoothHint", "Nicest");
            SceneManager.Current.Renderer.Hint("LineSmoothHint", "Nicest");
            SceneManager.Current.Renderer.Hint("PointSmoothHint", "Nicest");
            SceneManager.Current.Renderer.Hint("PerspectiveCorrectionHint", "Nicest");
            SceneManager.Current.Renderer.ShadeModel("Smooth");
            SceneManager.Current.Renderer.PointSize(3.0f);
            SceneManager.Current.Renderer.Enable("CullFace");

            //if (!FlummeryApplication.Active) { return; }
            foreach (Viewport viewport in viewports) { viewport.Resize(width, height); }
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

            foreach (Viewport viewport in viewports) { viewport.Resize(width, height); }
        }

        public void Minimise(Viewport chosen)
        {
            foreach (Viewport viewport in viewports) { viewport.Enabled = true; }
            chosen.ResetWidthHeightPosition();

            foreach (Viewport viewport in viewports) { viewport.Resize(width, height); }
        }

        public void ActionScaleUp()
        {
            if (actionScaling + 1 < actionScales.Length)
            {
                actionScaling++;
                SetActionScale(actionScales[actionScaling]);
                //FlummeryApplication.UI.SetActionScalingText($"Action Scaling: {actionScales[actionScaling]:F3}");
            }
        }

        public void ActionScaleDown()
        {
            if (actionScaling - 1 > -1)
            {
                actionScaling--;
                SetActionScale(actionScales[actionScaling]);
                //FlummeryApplication.UI.SetActionScalingText($"Action Scaling: {actionScales[actionScaling]:F3}");
            }
        }

        public void SetActionScale(float scale)
        {
            foreach (Viewport viewport in viewports) { viewport.Camera.SetActionScale(scale); }
        }

        public Ray GetRayFromMouse()
        {
            Ray ray = new Ray
            {
                Position = Active.ConvertScreenToWorldCoords((int)mousePosition.X, (int)mousePosition.Y),
                Direction = Active.Camera.CameraDirection
            };

            if (Active.ProjectionMode == ProjectionType.Orthographic)
            {
                ray.Position += ray.Direction * -20;
            }
            else
            {
                ray.Direction = (Active.ConvertScreenToWorldCoords((int)mousePosition.X, (int)mousePosition.Y, 1) - ray.Position).Normalised;
            }

            return ray;
        }

        public void MouseMove(int x, int y)
        {
            if (!active.Enabled) { return; }

            mousePosition.X = x;
            mousePosition.Y = y;

            if (!isMouseDown)
            {
                foreach (Viewport viewport in viewports)
                {
                    if (!viewport.Enabled) { continue; }

                    if (viewport.IsActive(x, y))
                    {
                        viewport.Active = true;
                        active = viewport;

                        OnMouseMove?.Invoke(this, new ViewportMouseMoveEventArgs(x, y, active));
                    }
                    else
                    {
                        viewport.Active = false;
                    }
                }

                return;
            }

            Drag(new ViewportMouseDragEventArgs(previousMouseDragPosition, new Vector2(x, y)));

            previousMouseDragPosition = new Vector2(x, y);
        }

        public void MouseDown(int X, int Y)
        {
            isMouseDown = true;

            OnMouseDown?.Invoke(this, new ViewportMouseDownEventArgs(Vector3.Zero));
            previousMouseDragPosition = new Vector2(X, Y);
        }

        public void MouseUp(int x, int y)
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

            switch (Mode)
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
        public int X { get; private set; }

        public int Y { get; private set; }

        public Viewport Viewport { get; private set; }

        public Vector3 Position => Viewport.ConvertScreenToWorldCoords(X, Y);

        public ViewportMouseMoveEventArgs(int x, int y, Viewport viewport)
        {
            X = x;
            Y = y;
            Viewport = viewport;
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

    public class ViewportMouseScrollEventArgs : EventArgs
    {
        public Vector3 Position { get; private set; }

        public ViewportMouseScrollEventArgs(Vector3 position)
        {
            Position = position;
        }
    }

    public class ViewportMouseDownEventArgs : EventArgs
    {
        public Vector3 Position { get; private set; }

        public ModelMesh Selected { get; set; }

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