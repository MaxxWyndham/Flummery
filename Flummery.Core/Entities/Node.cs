using ToxicRagers.Helpers;

namespace Flummery.Core.Entities
{
    public class Node : IEntity
    {
        private Model model;

        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; }

        public ModelBone LinkedBone { get; set; }

        public void Draw()
        {
            if (model == null)
            {
                model = new Model();

                Sphere sphere = new Sphere(0.025f, 7, 7);
                ModelManipulator.SetVertexColour(sphere, 0, 255, 0, 255);
                model.AddMesh(sphere);
                model.SetRenderStyle(RenderStyle.Wireframe);
            }

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

            SceneManager.Current.Renderer.PushMatrix();

            SceneManager.Current.Renderer.MultMatrix(ref mS);
            SceneManager.Current.Renderer.MultMatrix(ref mT);

            model.Draw();

            SceneManager.Current.Renderer.PopMatrix();
        }
    }
}
