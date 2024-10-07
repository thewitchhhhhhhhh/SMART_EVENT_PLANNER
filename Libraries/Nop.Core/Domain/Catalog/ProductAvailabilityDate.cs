using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductAvailabilityDate : BaseEntity, ISoftDeletedEntity
    {
        public int ProductId { get; set; }
        public DateTime AvailableDate { get; set; }
        public bool IsBooked { get; set; }
        public bool Deleted { get; set; }
        public int Price { get; set; }
    }
}
