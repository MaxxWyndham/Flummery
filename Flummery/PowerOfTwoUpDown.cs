using System;
using System.Windows.Forms;

using ToxicRagers.Helpers;

namespace Flummery.Controls
{
    public partial class PowerOfTwoUpDown : UpDownBase, System.ComponentModel.ISupportInitialize
    {
        int value;

        public event EventHandler ValueChanged;

        public int Value
        {
            get { return value; }
            set 
            { 
                this.value = value;

                UpdateEditText();
            }
        }

        public override void UpButton()
        {
            value = (value == 0 ? 1 : value * 2);

            UpdateEditText();
        }

        public override void DownButton()
        {
            value /= 2;

            UpdateEditText();
        }

        protected override void UpdateEditText()
        {
            this.Text = value.ToString();

            if (ValueChanged != null) { ValueChanged(this, new EventArgs()); }
        }

        public void BeginInit()
        {
            this.Text = value.ToString();
        }

        public void EndInit()
        {
        }
    }
}
