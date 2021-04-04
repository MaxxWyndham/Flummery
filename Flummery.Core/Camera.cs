using System;

using ToxicRagers.Helpers;

namespace Flummery.Core
{
    public enum ProjectionType
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

        private Vector3 target = Vector3.Zero;
        private float yaw, pitch, roll;

        public Vector3 Position { get; private set; }

        public Vector3 Up => Rotation.Up();

        public float Speed { get; private set; }

        public float RotationSpeed { get; private set; }

        public float ZoomSpeed { get; private set; }

        public Matrix4D View { get; private set; }

        public Matrix4D Rotation { get; private set; }

        public ProjectionType ProjectionMode { get; set; } = ProjectionType.Perspective;

        public Vector3 CameraDirection => (target - Position).Normalised;

        float zoom = 1.0f;

        public float Zoom
        {
            get => zoom;
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

            Speed = 10.0f;
            RotationSpeed = 0.005f;
            ZoomSpeed = 0.001f;

            Rotation = Matrix4D.Identity;

            Position = new Vector3(0, 2.0f, 3.0f);
        }

        public void Update(float dt)
        {
            updateViewMatrix();
        }

        private void updateViewMatrix()
        {
            Rotation *= Matrix4D.CreateFromAxisAngle(Rotation.Up(), yaw);
            Rotation *= Matrix4D.CreateFromAxisAngle(Rotation.Right(), pitch);
            Rotation *= Matrix4D.CreateFromAxisAngle(Rotation.Forward(), roll);

            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            Position = target - (Rotation.Forward() * (ProjectionMode == ProjectionType.Perspective ? zoom : 25));

            View = Matrix4D.LookAt(Position, target, Rotation.Up());
        }

        public void Frame(ModelMesh mesh)
        {
            target = Vector3.TransformVector(Vector3.TransformVector(mesh.BoundingBox.Centre, mesh.Parent.CombinedTransform), SceneManager.Current.Transform);
        }

        public void MoveCamera(Direction direction, float dt)
        {
            Vector3 v = Vector3.Zero;

            switch (direction)
            {
                case Direction.Forward:
                    v = Rotation.Forward() * dt;
                    break;

                case Direction.Backward:
                    v = -Rotation.Forward() * dt;
                    break;

                case Direction.Left:
                    v = -Rotation.Right() * dt;
                    break;

                case Direction.Right:
                    v = Rotation.Right() * dt;
                    break;

                case Direction.Up:
                    v = Rotation.Up() * dt;
                    break;

                case Direction.Down:
                    v = -Rotation.Up() * dt;
                    break;
            }

            Position += Speed * v;
        }

        public void SetPosition(float X = 0, float Y = 0, float Z = 0)
        {
            Position.X = X;
            Position.Y = Y;
            Position.Z = Z;
        }

        public void SetPosition(Vector3 pos)
        {
            Position = pos;
        }

        public void SetRotation(float yaw, float pitch, float roll)
        {
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
        }

        public void Rotate(float yaw = 0, float pitch = 0, float roll = 0, bool bApplySpeed = true)
        {
            this.yaw += yaw * (bApplySpeed ? RotationSpeed : 1);
            this.pitch += pitch * (bApplySpeed ? RotationSpeed : 1);
            this.roll += roll * (bApplySpeed ? RotationSpeed : 1);
        }

        public void Translate(float X = 0, float Y = 0, float Z = 0)
        {
            target += Vector3.TransformVector(new Vector3(X, Y, Z), Rotation);
        }

        public void SetActionScale(float speed)
        {
            Speed = 1.25f * speed;
            RotationSpeed = 0.005f * speed;
            ZoomSpeed = 0.001f * speed;
        }
    }
}