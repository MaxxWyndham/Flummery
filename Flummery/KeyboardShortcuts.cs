using System;
using System.ComponentModel;

namespace Flummery
{
    public partial class KeyboardShortcuts
    {
        [Description("Select"), Category("Camera Controls")]
        public char Select
        {
            get { return Properties.Settings.Default.KeysCameraSelect; }
            set { Properties.Settings.Default.KeysCameraSelect = value; }
        }

        [Description("Activates the Camera Pan mode"), Category("Camera Controls")]
        public char Pan
        {
            get { return Properties.Settings.Default.KeysCameraPan; }
            set { Properties.Settings.Default.KeysCameraPan = value; }
        }

        [Description("Activates the Camera Zoom mode"), Category("Camera Controls")]
        public char Zoom
        {
            get { return Properties.Settings.Default.KeysCameraZoom; }
            set { Properties.Settings.Default.KeysCameraZoom = value; }
        }

        [Description("Activates the Camera Rotate mode"), Category("Camera Controls")]
        public char Rotate
        {
            get { return Properties.Settings.Default.KeysCameraRotate; }
            set { Properties.Settings.Default.KeysCameraRotate = value; }
        }

        [Description("Frames the currectly selected mesh"), Category("Camera Controls")]
        public char Frame
        {
            get { return Properties.Settings.Default.KeysCameraFrame; }
            set { Properties.Settings.Default.KeysCameraFrame = value; }
        }

        [DisplayName("Action-Scale Up"), Description("Increases the current Action Scaling"), Category("Camera Controls")]
        public char ActionScaleUp
        {
            get { return Properties.Settings.Default.KeysActionScaleUp; }
            set { Properties.Settings.Default.KeysActionScaleUp = value; }
        }

        [DisplayName("Action-Scale Down"), Description("Decreases the current Action Scaling"), Category("Camera Controls")]
        public char ActionScaleDown
        {
            get { return Properties.Settings.Default.KeysActionScaleDown; }
            set { Properties.Settings.Default.KeysActionScaleDown = value; }
        }

        [DisplayName("Clear Selection"), Description("Deselects the currently selected mesh"), Category("Scene")]
        public char ClearSelection
        {
            get { return Properties.Settings.Default.KeysClearSelection; }
            set { Properties.Settings.Default.KeysClearSelection = value; }
        }

        [DisplayName("Cycle Render Mode"), Description("Cycles through the available render modes"), Category("Scene")]
        public char CycleRenderMode
        {
            get { return Properties.Settings.Default.KeysRenderMode; }
            set { Properties.Settings.Default.KeysRenderMode = value; }
        }

        [DisplayName("Toggle Coordinate System"), Description("Swaps between Left-handed and Right-handed co-ordinate systems"), Category("Scene")]
        public char ToggleCoordinateSystem
        {
            get { return Properties.Settings.Default.KeysCoordinateSystem; }
            set { Properties.Settings.Default.KeysCoordinateSystem = value; }
        }
    }
}
