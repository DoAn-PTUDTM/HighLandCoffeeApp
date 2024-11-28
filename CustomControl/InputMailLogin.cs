using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace CustomControl
{
    public class InputMailLogin : TextBox
    {
        
        ErrorProvider error = new ErrorProvider();
        string mailLogin = "";
        public InputMailLogin() {
            this.KeyPress += InputMailLogin_KeyPress;
        }

        private void InputMailLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            error.SetError(this, "Invalid Email");
            mailLogin += e.KeyChar;
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if(e.KeyChar=='\b' && mailLogin.Length >= 2)
            {
                mailLogin = mailLogin.Substring(0, mailLogin.Length - 2);
            }
            if (reg.IsMatch(mailLogin))
            {
                error.SetError(this, "");
                error.Clear();
            }
        }
    }
}
