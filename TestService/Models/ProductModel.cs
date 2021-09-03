using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TestService.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public string Brand { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceLine { get; set; }
        public string Status { get; set; }
        public string ImageDetail { get; set; }
        public int TotalRows { get; set; }
    }

}