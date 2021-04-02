using Flummery.Core.ContentPipeline;

using ToxicRagers.Helpers;

namespace Flummery.Core.Entities
{
    public class Icon : IEntity
    {
        private Asset asset;

        protected string IconFilename = "entity_driver";

        public string Name { get; set; }

        public object Tag { get; set; }

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public bool Lollipop { get; set; }

        public LinkType LinkType { get; private set; }

        public object Link { get; private set; }

        public bool Linked => Link != null;

        public void LinkWith(object item, LinkType linkType = LinkType.All)
        {
            Link = item;
            LinkType = linkType;
        }

        public void Draw()
        {
            if (asset == null)
            {
                ModelMeshPart sprite = new ModelMeshPart();
                sprite.AddVertex(new Vector3(-0.25f, -0.25f, 0.0f), Vector3.UnitY, new Vector2(0, 1));
                sprite.AddVertex(new Vector3(-0.25f, 0.25f, 0.0f), Vector3.UnitY, new Vector2(0, 0));
                sprite.AddVertex(new Vector3(0.25f, 0.25f, 0.0f), Vector3.UnitY, new Vector2(1, 0));
                sprite.AddVertex(new Vector3(0.25f, -0.25f, 0.0f), Vector3.UnitY, new Vector2(1, 1));

                sprite.AddVertex(new Vector3(0.25f, -0.25f, 0.0f), Vector3.UnitY, new Vector2(0, 1));
                sprite.AddVertex(new Vector3(0.25f, 0.25f, 0.0f), Vector3.UnitY, new Vector2(0, 0));
                sprite.AddVertex(new Vector3(-0.25f, 0.25f, 0.0f), Vector3.UnitY, new Vector2(1, 0));
                sprite.AddVertex(new Vector3(-0.25f, -0.25f, 0.0f), Vector3.UnitY, new Vector2(1, 1));
                sprite.IndexBuffer.Initialise();
                sprite.VertexBuffer.Initialise();
                sprite.Material = new Material { Name = "Entity.Asset", Texture = SceneManager.Current.Content.Load<Texture, PNGImporter>(IconFilename) };
                sprite.PrimitiveType = PrimitiveType.Quads;

                ModelMesh spritemesh = new ModelMesh();
                spritemesh.AddModelMeshPart(sprite);

                Model spritemodel = new Model();
                spritemodel.AddMesh(spritemesh);
                asset = spritemodel;
            }

            if (Linked)
            {
                Matrix4D parentTransform = ((ModelBone)Link).CombinedTransform;

                if (LinkType == LinkType.All)
                {
                    Transform = parentTransform;
                }
                else
                {
                    Transform = Matrix4D.Identity;

                    Vector3 v = parentTransform.ExtractTranslation();
                    parentTransform.Normalise();
                    parentTransform.M41 = v.X;
                    parentTransform.M42 = v.Y;
                    parentTransform.M43 = v.Z;

                    if (LinkType.HasFlag(LinkType.Rotation)) { Transform *= Matrix4D.CreateFromQuaternion(parentTransform.ExtractRotation()); }
                    if (LinkType.HasFlag(LinkType.Scale)) { Transform *= Matrix4D.CreateScale(parentTransform.ExtractScale()); }
                    if (LinkType.HasFlag(LinkType.Position)) { Transform *= Matrix4D.CreateTranslation(parentTransform.ExtractTranslation()); }
                }
            }

            Matrix4D mS = SceneManager.Current.Transform;
            Matrix4D mT = Transform;

            SceneManager.Current.Renderer.PushMatrix();

            Matrix4D position = Matrix4D.CreateTranslation(mT.ExtractTranslation());

            SceneManager.Current.Renderer.MultMatrix(ref mS);
            SceneManager.Current.Renderer.MultMatrix(ref position);

            if (Lollipop)
            {
                Matrix4D rotation = ViewportManager.Current.Active.Camera.Rotation;
                Matrix4D scale = Matrix4D.CreateScale(0.1f);

                SceneManager.Current.Renderer.MultMatrix(ref rotation);
                SceneManager.Current.Renderer.MultMatrix(ref scale);
            }

            SceneManager.Current.Renderer.Enable("Blend");
            SceneManager.Current.Renderer.BlendFunc("SrcAlpha", "OneMinusSrcAlpha");
            ((Model)asset).Draw();
            SceneManager.Current.Renderer.Disable("Blend");

            SceneManager.Current.Renderer.PopMatrix();
        }
    }
}
