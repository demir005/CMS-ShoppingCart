using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSShoppingCard.Models.ViewModels.Account
{
    public class OrdersForUserVM
    {
        public int OrderNumber { get; set; }
        public string Username { get; set; }
       
        public Dictionary<string, int> ProductAndQty { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; internal set; }
    }
}