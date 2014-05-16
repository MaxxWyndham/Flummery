using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace Flummery
{
    public class ViewportManager
    {
        List<Viewport> viewports = new List<Viewport>();
        Viewport active;

        public ViewportManager()
        {
            var top = new Viewport { Name = "Top", Position = Viewport.Quadrant.TopLeft, ProjectionMode = Viewport.Mode.Orthographic, ZoomAxis = Vector3.UnitY };
            top.Camera.SetPosition(0, 15, 0);
            top.Camera.SetRotation(0, MathHelper.DegreesToRadians(-90), 0);

            var right = new Viewport { Name = "Right", Position = Viewport.Quadrant.TopRight, ProjectionMode = Viewport.Mode.Orthographic, ZoomAxis = Vector3.UnitX };
            right.Camera.SetPosition(15, 0, 0);
            right.Camera.SetRotation(MathHelper.DegreesToRadians(90), 0, 0);

            var front = new Viewport { Name = "Front", Position = Viewport.Quadrant.BottomLeft, ProjectionMode = Viewport.Mode.Orthographic, ZoomAxis = Vector3.UnitZ };
            front.Camera.SetPosition(0, 0, 15);

            var threedee = new Viewport { Name = "3D", Position = Viewport.Quadrant.BottomRight };
            threedee.Camera.SetPosition(0, 15, 15);
            threedee.Camera.SetRotation(0, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(-45));

            viewports.Add(top);
            viewports.Add(right);
            viewports.Add(front);
            viewports.Add(threedee);
        }

        public void Initialise()
        {
            foreach (var viewport in viewports) { viewport.Resize(); }
        }

        public void AddViewport(Viewport viewport)
        {
            viewports.Add(viewport);
        }

        public void SetActionScale(float scale)
        {
            foreach (var viewport in viewports) { viewport.Camera.SetActionScale(scale); }
        }

        public void MouseMove(int X, int Y)
        {
            foreach (var viewport in viewports)
            {
                if (viewport.IsActive(X, Y))
                {
                    viewport.Active = true;
                    active = viewport;
                }
                else
                {
                    viewport.Active = false;
                }
            }
        }

        private void HandleInput(float dt)
        {
            var state = Keyboard.GetState();

            if (active == null) { return; }

            if (state[Key.A]) { active.Camera.MoveCamera(Camera.Direction.Forward, dt); }
            if (state[Key.Z]) { active.Camera.MoveCamera(Camera.Direction.Backward, dt); }
            if (state[Key.E]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
            if (state[Key.Q]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

            if (active.ProjectionMode == Viewport.Mode.Orthographic)
            {
                if (state[Key.Keypad8]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
                if (state[Key.Keypad2]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

                if (state[Key.Keypad4]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
                if (state[Key.Keypad6]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }
            }
            else
            {
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

        public void Update(float dt)
        {
            HandleInput(dt);

            foreach (var viewport in viewports)
            {
                viewport.Update(dt);
            }
        }

        public void Draw()
        {
            foreach (var viewport in viewports)
            {
                viewport.Draw(SceneManager.Current);
                viewport.DrawOverlay();
            }
        }
    }
}
