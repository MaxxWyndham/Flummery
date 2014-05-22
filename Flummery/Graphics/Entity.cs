using System;
using System.IO;
using Flummery.ContentPipeline.Core;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

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
        VFX
    }

    public class Entity : Asset
    {
        string uniqueIdentifier;
        string name;
        string tag;
        EntityType entityType = EntityType.Powerup;
        Matrix4 transform;
        Asset asset;
        AssetType assetType = AssetType.Model;

        public string UniqueIdentifier
        {
            get { return uniqueIdentifier; }
            set { uniqueIdentifier = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public EntityType EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public Matrix4 Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Asset Asset
        {
            get { return asset; }
            set { asset = value; }
        }

        public AssetType AssetType
        {
            get { return assetType; }
            set { assetType = value; }
        }

        public void Draw()
        {
            if (Linked) { transform = ((ModelBone)link).CombinedTransform; }

            switch (assetType)
            {
                case AssetType.Model:
                    var model = asset as Model;
                    if (model != null)
                    {
                        GL.PushMatrix();

                        GL.MultMatrix(ref transform);

                        model.Draw();

                        GL.PopMatrix();
                    }
                    break;

                case AssetType.Sprite:
                    if (asset == null)
                    {
                        var sprite = new ModelMeshPart();
                        sprite.AddVertex(new Vector3(-0.5f, -0.5f, 0.0f), Vector3.UnitY, new Vector2(0, 1));
                        sprite.AddVertex(new Vector3(-0.5f,  0.5f, 0.0f), Vector3.UnitY, new Vector2(0, 0));
                        sprite.AddVertex(new Vector3( 0.5f,  0.5f, 0.0f), Vector3.UnitY, new Vector2(1, 0));
                        sprite.AddVertex(new Vector3( 0.5f, -0.5f, 0.0f), Vector3.UnitY, new Vector2(1, 1));

                        sprite.AddVertex(new Vector3( 0.5f, -0.5f, 0.0f), Vector3.UnitY, new Vector2(0, 1));
                        sprite.AddVertex(new Vector3( 0.5f,  0.5f, 0.0f), Vector3.UnitY, new Vector2(0, 0));
                        sprite.AddVertex(new Vector3(-0.5f,  0.5f, 0.0f), Vector3.UnitY, new Vector2(1, 0));
                        sprite.AddVertex(new Vector3(-0.5f, -0.5f, 0.0f), Vector3.UnitY, new Vector2(1, 1));
                        sprite.IndexBuffer.Initialise();
                        sprite.VertexBuffer.Initialise();
                        sprite.Material = new Material { Name = "Entity.Asset", Texture = SceneManager.Current.Content.Load<Texture, PNGImporter>("entity_" + entityType.ToString().ToLower(), Path.GetDirectoryName(Application.ExecutablePath) + @"\data\icons\") };
                        sprite.PrimitiveType = PrimitiveType.Quads;
                        var spritemesh = new ModelMesh();
                        spritemesh.AddModelMeshPart(sprite);
                        var spritemodel = new Model();
                        spritemodel.AddMesh(spritemesh);
                        asset = spritemodel;
                    }

                    GL.PushMatrix();

                    var position = Matrix4.CreateTranslation(transform.ExtractTranslation());

                    GL.MultMatrix(ref position);

                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    ((Model)asset).Draw();
                    GL.Disable(EnableCap.Blend);

                    GL.PopMatrix();
                    break;
            }
        }
    }
}
