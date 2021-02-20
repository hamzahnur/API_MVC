using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_API_MVC.Models
{
    public class ViewModelItem
    {
        public List<Supplier> suppliers { get; set; }
        public List<Item> items { get; set; }
       

        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }
        public string price { get; set; }

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

    }
}