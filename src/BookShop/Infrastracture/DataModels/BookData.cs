﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastracture.DataModels
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<BookData> Books { get; set; }

    }
    public enum LanguageType
    {
        None=0,
        English=1,
        Farsi=2,
        Russian=3,
        Greek=4
    }
    public class BookData
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public BookCategory Category { get; set; }
        [MaxLength(50)]
        public string FileName { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public required string Description { get; set; }
        [MaxLength(250)]
        public required string Author { get; set; }
        public int Price { get; set; }
        public LanguageType Language { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        [MaxLength(1_000_000)]
        public byte[]? CoverImage { get; set; }

        //Be ezaye har ketab mitoone chandin rating dashte bashe
        public ICollection<RatingData> Ratings { get; set; }
    }
}
