using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Interfaces
{
    public interface IAssembly : IItemComponent
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
