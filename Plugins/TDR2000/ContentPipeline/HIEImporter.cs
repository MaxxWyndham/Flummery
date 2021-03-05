using System.IO;

using ToxicRagers.TDR2000.Formats;

using Flummery.Core;
using Flummery.Core.ContentPipeline;

namespace Flummery.Plugin.TDR2000.ContentPipeline
{
    public class HIEImporter : ContentImporter
    {
        public override string GetExtension() { return "hie"; }

        public override Asset Import(string path)
        {
            HIE hie = HIE.Load(path);
            Model model = new Model();
            Model mshses = new Model();

            foreach (string mesh in hie.Meshes)
            {
                Model mshs = SceneManager.Current.Content.Load<Model, MSHSImporter>(Path.GetFileNameWithoutExtension(mesh), Path.GetDirectoryName(path));
                foreach (ModelMesh part in mshs.Meshes) { mshses.AddMesh(part); }
            }

            foreach (string texture in hie.Textures)
            {
                SceneManager.Current.Content.Load<Material, TXImporter>(texture, Path.GetDirectoryName(path), true);
            }

            processNode(hie.Root, model, mshses, hie);

            ModelManipulator.FlipAxis(model, Axis.X, true);

            return model;
        }

        protected static Material material;

        static void processNode(TDRNode node, Model model, Model mshses, HIE hie, int parentBoneIndex = 0)
        {
            int boneIndex = parentBoneIndex;

            switch (node.Type)
            {
                case TDRNode.NodeType.Matrix:
                    boneIndex = model.AddMesh(null, boneIndex);

                    model.SetName(node.Name, boneIndex);
                    model.SetTransform(node.Transform, boneIndex);
                    break;

                case TDRNode.NodeType.Mesh:
                    int index = node.Index;
                    mshses.Meshes[index].MeshParts[0].Material = material;

                    if (model.Bones[parentBoneIndex].Mesh == null)
                    {
                        model.SetMesh(mshses.Meshes[index], boneIndex);
                    }
                    else
                    {
                        boneIndex = model.AddMesh(mshses.Meshes[index], parentBoneIndex);
                        model.SetName(mshses.Meshes[index].Name, boneIndex);
                    }
                    break;

                case TDRNode.NodeType.Texture:
                    if (node.Index > -1)
                    {
                        material = SceneManager.Current.Content.Load<Material, TXImporter>(hie.Textures[node.Index]);
                    }
                    else
                    {
                        material = null;
                    }
                    break;
            }

            foreach (TDRNode child in node.Children)
            {
                processNode(child, model, mshses, hie, boneIndex);
            }
        }
    }
}
