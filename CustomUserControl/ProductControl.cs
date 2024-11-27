using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Reflection.Emit;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
namespace CustomUserControl
{
    public partial class ProductControl: UserControl
    {
        public int productID { get; set; }
        public Button btnSizeS { get { return this.btnS; } }
        public Button btnSizeM {  get { return this.btnM; } }
        public Button btnSizeL {  get { return this.btnL; } }
        public void setData(int id)
        {
            btnS.Name = id.ToString();
            btnM.Name = id.ToString();
            btnL.Name = id.ToString();
        }
        public ProductControl(Product product)
        {
            InitializeComponent();
            string imagePath = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg";

            try
            {
              
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imagePath);

                   
                    using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(memoryStream);
                        photoProduct.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Có lỗi khi tải ảnh: " + ex.Message);
            }
            productID = (int)product.ProductId;
            lblNameProduct.Text = product.Name;

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnS_Click(object sender, EventArgs e)
        {

        }
    }
}
