using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace CustomUserControl
{
    public partial class TypeControl : UserControl
    {
        public int TypeId {  get; set; }
        public TypeControl(Category type)
        {
            InitializeComponent();
            lblNameType.Text = type.Name;
            TypeId = (int)type.CategoryId;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TypeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
