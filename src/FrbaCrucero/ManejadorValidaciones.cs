using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FrbaCrucero
{
    public class ManejadorValidaciones
    {
        private ErrorProvider errProvider;
        private Dictionary<string, string> dicMsjError;

        /// <summary>
        /// Constructor: Inicializa el objecto.
        /// </summary>
        /// <param name="paramErrorProvider"></param>
        public ManejadorValidaciones(ErrorProvider paramErrorProvider)
        {
            dicMsjError = new Dictionary<string, string>();
            errProvider = paramErrorProvider;
        }

        public void CrearValidacionesCheckListBox(ref CheckedListBox chkLst, string paramMsjError)
        {
            dicMsjError.Add(chkLst.Name, paramMsjError);
            chkLst.Validating += new CancelEventHandler(chkLst_Validating);
            chkLst.Validated += new EventHandler(chkLst_Validated);
        }

        void chkLst_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((CheckedListBox)sender), "");
        }

        void chkLst_Validating(object sender, CancelEventArgs e)
        {
            CheckedListBox miLst = (CheckedListBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miLst.Name).Value;

            if (miLst.CheckedItems.Count == 0)
            {
                e.Cancel = true;
                miLst.Focus();
                this.errProvider.SetError(miLst, msjError);
            }
        }

        public void CrearValidacionesListBox(ref ListBox lst, string paramMsjError)
        {
            dicMsjError.Add(lst.Name, paramMsjError);
            lst.Validating += new CancelEventHandler(lst_Validating);
            lst.Validated += new EventHandler(lst_Validated);
        }

        void lst_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((ListBox)sender), "");
        }

        void lst_Validating(object sender, CancelEventArgs e)
        {
            ListBox miLst = (ListBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miLst.Name).Value;

            if (miLst == null || miLst.Items.Count == 0)
            {
                e.Cancel = true;
                miLst.Focus();
                this.errProvider.SetError(miLst, msjError);
            }
        }

        public void CrearValidacionesComboBox(ref ComboBox cmb, string paramMsjError)
        {
            dicMsjError.Add(cmb.Name, paramMsjError);
            cmb.Validating += new CancelEventHandler(cmb_Validating);
            cmb.Validated += new EventHandler(cmb_Validated);
        }

        public void CrearValidacionesComboBoxInt64(ref ComboBox cmbInt64, string paramMsjError)
        {
            dicMsjError.Add(cmbInt64.Name, paramMsjError);
            cmbInt64.Validating += new CancelEventHandler(cmbInt64_Validating);
            cmbInt64.Validated += new EventHandler(cmbInt64_Validated);
        }

        void cmbInt64_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((ComboBox)sender), "");
        }

        void cmbInt64_Validating(object sender, CancelEventArgs e)
        {
            ComboBox miCmb = (ComboBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miCmb.Name).Value;
            if (Convert.ToInt64(miCmb.SelectedValue) < 0)
            {
                e.Cancel = true;
                miCmb.Select(0, miCmb.Text.Length);
                this.errProvider.SetError(miCmb, msjError);
            }
        }

        void cmb_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((ComboBox)sender), "");
        }

        void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox miCmb = (ComboBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miCmb.Name).Value;
            if (Convert.ToInt32(miCmb.SelectedValue) < 0)
            {
                e.Cancel = true;
                miCmb.Select(0, miCmb.Text.Length);
                this.errProvider.SetError(miCmb, msjError);
            }
        }

        public void CrearValidacionesTextBox(ref TextBox txt, string paramMsjError)
        {
            dicMsjError.Add(txt.Name, paramMsjError);
            txt.Validating += new System.ComponentModel.CancelEventHandler(this.Textbox_Validating);
            txt.Validated += new EventHandler(Textbox_Validated);
        }

        public void CrearValidacionesTextBoxEmail(ref TextBox txtMail, string paramMsjError)
        {
            dicMsjError.Add(txtMail.Name, paramMsjError);
            txtMail.Validating += new CancelEventHandler(txtMail_Validating);
            txtMail.Validated += new EventHandler(txtMail_Validated);
        }

        void txtMail_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((TextBox)sender), "");
        }

        void txtMail_Validating(object sender, CancelEventArgs e)
        {
            TextBox miTxt = (TextBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miTxt.Name).Value;
            if (!esEmailValido(miTxt.Text))
            {
                e.Cancel = true;
                miTxt.Select(0, miTxt.Text.Length);
                this.errProvider.SetError(miTxt, msjError);
            }
        }

        private void Textbox_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((TextBox)sender), "");
        }

        private void Textbox_Validating(object sender, CancelEventArgs e)
        {
            TextBox miTxt = (TextBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miTxt.Name).Value;
            if (string.IsNullOrEmpty(miTxt.Text))
            {
                e.Cancel = true;
                miTxt.Select(0, miTxt.Text.Length);
                this.errProvider.SetError(miTxt, msjError);
            }
        }

        public void CrearValidacionesNumericTextBox(ref NumericTextBox numText, string paramMsjError)
        {
            dicMsjError.Add(numText.Name, paramMsjError);
            numText.Validating += new CancelEventHandler(numText_Validating);
            numText.Validated += new EventHandler(numText_Validated);
        }

        void numText_Validated(object sender, EventArgs e)
        {
            this.errProvider.SetError(((NumericTextBox)sender), "");
        }

        void numText_Validating(object sender, CancelEventArgs e)
        {
            NumericTextBox miTxt = (NumericTextBox)sender;
            string msjError = dicMsjError.First(item => item.Key == miTxt.Name).Value;
            if (string.IsNullOrEmpty(miTxt.Text))
            {
                e.Cancel = true;
                miTxt.Select(0, miTxt.Text.Length);
                this.errProvider.SetError(miTxt, msjError);
            }
        }

        public bool esEmailValido(string mail)
        {
            Regex patronEmail = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase);
            return (!string.IsNullOrEmpty(mail) && patronEmail.IsMatch(mail));
        }
    }
}
