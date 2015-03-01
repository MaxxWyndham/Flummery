using System;
using System.IO;

using thatGameEngine;
using thatGameEngine.ContentPipeline;
using ToxicRagers.CarmageddonReincarnation.Formats;

namespace Flummery.ContentPipeline.Stainless
{
    class SystemsDamageXMLExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            var model = (asset as Model);

            if (model.SupportingDocuments.ContainsKey("SystemsDamage"))
            {
                ((SystemsDamage)model.SupportingDocuments["SystemsDamage"]).Save(path);
            }
            else
            {
                SystemsDamageSystemUnit unit;
                var systemsDamage = new SystemsDamage();

                unit = new SystemsDamageSystemUnit() { UnitType = SystemsDamageSystemUnitType.bodywork };
                unit.Settings = new SystemsDamageUnitCode();
                unit.Settings.SetParametersForMethod("CrushablePart", "Part", model.Root.Name, "A", 1.0f, "B", 0.15f);
                unit.Settings.SetParametersForMethod("WastedLinearContribution", "A", 1.0f, "B", 0.5f, "C", 0.5f);
                systemsDamage.Units.Add(unit);

                unit = new SystemsDamageSystemUnit() { UnitType = SystemsDamageSystemUnitType.fl_wheel };
                unit.Settings = new SystemsDamageUnitCode();
                unit.Settings.SetParametersForMethod("ComplicatedWheel", "Wheel", "Wheel_FL", "A", 1.0f);
                unit.Settings.SetParametersForMethod("SolidPart", "Part", "Wheel_FL", "A", 0.25f, "B", 1.0f);
                unit.Settings.SetParameterForMethod("WastedContribution", "Factor", 0.08f);
                unit.Settings.SetParameterForMethod("DamageEffect_Brakes", "Factor", 0.5f);
                systemsDamage.Units.Add(unit);

                unit = new SystemsDamageSystemUnit() { UnitType = SystemsDamageSystemUnitType.fr_wheel };
                unit.Settings = new SystemsDamageUnitCode();
                unit.Settings.SetParametersForMethod("ComplicatedWheel", "Wheel", "Wheel_FR", "A", 1.0f);
                unit.Settings.SetParametersForMethod("SolidPart", "Part", "Wheel_FR", "A", 0.25f, "B", 1.0f);
                unit.Settings.SetParameterForMethod("WastedContribution", "Factor", 0.08f);
                unit.Settings.SetParameterForMethod("DamageEffect_Brakes", "Factor", 0.5f);
                systemsDamage.Units.Add(unit);

                unit = new SystemsDamageSystemUnit() { UnitType = SystemsDamageSystemUnitType.rl_wheel };
                unit.Settings = new SystemsDamageUnitCode();
                unit.Settings.SetParametersForMethod("ComplicatedWheel", "Wheel", "Wheel_RL", "A", 1.0f);
                unit.Settings.SetParametersForMethod("SolidPart", "Part", "Wheel_RL", "A", 0.25f, "B", 1.0f);
                unit.Settings.SetParameterForMethod("WastedContribution", "Factor", 0.08f);
                systemsDamage.Units.Add(unit);

                unit = new SystemsDamageSystemUnit() { UnitType = SystemsDamageSystemUnitType.rr_wheel };
                unit.Settings = new SystemsDamageUnitCode();
                unit.Settings.SetParametersForMethod("ComplicatedWheel", "Wheel", "Wheel_RR", "A", 1.0f);
                unit.Settings.SetParametersForMethod("SolidPart", "Part", "Wheel_RR", "A", 0.25f, "B", 1.0f);
                unit.Settings.SetParameterForMethod("WastedContribution", "Factor", 0.08f);
                systemsDamage.Units.Add(unit);

                systemsDamage.Save(path);
            }
        }
    }
}
