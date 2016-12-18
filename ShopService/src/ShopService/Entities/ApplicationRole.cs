using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShopService.Conventions;

namespace ShopService.Entities
{
    public class ApplicationRole : IdentityRole<long>, IEntity
    {
    }
}