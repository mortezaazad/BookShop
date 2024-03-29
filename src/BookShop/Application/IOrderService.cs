﻿using BookShop.Application.Models.Order;

namespace BookShop.Application.Models
{
    public interface IOrderService
    {
        void AddRating(int orderId, int score);
        void Confirm(int orderId);
        int Create(OrderCreateModel model);
        OrderDetails Get(int orderId);
        IList<OrderItem> GetAll();
        IList<UserOrderItem> GetAllByUser(string userId);
        OrderDetails GetUserBook(string userId, int bookId);
    }
}