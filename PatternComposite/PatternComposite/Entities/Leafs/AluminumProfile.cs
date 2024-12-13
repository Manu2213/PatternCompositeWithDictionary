using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternComposite.Interfaces;
using static PatternComposite.Enums.TypeItemsEnums;

namespace PatternComposite.Entities.Leafs
{
    public class AluminumProfile : ItemLeaf, IAluminumProfile
    {
        public AluminumProfile(string name, string description, decimal unitPrice, decimal quantity, double length) :
            base(name, description, unitPrice, quantity)
        {
            Length = length;
        }

        public double Length { get; set ; }

        public override decimal Total()
        {
            return UnitPrice * Quantity * Convert.ToDecimal(Length);
        }
    }
}
