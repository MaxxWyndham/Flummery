using System;
using OpenTK;
using OpenTK.Input;

namespace Flummery
{
    public class Camera
    {
        public enum Direction
        {
            Forward,
            Backward,
            Left,
            Right,
            Up,
            Down
        }

        private Vector3 position;
        private Vector3 target;
        public Matrix4 viewMatrix, projectionMatrix;

        private float yaw, pitch, roll;
        private float speed, rotationSpeed;
        private Matrix4 cameraRotation;

        public Vector3 Position { get { return position; } }

        public Camera() { ResetCamera(); }

        public void ResetCamera()
        {
            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            speed = 10.0f;
            rotationSpeed = 4.0f;

            cameraRotation = Matrix4.Identity;

            position = new Vector3(0, 2.0f, 3.0f);
        }

        public void Update(float dt)
        {
            UpdateViewMatrix();
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

        public void MoveCamera(Direction direction, float dt)
        {
            var v = Vector3.Zero;

            switch (direction)
            {
                case Direction.Forward:
                    v = cameraRotation.Forward() * dt;
                    break;

                case Direction.Backward:
                    v = -cameraRotation.Forward() * dt;
                    break;

                case Direction.Left:
                    v = -cameraRotation.Right() * dt;
                    break;

                case Direction.Right:
                    v = cameraRotation.Right() * dt;
                    break;

                case Direction.Up:
                    v = cameraRotation.Up() * dt;
                    break;

                case Direction.Down:
                    v = -cameraRotation.Up() * dt;
                    break;
            }

            position += speed * v;
        }

        public void SetPosition(float X = 0, float Y = 0, float Z = 0)
        {
            position.X = X;
            position.Y = Y;
            position.Z = Z;
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

        public void Rotate(float yaw = 0, float pitch = 0, float roll = 0)
        {
            this.yaw += yaw * rotationSpeed;
            this.pitch += pitch * rotationSpeed;
            this.roll += roll * rotationSpeed;
        }

        public void SetActionScale(float speed)
        {
            this.speed = 10.0f * speed;
        }
    }
}
