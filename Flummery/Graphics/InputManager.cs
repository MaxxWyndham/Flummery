using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using OpenTK.Input;

namespace Flummery
{
    public enum KeyBinding
    {
        KeysCameraSelect,
        KeysCameraPan,
        KeysCameraZoom,
        KeysCameraRotate,
        KeysCameraFrame,

        KeysActionScaleUp,
        KeysActionScaleDown,

        KeysClearSelection,
        KeysRenderMode,
        KeysCoordinateSystem
    }

    public class InputManager
    {
        Dictionary<char, Action> bindings;
        Dictionary<KeyBinding, char> bindingLookup;
        KeyboardState lastState;

        public static InputManager Current;

        public delegate void BindingsChangedHandler(object sender, EventArgs e);

        public event BindingsChangedHandler OnBindingsChanged;

        public InputManager()
        {
            bindings = new Dictionary<char, Action>();
            bindingLookup = new Dictionary<KeyBinding, char>();

            Current = this;
        }

        public bool RegisterBinding(char key, KeyBinding binding, Action action)
        {
            key = char.ToUpper(key);

            if (bindings.ContainsKey(key)) { return false; }

            bindings.Add(key, action);
            bindingLookup.Add(binding, key);

            return true;
        }

        public void ReloadBindings()
        {
            KeyBinding[] b = new KeyBinding[bindingLookup.Count];

            bindingLookup.Keys.CopyTo(b, 0);

            foreach (var binding in b)
            {
                var newKey = (char)Properties.Settings.Default[binding.ToString()];

                if (bindingLookup[binding] == newKey) { continue; }

                bindings[newKey] = bindings[bindingLookup[binding]];
                bindings.Remove(bindingLookup[binding]);
                bindingLookup[binding] = newKey;
            }

            if (OnBindingsChanged != null) { OnBindingsChanged(this, new EventArgs()); }
        }

        public bool UpdateBinding(char oldKey, char newKey)
        {
            newKey = char.ToUpper(newKey);

            var binding = bindingLookup.Where(b => b.Value == oldKey).Select(b => b.Key).First();

            if (bindings.ContainsKey(newKey)) 
            {
                Properties.Settings.Default[binding.ToString()] = oldKey;
                return false; 
            }

            bindings[newKey] = bindings[oldKey];
            bindings.Remove(oldKey);
            bindingLookup[binding] = newKey;

            Properties.Settings.Default[binding.ToString()] = newKey;

            return true;
        }

        public bool HandleInput(object sender, KeyPressEventArgs e)
        {
            if (!FlummeryApplication.Active) { return true; }

            var key = char.ToUpper(e.KeyChar);

            if (bindings.ContainsKey(key))
            {
                bindings[key]();

                return true;
            }
            else
            {
                return false;
            }
        }

        public KeyboardShortcuts GetKeyboardShortcuts()
        {
            return new KeyboardShortcuts();
        }

        // From ViewportManager
        //public void UpdateKeyboardMovement()
        //{
        //    //if (!isMouseDown) { return; }

        //    var state = Keyboard.GetState();
        //    float dt = SceneManager.Current.DeltaTime;

        //    if (active.ProjectionMode == Projection.Orthographic)
        //    {
        //        if (state[Key.W]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
        //        if (state[Key.S]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

        //        if (state[Key.A]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
        //        if (state[Key.D]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }
        //    }
        //    else
        //    {
        //        if (state[Key.A]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
        //        if (state[Key.D]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }

        //        if (state[Key.W]) { active.Camera.MoveCamera(Camera.Direction.Forward, dt); }
        //        if (state[Key.S]) { active.Camera.MoveCamera(Camera.Direction.Backward, dt); }

        //        if (state[Key.Z]) { active.Camera.MoveCamera(Camera.Direction.Up, dt); }
        //        if (state[Key.X]) { active.Camera.MoveCamera(Camera.Direction.Down, dt); }

        //        if (state[Key.Q]) { active.Camera.Rotate(0, 0, -dt * 50); }
        //        if (state[Key.E]) { active.Camera.Rotate(0, 0, dt * 50); }

        //        if (state[Key.Keypad4]) { active.Camera.Rotate(dt, 0, 0); }
        //        if (state[Key.Keypad6]) { active.Camera.Rotate(-dt, 0, 0); }
        //        if (state[Key.Keypad2]) { active.Camera.Rotate(0, dt, 0); }
        //        if (state[Key.Keypad8]) { active.Camera.Rotate(0, -dt, 0); }
        //        if (state[Key.Keypad7]) { active.Camera.Rotate(0, 0, dt); }
        //        if (state[Key.Keypad9]) { active.Camera.Rotate(0, 0, -dt); }

        //        if (state[Key.Keypad1]) { active.Camera.MoveCamera(Camera.Direction.Left, dt); }
        //        if (state[Key.Keypad3]) { active.Camera.MoveCamera(Camera.Direction.Right, dt); }
        //    }
        //}
    }

    public class KeyboardShortcuts
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
