using System.Collections.Generic;

namespace Flummery
{
    public class ModelMesh
    {
        BoundingBox boundingBox;
        List<ModelMeshPart> meshParts;
        string name;
        ModelBone parent;
        object tag;
        bool visible = true;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public object Tag
        {
            get => tag;
            set => tag = value;
        }

        public ModelBone Parent
        {
            get => parent;
            set => parent = value;
        }

        public List<ModelMeshPart> MeshParts => meshParts;

        public BoundingBox BoundingBox
        {
            get
            {
                if (boundingBox == null) { boundingBox = new BoundingBox(this); }
                return boundingBox;
            }
        }

        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        public ModelMesh()
        {
            meshParts = new List<ModelMeshPart>();
        }

        public ModelMesh(ModelMesh from)
        {
            meshParts = new List<ModelMeshPart>(from.meshParts);
            name = from.name;
            parent = new ModelBone();
        }

        public void AddModelMeshPart(ModelMeshPart meshpart, bool bFinalise = true)
        {
            if (bFinalise) { meshpart.Finalise(); }
            meshParts.Add(meshpart);
        }

        public List<Material> GetMaterials()
        {
            List<Material> l = new List<Material>();
            List<long> index = new List<long>();

            foreach (ModelMeshPart part in meshParts)
            {
                if (part.Material != null && !index.Contains(part.Material.Key))
                {
                    l.Add(part.Material);
                    index.Add(part.Material.Key);
                }
            }

            return l;
        }

        public void Draw()
        {
            if (visible)
            {
                foreach (ModelMeshPart meshpart in meshParts)
                {
                    meshpart.Draw();
                }
            }
        }
    }
}