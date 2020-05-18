using System;
using System.Collections.Generic;
using System.Text;

namespace JustPrice
{
    public class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public Items()
        {

        }

        public Items(string name, string description, int price, int minPrice, int maxPrice)
        {
            Name = name;
            Description = description;
            Price = price;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}
