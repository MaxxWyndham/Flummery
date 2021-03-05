using System;
using System.IO;

using ToxicRagers.Helpers;

namespace Flummery.Core
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
        public string UniqueIdentifier { get; set; }

        public EntityType EntityType { get; set; } = EntityType.Powerup;

        public Matrix4D Transform { get; set; } = Matrix4D.Identity;

        public Asset Asset { get; set; }

        public AssetType AssetType { get; set; } = AssetType.Model;

        public bool Lollipop { get; set; } = false;

        public void Draw()
        {
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

                    if ((LinkType & LinkType.Rotation) == LinkType.Rotation) { Transform *= Matrix4D.CreateFromQuaternion(parentTransform.ExtractRotation()); }
                    if ((LinkType & LinkType.Scale) == LinkType.Scale) { Transform *= Matrix4D.CreateScale(parentTransform.ExtractScale()); }
                    if ((LinkType & LinkType.Position) == LinkType.Position) { Transform *= Matrix4D.CreateTranslation(parentTransform.ExtractTranslation()); }
                }
            }

            Matrix4D mS = SceneManager.Current.Transform;
            Matrix4D mT = Transform;

            switch (AssetType)
            {
                case AssetType.Model:
                    if (Asset is Model model)
                    {
                        SceneManager.Current.Renderer.PushMatrix();

                        SceneManager.Current.Renderer.MultMatrix(ref mS);
                        SceneManager.Current.Renderer.MultMatrix(ref mT);

                        model.Draw();

                        SceneManager.Current.Renderer.PopMatrix();
                    }
                    break;

                case AssetType.Sprite:
                    if (Asset == null)
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
                        //sprite.Material = new Material { Name = "Entity.Asset", Texture = SceneManager.Current.Content.Load<Texture, ContentPipeline.PNGImporter>($"entity_{EntityType.ToString().ToLower()}", Path.GetDirectoryName(Application.ExecutablePath) + @"\data\icons\") };
                        sprite.PrimitiveType = PrimitiveType.Quads;

                        ModelMesh spritemesh = new ModelMesh();
                        spritemesh.AddModelMeshPart(sprite);

                        Model spritemodel = new Model();
                        spritemodel.AddMesh(spritemesh);
                        Asset = spritemodel;
                    }

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
                    ((Model)Asset).Draw();
                    SceneManager.Current.Renderer.Disable("Blend");

                    SceneManager.Current.Renderer.PopMatrix();
                    break;
            }
        }
    }
}