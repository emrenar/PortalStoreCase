

namespace PortalStoreCase.Entities.Entities
{
    public class SKU:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal OldPrice { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
