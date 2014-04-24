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
        }

        public void Update(float dt)
        {
            HandleInput(dt);
            UpdateViewMatrix();
        }

        private void HandleInput(float dt)
        {
            var state = Keyboard.GetState();

            if (state[Key.J])
            {
                yaw += .02f * dt;
            }
            if (state[Key.L])
            {
                yaw += -.02f * dt;
            }
            if (state[Key.I])
            {
                pitch += -.02f * dt;
            }
            if (state[Key.K])
            {
                pitch += .02f * dt;
            }
            if (state[Key.U])
            {
                roll += -.02f * dt;
            }
            if (state[Key.O])
            {
                roll += .02f * dt;
            }

            if (state[Key.W])
            {
                MoveCamera(GetForward(cameraRotation) * dt);
            }
            if (state[Key.S])
            {
                MoveCamera(-GetForward(cameraRotation) * dt);
            }
            if (state[Key.A])
            {
                MoveCamera(-GetRight(cameraRotation) * dt);
            }
            if (state[Key.D])
            {
                MoveCamera(GetRight(cameraRotation) * dt);
            }
            if (state[Key.E])
            {
                MoveCamera(GetUp(cameraRotation) * dt);
            }
            if (state[Key.Q])
            {
                MoveCamera(-GetUp(cameraRotation) * dt);
            }
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
