using IceCreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
        public List<IceCream> IceCreams { get; set; }
        private DataListSingleton()
        {
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
            IceCreams = new List<IceCream>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
