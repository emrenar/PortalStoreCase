

namespace PortalStoreCase.Entities.Entities
{
    public class OrderItem : BaseEntity
    {
        public int SkuId { get; set; }
        public SKU SKU { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
