using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public class NumericTextBox : TextBox
    {
        public TextBox ObtenerTextBox()
        {
            return (TextBox)Parent;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // Check if the pressed character was a backspace or numeric.
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}