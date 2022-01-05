﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShoppingMall.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int ProductID { get; set; }
    }
}