using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_BLL
{
    public class OrderDetail_DAL_BLL
    {
        HighlandCoffeeDataContext hl = new HighlandCoffeeDataContext();
        public OrderDetail_DAL_BLL() { }

        public List<OrderItem> getAllOrderDetailByIdOrder(int idOrder)
        {
            return hl.OrderItems.Where(t => t.OrderId == idOrder).ToList();
        }

        public void insertOrderDetail(int quantity, int idProduct, int idOrder)
        {
            OrderItem detail = new OrderItem();
            detail.Quantity = quantity;
            detail.ProductId = idProduct;
            detail.OrderId = idOrder;
            detail.Price = quantity * hl.Products.Where(t => t.ProductId == idProduct).FirstOrDefault().Price;
            hl.OrderItems.InsertOnSubmit(detail);
            hl.SubmitChanges();
        }

        public void updateQuantityOrderDetail(int quantity, int idOrderDetail)
        {
            OrderItem detail = hl.OrderItems.Where(t => t.OrderItemId == idOrderDetail).FirstOrDefault();
            if (detail != null)
            {
                detail.Price = detail.Price / detail.Quantity * quantity;
                detail.Quantity = quantity;
                hl.SubmitChanges();
            }
        }

        public void deleteOrderDetail(int idOrderDetail)
        {
            OrderItem detail = hl.OrderItems.Where(t => t.OrderItemId == idOrderDetail).FirstOrDefault();
            if (detail != null)
            {
                hl.OrderItems.DeleteOnSubmit(detail);
                hl.SubmitChanges();
            }
        }
    }
}
