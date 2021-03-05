using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Flummery.Core
{
    public class InputAction
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public Action Action { get; set; }
    }

    public class InputManager
    {
        public List<InputAction> RegisteredActions { get; } = new List<InputAction>();

        public Dictionary<char, Action> Bindings { get; } = new Dictionary<char, Action>();

        public static InputManager Current { get; private set; }

        public delegate void BindingsChangedHandler(object sender, EventArgs e);

        public event BindingsChangedHandler OnBindingsChanged;

        public InputManager()
        {
            Current = this;
        }

        public bool RegisterInputAction(Action action, string name, string description, string category)
        {
            if (RegisteredActions.Any(ia => ia.Name == name)) { return false; }

            RegisteredActions.Add(new InputAction
            {
                Name = name,
                Description = description,
                Category = category,
                Action = action
            });

            return true;
        }

        public void ReloadBindings()
        {
            // loop registered binding actions, fetch key from settings

            OnBindingsChanged?.Invoke(this, new EventArgs());
        }

        public bool UpdateBinding(char oldKey, char newKey)
        {
            // find action bound to old key, check if new key isn't being used, bind old action to new key

            return true;
        }

        //public bool HandleInput(object sender, KeyPressEventArgs e)
        //{
        //    if (!FlummeryApplication.Active) { return true; }

        //    char key = char.ToUpper(e.KeyChar);

        //    if (Bindings.ContainsKey(key))
        //    {
        //        Bindings[key]();

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

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

    [Flags]
    public enum MouseButtons
    {
        None = 0,
        Left = 1048576,
        Right = 2097152,
        Middle = 4194304
    }

    public class MouseEvent
    {
        public MouseButtons Button { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
