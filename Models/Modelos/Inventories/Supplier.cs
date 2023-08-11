using Models.Modelos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Modelos.Inventories 
{
    public class Supplier : Address
    {
        public Guid Id { get; set; }
        public string CorporateName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Able { get; set; } = true;
    }
}
