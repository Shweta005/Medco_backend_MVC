using System;
using System.Collections.Generic;

#nullable disable

namespace Medco_backend.Models
{
    public partial class Coupen
    {
        public int Cid { get; set; }
        public string Coupencode { get; set; }
        public string Coupenname { get; set; }
        public int? Appliesto { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Expirydate { get; set; }
        public DateTime? Closeddate { get; set; }
        public bool? Availability { get; set; }
        public int? Discount { get; set; }

        public virtual Category AppliestoNavigation { get; set; }
    }
}
