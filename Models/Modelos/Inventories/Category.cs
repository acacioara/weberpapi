using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Modelos.Inventories
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Able { get; set; }


        public Category()
        {
            Id = Guid.NewGuid();
        }
    }
}
