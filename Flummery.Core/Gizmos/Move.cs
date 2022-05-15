using System.Drawing;

using ToxicRagers.Helpers;

namespace Flummery.Core.Gizmos
{
    public class Move : IGizmo, IEntity
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public ModelBone LinkedBone { get; set; }

        public void Draw()
        {
            IRenderer renderer = SceneManager.Current.Renderer;

            Matrix4D parentTransform = LinkedBone.CombinedTransform;

            Transform = Matrix4D.Identity;

            Vector3 v = parentTransform.ExtractTranslation();
            parentTransform.Normalise();
            parentTransform.M41 = v.X;
            parentTransform.M42 = v.Y;
            parentTransform.M43 = v.Z;

            Transform *= Matrix4D.CreateFromQuaternion(parentTransform.ExtractRotation());
            Transform *= Matrix4D.CreateTranslation(parentTransform.ExtractTranslation());

            Matrix4D mS = SceneManager.Current.Transform;
            Matrix4D mT = Transform;
            Matrix4D scale = Matrix4D.CreateScale(0.01f);

            renderer.PolygonMode("FrontAndBack", "Fill");
            renderer.Disable("CullFace");
            renderer.Disable("Lighting");
            renderer.Disable("Texture2D");

            renderer.PushMatrix();
            renderer.MultMatrix(ref mS);
            renderer.MultMatrix(ref mT);
            renderer.MultMatrix(ref scale);

            renderer.Begin(PrimitiveType.LineStrip);
            renderer.Color4(Color.Blue);
            renderer.LineWidth(5);
            renderer.Vertex3(0, 0, 0); renderer.Vertex3(10, 0, 0);
            renderer.End();

            renderer.Begin(PrimitiveType.Triangles);
            renderer.Color4(Color.Blue);
            renderer.Vertex3(10, -2, 0); renderer.Vertex3(15, 0, 0); renderer.Vertex3(10, 2, 0);
            renderer.Vertex3(10, 0, -2); renderer.Vertex3(15, 0, 0); renderer.Vertex3(10, 0, 2);
            renderer.End();

            renderer.Begin(PrimitiveType.LineStrip);
            renderer.Color4(Color.Green);
            renderer.LineWidth(5);
            renderer.Vertex3(0, 0, 0); renderer.Vertex3(0, 10, 0);
            renderer.End();

            renderer.Begin(PrimitiveType.Triangles);
            renderer.Color4(Color.Green);
            renderer.Vertex3(-2, 10, 0); renderer.Vertex3(0, 15, 0); renderer.Vertex3(2, 10, 0);
            renderer.Vertex3(0, 10, -2); renderer.Vertex3(0, 15, 0); renderer.Vertex3(0, 10, 2);
            renderer.End();

            renderer.Begin(PrimitiveType.LineStrip);
            renderer.Color4(Color.Red);
            renderer.LineWidth(5);
            renderer.Vertex3(0, 0, 0); renderer.Vertex3(0, 0, 10);
            renderer.End();

            renderer.Begin(PrimitiveType.Triangles);
            renderer.Color4(Color.Red);
            renderer.Vertex3(0, -2, 10); renderer.Vertex3(0, 0, 15); renderer.Vertex3(0, 2, 10);
            renderer.Vertex3(-2, 0, 10); renderer.Vertex3(0, 0, 15); renderer.Vertex3(2, 0, 10);
            renderer.End();

            renderer.PopMatrix();

            renderer.Enable("DepthTest");
            renderer.Enable("Lighting");
            renderer.Enable("Texture2D");
        }
    }
}
