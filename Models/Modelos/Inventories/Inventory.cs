using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Modelos.Inventories
{
    public class Inventory
    {
        private decimal _salePrice = 0;
        public Guid Id { get; set; }

        // campos do produto - inicio
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal ProfitPercentage { get; set; }
        public decimal SalePrice { get => _salePrice; set => _salePrice =  CostPrice * (1 + (ProfitPercentage / 100)) ; }
        public bool Able { get; set; }
        // campos do produto - fim

        public Guid IdSupplier { get; set; }
        [JsonIgnore]
        public virtual Supplier Suppliers { get; set; }
        public Guid IdCategory{ get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public Guid IdUnitType { get; set; }
        [JsonIgnore]
        public virtual UnitType UnitType { get; set; }


        public Inventory()
        {
            Id = Guid.NewGuid();
            IdSupplier = Guid.Empty;
            IdCategory = Guid.Empty;
            IdUnitType = Guid.Empty;
        }
    }
}
