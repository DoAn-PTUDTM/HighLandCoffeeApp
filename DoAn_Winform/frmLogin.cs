using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;

namespace DoAn_Winform
{
    public partial class btnShow : Form
    {
        User_DAL_BLL user = new User_DAL_BLL();
        public btnShow()
        {
            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtMail.Text=="" || txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            if(user.checkLogin(txtMail.Text, txtPass.Text))
            {
                
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                FormMain formMain = new FormMain(user.getUserByEmail(txtMail.Text));
                formMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại mật khẩu hoặc email");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }
    }
}
