using CustomUserControl;
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
using DAL_BLL;
using System.Xml.Linq;

namespace DoAn_Winform
{
    public partial class FormMain : Form
    {
        private List<Category> typeList = new List<Category>();
        private Type_DAL_BLL type_DAL = new Type_DAL_BLL();
        private Product_DAL_BLL Product_DAL = new Product_DAL_BLL();
        private Order_DAL_BLL order_DAL = new Order_DAL_BLL();
        private OrderDetail_DAL_BLL orderDetail_DAL_BLL=new OrderDetail_DAL_BLL();
        private List<Product> productList = new List<Product>();
        private List<OrderItem> lstOrder_detail = new List<OrderItem> ();
        string nameProduct;
        private List<OrderItem> detail = new List<OrderItem>();
        private Order orderNow=new Order();
        TypeControl selected;
        OrderDetailControl orderDetailControlSelected;
        string nameOD;
        string sizeOD;
        int idUser;

        

        public object Products_DAL { get; private set; }

        public FormMain(int id)
        {
            InitializeComponent();
            this.idUser = id;
            typeList = type_DAL.getAllTypes();
            productList = Product_DAL.getListProducts();
            orderNow = order_DAL.createAndGetNewOrder(id);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int y = 0;
            for (int i = 0; i < typeList.Count; i++)
            {
                TypeControl typeControl = new TypeControl(typeList[i]);
                typeControl.Location = new Point(20, y);
                y += 60;
                typeControl.Size = new Size(100, 50);
                panelType.Controls.Add(typeControl);
                typeControl.Click += TypeControl_Click;
            }

            loadProduct(productList);
            OrderDetailControl orderDetailControl = new OrderDetailControl();
            orderDetailControl.Location = new Point(0, 0);
            panel1.Controls.Add(orderDetailControl);
            orderDetailControl.BackColor = Color.White;
            OrderItem p = new OrderItem();
        }

        private void TypeControl_Click(object sender, EventArgs e)
        {
            TypeControl chooseTypeUser = (TypeControl)sender;
            if (selected != null)
            {
                selected.BorderStyle = BorderStyle.None;
            }
            selected = chooseTypeUser;
            selected.BorderStyle = BorderStyle.FixedSingle;

            int typeId = chooseTypeUser.TypeId;
            List<Product> productByTypes = Product_DAL.getListProductByType(typeId);
            loadProduct(productByTypes);
        }

        private void loadProduct(List<Product> products)
        {
            panelProduct.Controls.Clear();
            int top = 0, left = 0;
            for (int i = 0; i < products.Count; i++)
            {
                ProductControl productControl = new ProductControl(products[i]);
                productControl.setData(i + 1);
                productControl.Left = left;
                productControl.Top = top;
                productControl.Padding = new Padding(4);
                left += 180;
                productControl.Size = new Size(170, 200);
                if ((i + 1) % 4 == 0)
                {
                    top += 200; left = 0;
                }
                productControl.btnSizeS.Click += btnSizeS_Click;
                productControl.btnSizeM.Click += BtnSizeM_Click;
                productControl.btnSizeL.Click += BtnSizeL_Click;
                panelProduct.Controls.Add(productControl);
            }
        }

        private void BtnSizeL_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = int.Parse(btn.Name);
            AddProductToOrder(productId, "L");
        }

