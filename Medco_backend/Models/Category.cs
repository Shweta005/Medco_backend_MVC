using System;
using System.Collections.Generic;

#nullable disable

namespace Medco_backend.Models
{
    public partial class Category
    {
        public Category()
        {
            Coupens = new HashSet<Coupen>();
        }

        public int Catid { get; set; }
        public string Catname { get; set; }

        public virtual ICollection<Coupen> Coupens { get; set; }
    }
}
