﻿using BookShop.Application.Models.Order;
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

        public IList<OrderItem> GetAll()
        {
            var orderList = _db.Orders
                .Include(o => o.User)
                .Include(o => o.Book)
                //.ThenInclude(o => o.Category)
                .ProjectToType<OrderItem>().ToList();
            return orderList;
        }

        public IList<UserOrderItem> GetAllByUser(string userId)
        {
            var orderList = _db.Orders
                .Include(o => o.User)
                .Include(o => o.Book)
                .Include(o=>o.Rating)
                .Where(o=>o.UserId==userId && o.State==OrderState.Confirmed)
                .ProjectToType<UserOrderItem>().ToList();
            return orderList;
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

        public OrderDetails GetUserBook(string userId, int bookId)
        {
            var order = _db.Orders
                .Include(o => o.User)
                .Include(o => o.Book)
                .ThenInclude(o => o.Category)
                .FirstOrDefault(o => o.UserId == userId && o.BookId==bookId && o.State==OrderState.Confirmed);
            return order.Adapt<OrderDetails>();
        }

        public void AddRating(int orderId, int score)
        {
            var order = _db.Orders.Find(orderId);
            order.Rating = new RatingData
            {
                BookId = order.BookId,
                OrderId = orderId,
                TimeCreated = DateTime.Now,
                Score = (RatingScore)score
            };
            _db.SaveChanges();
        }
    }
}
