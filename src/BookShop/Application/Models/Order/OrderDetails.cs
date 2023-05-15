using BookShop.Infrastracture.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Models.Order
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public BookData Book { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Amount { get; set; }
        public OrderState State { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public BookData Book { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Amount { get; set; }
        public OrderState State { get; set; }
    }

    public class UserOrderItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? RatingScore { get; set; }
        public BookData Book { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Amount { get; set; }
        public OrderState State { get; set; }
    }

}
