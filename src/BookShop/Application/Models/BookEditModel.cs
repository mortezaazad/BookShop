﻿using BookShop.Infrastracture.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Models
{
    public class BookEditModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int CategoryId { get; set; }
        public LanguageType Language{ get; init; }
    }
}