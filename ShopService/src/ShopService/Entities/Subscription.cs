using System.Collections.Generic;
using ShopService.Conventions;

namespace ShopService.Entities
{
    public class Subscription : IEntity
    {
        public long Id { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}