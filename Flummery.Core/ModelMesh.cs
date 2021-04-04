using System.Collections.Generic;

namespace Flummery.Core
{
    public class ModelMesh
    {
        BoundingBox boundingBox;

        BoundingSphere boundingSphere;

        public string Name { get; set; }

        public object Tag { get; set; }

        public ModelBone Parent { get; set; }

        public List<ModelMeshPart> MeshParts { get; } = new List<ModelMeshPart>();

        public BoundingBox BoundingBox
        {
            get
            {
                if (boundingBox == null) { boundingBox = new BoundingBox(this); }

                return boundingBox;
            }
        }

        public BoundingSphere BoundingSphere
        {
            get
            {
                if (boundingSphere == null) { boundingSphere = BoundingSphere.CreateFromBoundingBox(BoundingBox); }

                return boundingSphere;
            }
        }

        public bool Visible { get; set; } = true;

        public ModelMesh() { }

        public ModelMesh(ModelMesh from)
        {
            MeshParts = new List<ModelMeshPart>(from.MeshParts.Count);

            foreach (ModelMeshPart part in from.MeshParts)
            {
                MeshParts.Add(part.Clone());
            }

            Name = from.Name;
            Parent = new ModelBone();
        }

        public void AddModelMeshPart(ModelMeshPart meshpart, bool finalise = true)
        {
            if (finalise) { meshpart.Finalise(); }
            MeshParts.Add(meshpart);
        }

        public List<Material> GetMaterials()
        {
            List<Material> l = new List<Material>();
            List<long> index = new List<long>();

            foreach (ModelMeshPart part in MeshParts)
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
            if (Visible)
            {
                foreach (ModelMeshPart meshpart in MeshParts)
                {
                    meshpart.Draw();
                }
            }
        }
    }
}