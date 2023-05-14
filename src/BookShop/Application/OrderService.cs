using BookShop.Application.Models.Order;
using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Models
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public OrderDetails Get(int orderId)
        {
            var order = _db.Orders
                .Include(o=>o.User)
                .Include(o=>o.Book)
                .ThenInclude(o=>o.Category)
                .First(o=>o.Id== orderId);
            return order.Adapt<OrderDetails>();
        }
        public int Create(OrderCreateModel model)
        {
            var order = model.Adapt<OrderData>();
            order.TimeCreated = DateTime.Now;
            order.State = OrderState.New;
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order.Id;
        }

        public void Confirm(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            if (order.State ==OrderState.New) 
            {
                order.State = OrderState.Confirmed;
            }
            _db.SaveChanges();
        }
    }
}
