using System;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

using Flummery.Core.ContentPipeline;
using Flummery.Core;

namespace Flummery.Plugin.CarmageddonMaxDamage.ContentPipeline
{
    public class StructureXMLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = (asset as Model);
            if (string.Compare(Path.GetFileName(path), "structure.xml", true) != 0) { path += "\\Structure.XML"; }

            if (model.SupportingDocuments.ContainsKey("Structure"))
            {
                ((Structure)model.SupportingDocuments["Structure"]).Save(path);
            }
            else
            {
                Structure structure = new Structure();

                StructurePart root = new StructurePart() { IsRoot = true };

                TravelTree(model.Root, ref root, true);

                structure.Root = root;

                structure.Save(path);
            }
        }

        public static void TravelTree(ModelBone bone, ref StructurePart parent, bool root = false)
        {
            StructurePart part = new StructurePart();

            if (root) { part = parent; }

            part.Name = bone.Name;

            switch (bone.Name.ToLower())
            {
                case "driver":
                    return;

                case "wheel_fl":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_SUSPENSION);
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_STEERING);

                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_fr":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_SUSPENSION);
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_STEERING);

                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_rl":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_POINT_OF_SUSPENSION);

                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_rr":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_RIGHT_POINT_OF_SUSPENSION);

                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_RIGHT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_RIGHT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                default:
                    if (bone.Name.Length > 2 && bone.Name.StartsWith("c_", StringComparison.InvariantCultureIgnoreCase))
                    {
                        part.DamageSettings.SetParameterForMethod("Crushability", "Value", 1.0f);
                    }
                    else
                    {
                        part.DamageSettings.SetParameterForMethod("Crushability", "Value", 0.0f);
                    }
                    break;
            }

            foreach (ModelBone b in bone.Children)
            {
                TravelTree(b, ref part);
            }

            if (!root)
            {
                StructureWeld weld = new StructureWeld
                {
                    Partner = parent.Name
                };

                weld.WeldSettings.SetParametersForMethod("PartSpaceVertex", "X", 0, "Y", 0, "Z", 0);

                part.Welds.Add(weld);

                parent.Parts.Add(part);
            }
        }
    }
}
