using System;
using System.Collections.Generic;

using OpenTK;

namespace Flummery
{
    public class ModelMesh
    {
        BoundingBox boundingBox;
        BoundingSphere BoundingSphere;
        List<ModelMeshPart> meshParts;
        string name;
        ModelBone parent;
        object tag;
        bool visible = true;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public ModelBone Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public List<ModelMeshPart> MeshParts
        {
            get { return meshParts; }
        }

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
            get { return visible; }
            set { visible = value; }
        }

        public ModelMesh()
        {
            meshParts = new List<ModelMeshPart>();
        }

        public ModelMesh(ModelMesh from)
        {
            this.meshParts = new List<ModelMeshPart>(from.meshParts);
            this.name = from.name;
            this.parent = new ModelBone();
        }

        public void AddModelMeshPart(ModelMeshPart meshpart, bool bFinalise = true)
        {
            if (bFinalise) { meshpart.Finalise(); }
            meshParts.Add(meshpart);
        }

        public List<Material> GetMaterials()
        {
            var l = new List<Material>();
            var index = new List<long>();

            foreach (var part in meshParts)
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
