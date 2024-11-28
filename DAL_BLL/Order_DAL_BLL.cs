using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_BLL
{
    public class Order_DAL_BLL
    {
        HighlandCoffeeDataContext hl = new HighlandCoffeeDataContext();
        public Order_DAL_BLL() { }
        public List<Order> getAllOrder()
        {
            return hl.Orders.ToList<Order>();
        }
        public List<Order> getOrderById(int id)
        {
            return hl.Orders.Where(t => t.UserId == id).ToList<Order>();
        }

        public Order createAndGetNewOrder(int idUser)
        {
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Now;
            newOrder.UserId = idUser;
            newOrder.TotalAmount = 0;
            hl.Orders.InsertOnSubmit(newOrder);
            hl.SubmitChanges();
            return newOrder;

        }
        public void deleteOrder(Order order)
        {
            hl.Orders.DeleteOnSubmit(order);
            hl.SubmitChanges();
        }
        public void updateUserInOrder(int idUser, Order order)
        {
            Order temp = hl.Orders.Where(t => t.OrderId == order.OrderId).FirstOrDefault();
            temp.UserId = idUser;
            hl.SubmitChanges();
        }
        public void saveOrderDetail(OrderItem detail)
        {
            hl.OrderItems.InsertOnSubmit(detail);
            hl.SubmitChanges();
        }


    }

}
