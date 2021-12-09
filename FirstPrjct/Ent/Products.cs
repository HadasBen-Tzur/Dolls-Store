using System;
using System.Collections.Generic;

namespace Ent
{
    public partial class Products
    {
        public Products()
        {
            OrdersItem = new HashSet<OrdersItem>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? CategoryId { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<OrdersItem> OrdersItem { get; set; }
    }
}
