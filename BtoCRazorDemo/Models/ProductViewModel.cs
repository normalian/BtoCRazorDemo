using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtoCRazorDemo.Models
{
    public class ProductViewModel
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ImageFileUrl { get; set; }

        public int Qty { get; set; }
    }
}