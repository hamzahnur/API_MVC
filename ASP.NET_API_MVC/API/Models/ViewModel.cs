using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string NameItem { get; set; }
        public int Quantity { get; set; }
        public string price { get; set; }
        public string NameSupplier { get; set; }
    }
}