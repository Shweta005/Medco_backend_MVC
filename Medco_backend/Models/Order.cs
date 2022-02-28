using System;
using System.Collections.Generic;

#nullable disable

namespace Medco_backend.Models
{
    public partial class Order
    {
        public int Oid { get; set; }
        public int[] Pid { get; set; }
        public int? Uid { get; set; }
        public int? Totalprice { get; set; }
        public int? Quantity { get; set; }
        public string Address { get; set; }
        public DateTime? Ordereddate { get; set; }
        public DateTime? Deliverydate { get; set; }
        public string Coupen { get; set; }
        public string Orderstatus { get; set; }

        public virtual User UidNavigation { get; set; }
    }
}
