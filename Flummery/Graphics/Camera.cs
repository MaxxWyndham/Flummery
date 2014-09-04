using System;
using OpenTK;
using OpenTK.Input;

namespace Flummery
{
    public enum Projection
    {
        Orthographic,
        Perspective
    }

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
        private Vector3 target = Vector3.Zero;

        public Matrix4 viewMatrix, projectionMatrix;

        private float yaw, pitch, roll;
        private float speed, rotationSpeed, zoomSpeed;
        private Matrix4 cameraRotation;

        Projection projectionMode = Projection.Perspective;

        public Vector3 Position { get { return position; } }
        public float Speed { get { return speed; } }
        public float RotationSpeed { get { return rotationSpeed; } }
        public float ZoomSpeed { get { return zoomSpeed; } }

        public Projection ProjectionMode
        {
            get { return projectionMode; }
            set { projectionMode = value; }
        }

        float zoom = 1.0f;

        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                zoom = Math.Max(0.001f, zoom);
            }
        }

        public Camera() { ResetCamera(); }

        public void ResetCamera()
        {
            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            speed = 10.0f;
            rotationSpeed = 0.005f;
            zoomSpeed = 0.001f;

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

            position = target - (cameraRotation.Forward() * zoom);

            viewMatrix = Matrix4.LookAt(position, target, cameraRotation.Up());
        }

        public void Frame(ModelMesh mesh)
        {
            //viewport.Camera.ResetCamera();
            target = Vector3.TransformPosition(mesh.BoundingBox.Centre, mesh.Parent.CombinedTransform * SceneManager.Current.Transform);
            //viewport.Camera.MoveCamera(Camera.Direction.Backward, 10.0f);
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

        public void Translate(float X = 0, float Y = 0, float Z = 0)
        {
            target += Vector3.Transform(new Vector3(X, Y, Z), cameraRotation);
        }

        public void SetActionScale(float speed)
        {
            this.speed = 1.25f * speed;
            this.rotationSpeed = 0.005f * speed;
            this.zoomSpeed = 0.001f * speed;
        }
    }
}