        private void BtnSizeM_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = int.Parse(btn.Name);
            AddProductToOrder(productId, "M");
        }

        private void btnSizeS_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = int.Parse(btn.Name);
            AddProductToOrder(productId, "S");
        }

        private void AddProductToOrder(int productId, string size)
        {
            
            Product p = Product_DAL.getProductById(productId);
            OrderItem o_D = lstOrder_detail.FirstOrDefault(od => od.ProductId == productId && od.Size == size);
           
            if (o_D != null)
            {
                o_D.Quantity += 1;
            }
            else
            {
                OrderItem newO_d = new OrderItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    Price = p.Price,
                    Size = size,
                    Product = p
                };
                lstOrder_detail.Add(newO_d);
                
                
            }
            nameProduct = p.Name;
            loadOrderDetail(lstOrder_detail);
        }

      
        private void OrderDetailControl_Click(object sender, EventArgs e)
        {
            OrderDetailControl chooseOrderDetail = (OrderDetailControl)sender;
            if (orderDetailControlSelected != null)
            {
                orderDetailControlSelected.BackColor = Color.White;
            }
            orderDetailControlSelected = chooseOrderDetail;
            orderDetailControlSelected.BackColor = Color.DarkGray;
            nameOD = chooseOrderDetail.nameProduct;
            sizeOD = chooseOrderDetail.sizeP;
        }

        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            Product p = Product_DAL.getProductByName(nameOD);
            OrderItem o_D = lstOrder_detail.FirstOrDefault(od => od.ProductId == p.ProductId && od.Size == sizeOD);

            if (o_D != null)
            {
                o_D.Quantity += 1;
            }
            loadOrderDetail(lstOrder_detail);
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            Product p = Product_DAL.getProductByName(nameOD);
            OrderItem o_D = lstOrder_detail.FirstOrDefault(od => od.ProductId == p.ProductId && od.Size == sizeOD);
            if (o_D.Quantity >= 1)
            {
                if (o_D != null)
                {
                    o_D.Quantity -= 1;
                }
                loadOrderDetail(lstOrder_detail);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = Product_DAL.getProductByName(nameOD);
            OrderItem o_D = lstOrder_detail.FirstOrDefault(od => od.ProductId == p.ProductId && od.Size == sizeOD);
            lstOrder_detail.Remove(o_D);
            loadOrderDetail(lstOrder_detail);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var existingOrder = order_DAL.getOrderById((int)orderNow.OrderId).FirstOrDefault();
            if (lstOrder_detail.Count > 0)
            {
                if (existingOrder != null)
                {
                    orderNow = order_DAL.createAndGetNewOrder(idUser);
                }
                orderNow.TotalAmount = double.Parse(txtTotalPrice.Text);
                orderNow.OrderDate = DateTime.Now;
                order_DAL.updateUserInOrder(idUser, orderNow);

                foreach (var detail in lstOrder_detail)
                {
                    detail.OrderId = orderNow.OrderId;
                    double basePrice = (double)detail.Price;
                    if (detail.Size == "S")
                    {
                        detail.Price = basePrice;
                    }
                    else if (detail.Size == "M")
                    {
                        detail.Price = basePrice + 4000;
                    }
                    else if (detail.Size == "L")
                    {
                        detail.Price = basePrice + 10000;
                    }
                    order_DAL.saveOrderDetail(detail);
                }

                MessageBox.Show("Đơn hàng đã được thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstOrder_detail.Clear();
                loadOrderDetail(lstOrder_detail);
                int userId = idUser;
                List<Order> userOrders = order_DAL.getOrderById(userId);
                DataTable dt = setDataTable(userOrders);
              //  dataGridViewBills.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadOrderDetail(List<OrderItem> lstOrder_detail)
        {
            panel4.Controls.Clear();
            int top = 0;
            double totalPrice = 0;
            foreach (OrderItem item in lstOrder_detail)
            {
                OrderDetailControl orderDetailControl = new OrderDetailControl();
                double price;
                if (item.Size == "S")
                    price = (double)item.Price;
                else if (item.Size == "M")
                    price = (double)(item.Price + 10000);
                else
                    price = (double)(item.Price + 15000);
                orderDetailControl.setData(item.Quantity.ToString(),nameProduct, price.ToString(), item.Size);
                orderDetailControl.Size = new Size(300, 60);
                orderDetailControl.Top = top;
                top += 70;
                totalPrice += (price * item.Quantity);
                panel4.Controls.Add(orderDetailControl);
                orderDetailControl.Click += OrderDetailControl_Click;
            }
            txtTotalPrice.Text = totalPrice.ToString();
        }

        public DataTable setDataTable(List<Order> orders)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomName");
            dt.Columns.Add("TotalAmount", typeof(double));
            dt.Columns.Add("OrderDate", typeof(DateTime));

            foreach (var order in orders)
            {
                if(order.TotalAmount > 0)
                {
                    DataRow row = dt.NewRow();
                    row["CustomName"] = order.User.FullName;
                    row["TotalAmount"] = order.TotalAmount;
                    row["OrderDate"] = order.OrderDate != null ? (object)order.OrderDate : DBNull.Value;
                    dt.Rows.Add(row);
                }                
            }
            return dt;
        }

        private void panelType_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
