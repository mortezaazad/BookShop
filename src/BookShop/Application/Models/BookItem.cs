﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Models;

public class BookItem
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Price { get; init; }
    public string Language { get; set; }
    public string CategoryName { get; set; }
    public byte[]? CoverImage { get; set; }

}
