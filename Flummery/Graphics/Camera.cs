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
        private float speed, rotationSpeed;
        private Matrix4 cameraRotation;

        public Camera() { ResetCamera(); }

        public void ResetCamera()
        {
            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            speed = 1.0f;
            rotationSpeed = 0.4f;

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
                yaw += rotationSpeed * dt;
            }
            if (state[Key.Keypad6])
            {
                yaw += -rotationSpeed * dt;
            }

            if (state[Key.Keypad2])
            {
                pitch += -rotationSpeed * dt;
            }
            if (state[Key.Keypad8])
            {
                pitch += rotationSpeed * dt;
            }

            if (state[Key.Keypad7])
            {
                roll += -rotationSpeed * dt;
            }
            if (state[Key.Keypad9])
            {
                roll += rotationSpeed * dt;
            }

            //  A/Z zoom in/out, numpad 7/9 barrel roll right/left, numpad 2/8 look up/down, numpad 4/6 look left/right, numpad 1/3 strafe left/right

            if (state[Key.A])
            {
                MoveCamera(cameraRotation.Forward() * dt);
            }
            if (state[Key.Z])
            {
                MoveCamera(-cameraRotation.Forward() * dt);
            }
            if (state[Key.Keypad1])
            {
                MoveCamera(-cameraRotation.Right() * dt);
            }
            if (state[Key.Keypad3])
            {
                MoveCamera(cameraRotation.Right() * dt);
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

        private void UpdateViewMatrix()
        {
            cameraRotation.NormaliseForward();
            cameraRotation.NormaliseUp();
            cameraRotation.NormaliseRight();

            cameraRotation *= Matrix4.CreateFromAxisAngle(cameraRotation.Right(), pitch);
            cameraRotation *= Matrix4.CreateFromAxisAngle(cameraRotation.Up(), yaw);
            cameraRotation *= Matrix4.CreateFromAxisAngle(cameraRotation.Forward(), roll);

            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            target = position + cameraRotation.Forward();

            viewMatrix = Matrix4.LookAt(position, target, cameraRotation.Up());
        }

        public void MoveCamera(Vector3 addedVector)
        {
            position += speed * addedVector;
        }

        public void SetPosition(Vector3 pos)
        {
            position = pos;
        }

        public void SetRotation(float yaw, float pitch, float roll)
        {
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
        }

        public void SetActionScale(float speed)
        {
            this.speed = speed;
        }
    }
}
