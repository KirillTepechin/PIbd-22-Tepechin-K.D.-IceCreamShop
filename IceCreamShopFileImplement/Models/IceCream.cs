﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopFileImplement.Models
{
    public class IceCream
    {
        public int Id { get; set; }
        public string IceCreamName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> IceCreamIngredients { get; set; }
    }
}