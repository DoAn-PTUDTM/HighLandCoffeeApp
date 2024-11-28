using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomUserControl
{
    public partial class OrderDetailControl : UserControl
    {
        public string nameProduct { get; set; }
        public string sizeP {  get; set; }
        public OrderDetailControl()
        {
            InitializeComponent();           
        }

        private void OrderDetailControl_Load(object sender, EventArgs e)
        {

        }
        public void setData(string quantity, string name, string price, string size)
        {
            labelName.Text = name;
            labelPrice.Text = price;
            labelQuantity.Text = quantity;
            labelSize.Text = size;
            this.nameProduct = name;
            this.sizeP = size;
        }
    }
}
