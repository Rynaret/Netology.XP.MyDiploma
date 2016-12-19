using ShopService.Conventions;

namespace ShopService.Entities
{
    public class Product : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
    }
}