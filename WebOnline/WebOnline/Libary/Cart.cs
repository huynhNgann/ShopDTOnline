using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebOnline.Models;
namespace WebOnline.Libary
{
    public class CartItem
    {
        public sanPham shopping_product { get; set; }
        public int shopping_quantity { get; set; }
             }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
       
    }
}