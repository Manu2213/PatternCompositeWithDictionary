using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternComposite.Interfaces;

namespace PatternComposite.Entities
{
    public class ItemLeaf : IItemComponent
    {
        public ItemLeaf(string name, string description, decimal unitPrice, decimal quantity)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        public virtual decimal Total()
        {
            return UnitPrice * Quantity;
        }

        public void UpdateUnitPrice()
        {
            UnitPrice = UnitPrice;
        }
    }
}
