using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Flummery.Core;

using ToxicRagers.CarmageddonReincarnation.Formats;
using ToxicRagers.Helpers;

namespace Flummery
{
    public partial class MaterialEditor : Form
    {
        MT2 material;

        public MaterialEditor(Material M)
        {
            InitializeComponent();

            cboBaseMaterial.SelectedIndex = 15;

            if (M.SupportingDocuments.ContainsKey("Source") && M.SupportingDocuments["Source"] is MT2 m)
            {
                material = m;

                setMaterial(material);
            }

            if (M.Texture != null) { pbPreview.Image = M.Texture.GetThumbnail(256); }
        }

        private void setMaterial(MT2 m)
        {
            lstSamplersAndTexCoordSources.Items.Clear();

            txtMaterialName.Text = m.Name;
            cboBaseMaterial.Text = m.BasedOffOf;

            setUIFromObject((MT2)Activator.CreateInstance(m.GetType()));
            setUIFromObject(m);

            //foreach (Sampler sampler in m.Defaults.Samplers)
            //{
            //}
        }

        private void cboBaseMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDiffuseColour.Text == txtDiffuseColour.Tag.ToString()) { txtDiffuseColour.Text = ""; }
            if (txtDiffuse2.Text == txtDiffuse2.Tag.ToString()) { txtDiffuse2.Text = ""; }
            if (txtDiffuse3.Text == txtDiffuse3.Tag.ToString()) { txtDiffuse3.Text = ""; }
            if (txtNormal1.Text == txtNormal1.Tag.ToString()) { txtNormal1.Text = ""; }
            if (txtNormal2.Text == txtNormal2.Tag.ToString()) { txtNormal2.Text = ""; }
            if (txtNormal3.Text == txtNormal3.Tag.ToString()) { txtNormal3.Text = ""; }
            if (txtSpecular1.Text == txtSpecular1.Tag.ToString()) { txtSpecular1.Text = ""; }
            if (txtSpecular2.Text == txtSpecular2.Tag.ToString()) { txtSpecular2.Text = ""; }
            if (txtSpecular3.Text == txtSpecular3.Tag.ToString()) { txtSpecular3.Text = ""; }
            if (txtBlendMap.Text == txtBlendMap.Tag.ToString()) { txtBlendMap.Text = ""; }

            flpMaterialOptions.SuspendLayout();

            pnlDiffuse1.Visible = false;
            pnlDiffuse2.Visible = false;
            pnlDiffuse3.Visible = false;
            pnlNormal1.Visible = false;
            pnlNormal2.Visible = false;
            pnlNormal3.Visible = false;
            pnlSpecular1.Visible = false;
            pnlSpecular2.Visible = false;
            pnlSpecular3.Visible = false;
            pnlBlendMap.Visible = false;
            pnlBlendFactor.Visible = false;
            pnlFalloff.Visible = false;
            pnlBlendUVSlot.Visible = false;
            pnlLayer1UVSlot.Visible = false;
            pnlLayer2UVSlot.Visible = false;
            pnlSpecColourB.Visible = false;
            pnlAmbientLightR.Visible = false;
            pnlAmbientLightG.Visible = false;
            pnlAmbientLightB.Visible = false;
            pnlNoSortAlpha.Visible = false;

