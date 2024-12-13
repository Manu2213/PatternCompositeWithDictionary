using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Interfaces
{
    public interface IAluminumProfile : IItemComponent
    {
        double Length { get; set; }
    }
}
