using System;
using System.Collections.Generic;

namespace Flummery
{
    public class ModelMesh
    {
        BoundingBox boundingBox;
        BoundingSphere BoundingSphere;
        List<ModelMeshPart> meshParts;
        string name;
        ModelBone parent;
        object Tag;

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public void Draw()
        {
            foreach (ModelMeshPart meshpart in meshParts)
            {
                meshpart.Draw();
            }
        }
    }
}