            switch (((ComboBox)sender).Text)
            {
                case "car_shader_base":
                case "car_shader_glass":
                case "car_shader_no_normals_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";
                    break;

                case "car_shader_base2":
                    pnlDiffuse1.Visible = true;
                    pnlDiffuse2.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlSpecular2.Visible = true;
                    pnlBlendMap.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;
                    pnlLayer2UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtDiffuse2.Tag = "diffuse colour 2";
                    txtNormal1.Tag = "normal map";
                    txtNormal2.Tag = "normal map 2";
                    txtSpecular1.Tag = "spec map";
                    txtSpecular2.Tag = "spec map 2";
                    txtBlendMap.Tag = "blendmap";

                    lblBlendFactor.Text = "Blend Factor";
                    lblFalloff.Text = "Falloff";
                    lblBlendUVSlot.Text = "Blend UV Slot";
                    lblLayer1UVSlot.Text = "Layer 1 UV Slot";
                    lblLayer2UVSlot.Text = "Layer 2 UV Slot";
                    break;

                case "car_shader_double_sided_base":
                    pnlDiffuse1.Visible = true;
                    pnlDiffuse2.Visible = true;
                    pnlDiffuse3.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;
                    pnlNormal3.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlSpecular2.Visible = true;
                    pnlSpecular3.Visible = true;
                    pnlBlendMap.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;
                    pnlLayer2UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "side 1 diffuse colour 2";
                    txtDiffuse2.Tag = "side 1 diffuse colour 1";
                    txtDiffuse3.Tag = "side 2 diffuse colour";
                    txtNormal1.Tag = "side 1 normal map 2";
                    txtNormal2.Tag = "side 1 normal map 1";
                    txtNormal3.Tag = "side 2 normal map";
                    txtSpecular1.Tag = "side 1 spec map 2";
                    txtSpecular2.Tag = "side 1 spec map 1";
                    txtSpecular3.Tag = "side 2 spec map";
                    txtBlendMap.Tag = "blendmap";

                    lblBlendFactor.Text = "Blend Factor";
                    lblFalloff.Text = "Falloff";
                    lblBlendUVSlot.Text = "Blend UV Slot";
                    lblLayer1UVSlot.Text = "Layer 1 UV Slot";
                    lblLayer2UVSlot.Text = "Layer 2 UV Slot";
                    break;

                case "decal_base":
                    pnlDiffuse1.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";

                    lblBlendFactor.Text = "Tile Size X";
                    lblFalloff.Text = "Tile Size Y";
                    lblBlendUVSlot.Text = "Blend UV Slot";
                    lblLayer1UVSlot.Text = "Layer 1 UV Slot";
                    lblLayer2UVSlot.Text = "Layer 2 UV Slot";
                    break;

                case "effects_fluid":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;
                    pnlSpecular2.Visible = true;
                    pnlDiffuse3.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtNormal2.Tag = "normal map 2";
                    txtSpecular2.Tag = "noise";
                    txtDiffuse3.Tag = "reflect 2d";

                    lblBlendFactor.Text = "Spec Colour R";
                    lblFalloff.Text = "Spec Colour G";
                    lblBlendUVSlot.Text = "Spec Colour B";
                    lblLayer1UVSlot.Text = "Spec Power";
                    break;

                case "fog":
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;
                    pnlLayer2UVSlot.Visible = true;

                    lblBlendFactor.Text = "Main Colour R";
                    lblFalloff.Text = "Main Colour G";
                    lblBlendUVSlot.Text = "Main Colour B";
                    lblLayer1UVSlot.Text = "Min Distance";
                    lblLayer2UVSlot.Text = "Max Distance";
                    break;

                case "glass_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlBlendMap.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";
                    txtBlendMap.Tag = "cube map";
                    break;

                case "glow_in_the_dark_paint":
                    pnlNormal1.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;
                    pnlLayer2UVSlot.Visible = true;
                    pnlSpecColourB.Visible = true;
                    pnlAmbientLightR.Visible = true;
                    pnlAmbientLightG.Visible = true;
                    pnlAmbientLightB.Visible = true;

                    txtNormal1.Tag = "normal map";

                    lblBlendFactor.Text = "Diffuse Colour R";
                    lblFalloff.Text = "Diffuse Colour G";
                    lblBlendUVSlot.Text = "Diffuse Colour B";
                    lblLayer1UVSlot.Text = "Specular Colour R";
                    lblLayer2UVSlot.Text = "Specular Colour G";
                    lblAmbientLightR.Text = "Ambient Light R";
                    break;

                case "glow_simple_norm_spec_env_base":
                case "simple_norm_spec_env_base_A":
                case "simple_norm_spec_env_unlit_base":
                case "unlit_1bit_base":
                case "unlit_base":
                case "vertex_norm_spec_env_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";
                    break;

                case "glow_simple_norm_spec_env_base_A":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlNoSortAlpha.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";

                    chkNoSortAlpha.Text = "No Sort Alpha";
                    break;

                case "ped_base":
                case "simple_1bit_base":
                case "simple_additive_base":
                case "simple_base":
                case "skybox_base":
                    pnlDiffuse1.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    break;

                case "repulse_base":
                    // TODO
                    break;

                case "simple_norm_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";

                    lblBlendFactor.Text = "Spec Colour R";
                    lblFalloff.Text = "Spec Colour G";
                    lblBlendUVSlot.Text = "Spec Colour B";
                    lblLayer1UVSlot.Text = "Spec Power";
                    break;

                case "simple_norm_detail_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtNormal2.Tag = "normal map 2";
                    break;

                case "simple_norm_spec_1bit_env_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlBlendFactor.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";

                    lblBlendFactor.Text = "Transmissive Factor";
                    break;

                case "simple_norm_spec_env_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlBlendMap.Visible = true;
                    pnlNoSortAlpha.Visible = true;
                    pnlAmbientLightR.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtSpecular1.Tag = "spec map";
                    txtBlendMap.Tag = "environment cube";

                    chkNoSortAlpha.Text = "Direction Set";

                    lblAmbientLightR.Text = "Direction Angle";
                    nudAmbientLightR.Tag = "DirectionAngle";
                    break;

                case "simple_norm_spec_env_blend_base":
                    pnlDiffuse1.Visible = true;
                    pnlDiffuse2.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlSpecular2.Visible = true;
                    pnlSpecular3.Visible = true;
                    pnlBlendMap.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;
                    pnlLayer2UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtDiffuse2.Tag = "diffuse colour 2";
                    txtNormal1.Tag = "normal map";
                    txtNormal2.Tag = "normal map 2";
                    txtSpecular1.Tag = "spec map";
                    txtSpecular2.Tag = "spec map 2";
                    txtSpecular3.Tag = "environment cube";
                    txtBlendMap.Tag = "blendmap";

                    lblBlendFactor.Text = "Blend Factor";
                    lblFalloff.Text = "Falloff";
                    lblBlendUVSlot.Text = "Blend UV Slot";
                    lblLayer1UVSlot.Text = "Layer 1 UV Slot";
                    lblLayer2UVSlot.Text = "Layer 2 UV Slot";
                    break;

                case "simple_spec_base":
                    pnlDiffuse1.Visible = true;
                    pnlSpecular1.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtSpecular1.Tag = "spec map";
                    break;

                case "test_blood_particle_base":
                    // TODO
                    break;

                case "water_base":
                    pnlDiffuse1.Visible = true;
                    pnlNormal1.Visible = true;
                    pnlNormal2.Visible = true;
                    pnlSpecular1.Visible = true;
                    pnlSpecular3.Visible = true;
                    pnlBlendMap.Visible = true;
                    pnlBlendFactor.Visible = true;
                    pnlFalloff.Visible = true;
                    pnlBlendUVSlot.Visible = true;
                    pnlLayer1UVSlot.Visible = true;

                    txtDiffuseColour.Tag = "diffuse colour";
                    txtNormal1.Tag = "normal map";
                    txtNormal2.Tag = "normal map 2";
                    txtSpecular1.Tag = "spec map";
                    txtSpecular3.Tag = "environment cube";
                    txtBlendMap.Tag = "foam map";

                    lblBlendFactor.Text = "Min Distance";
                    lblFalloff.Text = "Max Distance";
                    lblBlendUVSlot.Text = "Sea Falloff";
                    lblLayer1UVSlot.Text = "Shore Factor";
                    break;
            }

