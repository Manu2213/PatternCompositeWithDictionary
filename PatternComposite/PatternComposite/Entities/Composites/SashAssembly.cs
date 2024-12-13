using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternComposite.Interfaces;
using static PatternComposite.Enums.TypeItemsEnums;

namespace PatternComposite.Entities.Composites
{
    public class SashAssembly:ItemComposite, IAssembly
    {
        public SashAssembly(string name, string description, decimal quantity, Dictionary<TypeItem, List<IItemComponent>>? items,
            double width, double height) :base(name, description, quantity, items)
        {
            Width = width;
            Height = height;
        }

        public SashAssembly(string name, string description, decimal quantity, double width, double height) : this(name, description, quantity, null, width, height) { }
        public SashAssembly(string name, string description, double width, double height) :this(name, description, 1, null, width, height){ }

        public double Height { get; set; }
        public double Width { get; set; }
    }
}
