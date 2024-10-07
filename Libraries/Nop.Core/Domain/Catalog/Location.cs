using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Catalog
{
    public partial class Location : BaseEntity
    {
        public string Name { get; set; }
    }
    public partial class FoodType : BaseEntity
    {
        public string Type { get; set; }
    }
}
