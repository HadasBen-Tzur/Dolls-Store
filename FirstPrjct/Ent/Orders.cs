using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ent
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersItem = new HashSet<OrdersItem>();
        }

        public int OrderId { get; set; }
        public string OrderSum { get; set; }
        public short? UserId { get; set; }
        public string OrderDate { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
        public virtual ICollection<OrdersItem> OrdersItem { get; set; }
    }
}
