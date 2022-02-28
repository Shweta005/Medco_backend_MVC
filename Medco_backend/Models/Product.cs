using System;
using System.Collections.Generic;

#nullable disable

namespace Medco_backend.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string Imgurl { get; set; }
        public string Productname { get; set; }
        public string Productdesc { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public int? Catid { get; set; }
        public string Mfgname { get; set; }
        public string Catname { get; set; }
    }
}
