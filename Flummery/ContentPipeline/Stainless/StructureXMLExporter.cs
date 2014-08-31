using System;
using System.IO;

using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class StructureXMLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);
            if (string.Compare(Path.GetFileName(path), "structure.xml", true) != 0) { path += "\\Structure.xml"; }

            if (model.SupportingDocuments.ContainsKey("Structure"))
            {
                ((Structure)model.SupportingDocuments["Structure"]).Save(path);
            }
            else
            {
                var structure = new Structure();

                var root = new StructurePart() { IsRoot = true };

                TravelTree(model.Root, ref root, true);

                structure.Root = root;

                structure.Save(path);
            }
        }

        public static void TravelTree(ModelBone bone, ref StructurePart parent, bool root = false)
        {
            var part = new StructurePart();

            if (root) { part = parent; }

            part.Name = bone.Name;

            switch (bone.Name.ToLower())
            {
                case "driver":
                    return;

                case "wheel_fl":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_SUSPENSION);
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_STEERING);

                    part.DamageSettings.SetParameterForMethod("Crushability", "Value", 0.0f);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_LEFT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_fr":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_SUSPENSION);
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_STEERING);

                    part.DamageSettings.SetParameterForMethod("Crushability", "Value", 0.0f);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.FRONT_RIGHT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_rl":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_POINT_OF_SUSPENSION);

                    part.DamageSettings.SetParameterForMethod("Crushability", "Value", 0.0f);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_WHEEL);
                    part.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_LEFT_POINT_OF_ROTATION);
                    part.DamageSettings.SetParameterForMethod("ShapeType", "Shape", "TIC_TAC_X");
                    part.DamageSettings.SetParameterForMethod("Restitution", "Value", 2.0f);
                    break;

                case "wheel_rr":
                    parent.DamageSettings.SetParameterForMethod("PhysicsProperty", "Name", StructurePhysicsProperty.REAR_RIGHT_POINT_OF_SUSPENSION);

                    part.DamageSettings.SetParameterForMethod("Crushability", "Value", 0.0f);
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

            foreach (var b in bone.Children)
            {
                TravelTree(b, ref part);
            }

            if (!root)
            {
                var weld = new StructureWeld();
                weld.Partner = parent.Name;

                part.Welds.Add(weld);

                parent.Parts.Add(part);
            }
        }
    }
}
