using System;
using OpenTK;
using OpenTK.Input;

namespace Flummery
{
    public class Camera
    {
        private Vector3 position;
        private Vector3 target;
        public Matrix4 viewMatrix, projectionMatrix;

        private float yaw, pitch, roll;
        private float speed;
        private Matrix4 cameraRotation;

        public Camera() { ResetCamera(); }

        public void ResetCamera()
        {
            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            speed = .3f;

            cameraRotation = Matrix4.Identity;

            position = new Vector3(0, 2.0f, 3.0f);
        }

        public void Update(float dt)
        {
            HandleInput(dt);
            UpdateViewMatrix();
        }

        private void HandleInput(float dt)
        {
            var state = Keyboard.GetState();

            if (state[Key.Keypad4])
            {
                yaw += .2f * dt;
            }
            if (state[Key.Keypad6])
            {
                yaw += -.2f * dt;
            }

            if (state[Key.Keypad2])
            {
                pitch += -.2f * dt;
            }
            if (state[Key.Keypad8])
            {
                pitch += .2f * dt;
            }

            if (state[Key.Keypad7])
            {
                roll += -.2f * dt;
            }
            if (state[Key.Keypad9])
            {
                roll += .2f * dt;
            }

            //  A/Z zoom in/out, numpad 7/9 barrel roll right/left, numpad 2/8 look up/down, numpad 4/6 look left/right, numpad 1/3 strafe left/right

            if (state[Key.A])
            {
                MoveCamera(GetForward(cameraRotation) * dt);
            }
            if (state[Key.Z])
            {
                MoveCamera(-GetForward(cameraRotation) * dt);
            }
            if (state[Key.Keypad1])
            {
                MoveCamera(-GetRight(cameraRotation) * dt);
            }
            if (state[Key.Keypad3])
            {
                MoveCamera(GetRight(cameraRotation) * dt);
            }

            //if (state[Key.E])
            //{
            //    MoveCamera(GetUp(cameraRotation) * dt);
            //}
            //if (state[Key.Q])
            //{
            //    MoveCamera(-GetUp(cameraRotation) * dt);
            //}
        }

        private Vector3 GetRight(Matrix4 m, bool normalise = false)
        {
            var v = new Vector3(m.M11, m.M12, m.M13);
            if (normalise) { v.Normalize(); }
            return v;
        }


        private Vector3 GetUp(Matrix4 m, bool normalise = false)
        {
            var v = new Vector3(m.M21, m.M22, m.M23);
            if (normalise) { v.Normalize(); }
            return v;
        }

        private Vector3 GetForward(Matrix4 m, bool normalise = false)
        {
            var v = new Vector3(m.M31, m.M32, m.M33);
            if (normalise) { v.Normalize(); }
            return -v;
        }

        private void UpdateViewMatrix()
        {
            var f = GetForward(cameraRotation, true);
            var u = GetUp(cameraRotation, true);
            var r = GetRight(cameraRotation, true);

            cameraRotation *= Matrix4.CreateFromAxisAngle(r, pitch);
            cameraRotation *= Matrix4.CreateFromAxisAngle(u, yaw);
            cameraRotation *= Matrix4.CreateFromAxisAngle(f, roll);

            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            target = position + f;

            viewMatrix = Matrix4.LookAt(position, target, u);
        }

        public void MoveCamera(Vector3 addedVector)
        {
            position += speed * addedVector;
        }
    }
}
