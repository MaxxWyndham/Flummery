using System.IO;
using System.Windows.Forms;

using Flummery.ContentPipeline.Core;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Flummery
{
    public enum AssetType
    {
        Sprite,
        Model
    }

    public enum EntityType
    {
        Accessory,
        Bone,
        Checkpoint,
        CopSpawn,
        Driver,
        Grid,
        Light,
        Powerup,
        RaceNode,
        Wheel,
        VFX,
        Crush
    }

    public class Entity : Asset
    {
        string uniqueIdentifier;
        EntityType entityType = EntityType.Powerup;
        Matrix4 transform;
        Asset asset;
        AssetType assetType = AssetType.Model;

        bool isLollipop = false;

        public string UniqueIdentifier
        {
            get => uniqueIdentifier;
            set => uniqueIdentifier = value;
        }

        public EntityType EntityType
        {
            get => entityType;
            set => entityType = value;
        }

        public Matrix4 Transform
        {
            get => transform;
            set => transform = value;
        }

        public Asset Asset
        {
            get => asset;
            set => asset = value;
        }

        public AssetType AssetType
        {
            get => assetType;
            set => assetType = value;
        }

        public bool Lollipop
        {
            get => isLollipop;
            set => isLollipop = value;
        }

        public void Draw()
        {
            if (Linked)
            {
                Matrix4 parentTransform = ((ModelBone)link).CombinedTransform;

                if (linkType == LinkType.All)
                {
                    transform = parentTransform;
                }
                else
                {
                    transform = Matrix4.Identity;

                    Vector3 v = parentTransform.ExtractTranslation();
                    parentTransform.Normalize();
                    parentTransform.M41 = v.X;
                    parentTransform.M42 = v.Y;
                    parentTransform.M43 = v.Z;

                    if ((linkType & LinkType.Rotation) == LinkType.Rotation) { transform *= Matrix4.CreateFromQuaternion(parentTransform.ExtractRotation()); }
                    if ((linkType & LinkType.Scale) == LinkType.Scale) { transform *= Matrix4.CreateScale(parentTransform.ExtractScale()); }
                    if ((linkType & LinkType.Position) == LinkType.Position) { transform *= Matrix4.CreateTranslation(parentTransform.ExtractTranslation()); }
                }
            }

            Matrix4 mS = SceneManager.Current.Transform;
            Matrix4 mT = transform;

            switch (assetType)
            {
                case AssetType.Model:
                    Model model = asset as Model;
                    if (model != null)
                    {
                        GL.PushMatrix();

                        GL.MultMatrix(ref mS);
                        GL.MultMatrix(ref mT);

                        model.Draw();

                        GL.PopMatrix();
                    }
                    break;

                case AssetType.Sprite:
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
                        sprite.Material = new Material { Name = "Entity.Asset", Texture = SceneManager.Current.Content.Load<Texture, PNGImporter>("entity_" + entityType.ToString().ToLower(), Path.GetDirectoryName(Application.ExecutablePath) + @"\data\icons\") };
                        sprite.PrimitiveType = PrimitiveType.Quads;

                        ModelMesh spritemesh = new ModelMesh();
                        spritemesh.AddModelMeshPart(sprite);

                        Model spritemodel = new Model();
                        spritemodel.AddMesh(spritemesh);
                        asset = spritemodel;
                    }

                    GL.PushMatrix();

                    Matrix4 position = Matrix4.CreateTranslation(mT.ExtractTranslation());


                    GL.MultMatrix(ref mS);
                    GL.MultMatrix(ref position);


                    if (isLollipop)
                    {
                        Matrix4 rotation = ViewportManager.Current.Active.Camera.Rotation;
                        Matrix4 scale = Matrix4.CreateScale(0.1f);

                        GL.MultMatrix(ref rotation);
                        GL.MultMatrix(ref scale);
                    }

                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                    ((Model)asset).Draw();
                    GL.Disable(EnableCap.Blend);

                    GL.PopMatrix();
                    break;
            }
        }
    }
}