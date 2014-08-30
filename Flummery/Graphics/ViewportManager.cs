using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public class ViewportManager
    {
        public static ViewportManager Current;

        bool bHasFocus = false;

        private bool isMouseDown = false;
        private Vector2 previousMouseDragPosition;

        public bool HasFocus { get { return bHasFocus; } set { bHasFocus = value; } }

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
            var top = new Viewport { Name = "Top", Position = Viewport.Quadrant.TopLeft, ProjectionMode = Viewport.Mode.Orthographic };
            top.Camera.SetPosition(0, 15, 0);
            top.Camera.SetRotation(0, MathHelper.DegreesToRadians(-90), 0);

            var right = new Viewport { Name = "Right", Position = Viewport.Quadrant.TopRight, ProjectionMode = Viewport.Mode.Orthographic };
            right.Camera.SetPosition(15, 0, 0);
            right.Camera.SetRotation(MathHelper.DegreesToRadians(90), 0, 0);

            var front = new Viewport { Name = "Front", Position = Viewport.Quadrant.BottomLeft, ProjectionMode = Viewport.Mode.Orthographic };
            front.Camera.SetPosition(0, 0, 15);

            var threedee = new Viewport { Name = "3D", Position = Viewport.Quadrant.BottomRight };
            threedee.Camera.SetPosition(0, 15, 15);
            threedee.Camera.SetRotation(0, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(-45));

            viewports.Add(top);
            viewports.Add(right);
            viewports.Add(front);
            viewports.Add(threedee);

            active = threedee;

            Current = this;
        }

        public Viewport Active { get { return active; } }

        public void Initialise()
        {
            if (!Flummery.Active) { return; }
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
                Flummery.UI.SetActionScalingText("Action Scaling: " + actionScales[actionScaling].ToString("0.000"));
            }
        }

        public void ActionScaleDown()
        {
            if (actionScaling - 1 > -1)
            {
                actionScaling--;
                SetActionScale(actionScales[actionScaling]);
                Flummery.UI.SetActionScalingText("Action Scaling: " + actionScales[actionScaling].ToString("0.000"));
            }
        }

        public void SetActionScale(float scale)
        {
            foreach (var viewport in viewports) { viewport.Camera.SetActionScale(scale); }
        }

        public bool KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            var bHandled = false;

            if (Flummery.Active && !isMouseDown)
            {
                switch (e.KeyChar)
                {
                    case '*':
                        ActionScaleUp();
                        return true;

                    case '/':
                        ActionScaleDown();
                        return true;

                    case 'd':
                        SceneManager.Current.SetBoundingBox(null);
                        return true;
                }
            }

            return bHandled;
        }

        public void UpdateKeyboardMovement()
        {
            var state = Keyboard.GetState();
            float dt = SceneManager.Current.DeltaTime;

            if (active.ProjectionMode == Viewport.Mode.Orthographic)
            {
                if (state[Key.W]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
                if (state[Key.S]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

                if (state[Key.A]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
                if (state[Key.D]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }
            }
            else
            {
                if (state[Key.A]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
                if (state[Key.D]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }

                if (state[Key.W]) { active.Camera.MoveCamera(Camera.Direction.Forward, dt); }
                if (state[Key.S]) { active.Camera.MoveCamera(Camera.Direction.Backward, dt); }

                if (state[Key.Z]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
                if (state[Key.X]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

                if (state[Key.Q]) { active.Camera.Rotate(0, 0, -dt * 50); }
                if (state[Key.E]) { active.Camera.Rotate(0, 0, dt * 50); }

                if (state[Key.Keypad4]) { active.Camera.Rotate(dt, 0, 0); }
                if (state[Key.Keypad6]) { active.Camera.Rotate(-dt, 0, 0); }
                if (state[Key.Keypad2]) { active.Camera.Rotate(0, dt, 0); }
                if (state[Key.Keypad8]) { active.Camera.Rotate(0, -dt, 0); }
                if (state[Key.Keypad7]) { active.Camera.Rotate(0, 0, dt); }
                if (state[Key.Keypad9]) { active.Camera.Rotate(0, 0, -dt); }

                if (state[Key.Keypad1]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
                if (state[Key.Keypad3]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }
            }
        }

        public void MouseMove(int X, int Y)
        {
            if (!active.Enabled) { return; }
            if (!isMouseDown) { return; }

            Drag( new ViewportMouseDragEventArgs( previousMouseDragPosition, new Vector2(X, Y) ) );

            previousMouseDragPosition = new Vector2(X, Y);
        }

        public void MouseDown(int X, int Y)
        {
            foreach (var viewport in viewports)
            {
                if (!viewport.Enabled) { continue; }

                if (viewport.IsActive(X, Y))
                {
                    viewport.Active = true;
                    active = viewport;

                    if (OnMouseDown != null) { OnMouseDown(this, new ViewportMouseMoveEventArgs(viewport.ConvertScreenToWorldCoords(X, Y))); }
                }
                else
                {
                    viewport.Active = false;
                }
            }

            isMouseDown = true;
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

           if (active.ProjectionMode == Viewport.Mode.Orthographic)
           {
               active.Zoom -= fDelta;
           }
           else
           {
               active.Camera.MoveCamera(Camera.Direction.Backward, -fDelta);
           }
        }

        public void Drag(ViewportMouseDragEventArgs e)
        {
            if (!active.Enabled) { return; }
            float diffX = (e.CurrentPosition.X - e.PreviousPosition.X);
            float diffY = (e.CurrentPosition.Y - e.PreviousPosition.Y);

            if (active.ProjectionMode == Viewport.Mode.Orthographic)
            {
                active.Camera.Translate(-diffX * 0.01f * active.Zoom, diffY * 0.01f * active.Zoom);
            }
            else if (active.ProjectionMode == Viewport.Mode.Perspective)
            {
                active.Camera.Rotate(diffX, diffY);
            }
        }

        public void Update(float dt)
        {
            UpdateKeyboardMovement();

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