            setTextBoxState(txtDiffuseColour);
            setTextBoxState(txtDiffuse2);
            setTextBoxState(txtDiffuse3);
            setTextBoxState(txtNormal1);
            setTextBoxState(txtNormal2);
            setTextBoxState(txtNormal3);
            setTextBoxState(txtSpecular1);
            setTextBoxState(txtSpecular2);
            setTextBoxState(txtSpecular3);
            setTextBoxState(txtBlendMap);

            flpMaterialOptions.ResumeLayout();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        private IEnumerable<Control> controlWithTag(string tag, Control x)
        {
            IEnumerable<Control> controls = x.Controls.Cast<Control>();

            return controls.SelectMany(c => controlWithTag(tag, c))
                           .Concat(controls)
                           .Where(c => c.Tag != null && string.Compare(c.Tag.ToString().Replace(" ", ""), tag.Replace("_", ""), true) == 0);
        }

        private void setTextBoxState(TextBox txt)
        {
            if (txt.Text == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = SystemColors.GrayText;
            }
            else
            {
                txt.ForeColor = SystemColors.WindowText;
            }
        }

        private void setUIFromObject(MT2 m)
        {
            foreach (PropertyInfo property in m.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    object[] attributes = property.GetCustomAttributes(true);
                    bool bRequired = attributes.Any(a => a.GetType() == typeof(Required));

                    switch (property.PropertyType.ToString().Split('.').Last())
                    {
                        case "Vector3":
                            Vector3 v = (Vector3)property.GetValue(m, null);

                            if (Controls.Find($"nud{property.Name}X", true).Any())
                            {
                                (Controls.Find($"nud{property.Name}X", true).FirstOrDefault() as NumericUpDown).Value = (decimal)v.X;
                                (Controls.Find($"nud{property.Name}Y", true).FirstOrDefault() as NumericUpDown).Value = (decimal)v.Y;
                                (Controls.Find($"nud{property.Name}Z", true).FirstOrDefault() as NumericUpDown).Value = (decimal)v.Z;
                            }
                            break;

                        case "Single":
                            NumericUpDown nud = (Controls.Find("nud" + property.Name, true).FirstOrDefault() as NumericUpDown);
                            if (nud == null) { nud = (NumericUpDown)controlWithTag(property.Name, this).First(); }
                            nud.Value = (decimal)(float)property.GetValue(m, null);
                            break;

                        case "Troolean":
                            {
                                CheckBox chk = (Controls.Find("chk" + property.Name, true).FirstOrDefault() as CheckBox);
                                if (chk == null) { chk = chkNoSortAlpha; }
                                Troolean value = (Troolean)property.GetValue(m, null);
                                if (value != Troolean.Unset) { chk.Checked = (value == Troolean.True); }
                            }
                            break;

                        case "String":
                            {
                                TextBox txt = (Controls.Find("txt" + property.Name, true).FirstOrDefault() as TextBox);
                                if (txt == null) { txt = (TextBox)controlWithTag(property.Name, this).FirstOrDefault(); }
                                if (txt == null)
                                {
                                    Console.WriteLine($"Couldn't find txt{property.Name}");
                                    continue;
                                }

                                txt.Text = (string)property.GetValue(m, null);
                                setTextBoxState(txt);
                            }
                            break;

                        default:
                            Console.WriteLine($"[{property.PropertyType}] {property.Name} = {property.GetValue(m, null)}");
                            break;
                    }

                }
            }
        }

        private void setElementFromProperty(PropertyInfo property)
        {
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
        }
    }
}