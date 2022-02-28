using System;
using System.Collections.Generic;

#nullable disable

namespace Medco_backend.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Uid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public long? Mobileno { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
