using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ent
{
    public partial class OrdersItem
    {
        public int OrderItemId { get; set; }
        public short? ProductId { get; set; }
        public int? OrderId { get; set; }
        public short? Quentity { get; set; }
        [JsonIgnore]
        public virtual Orders Order { get; set; }
        [JsonIgnore]
        public virtual Products Product { get; set; }
    }
}
