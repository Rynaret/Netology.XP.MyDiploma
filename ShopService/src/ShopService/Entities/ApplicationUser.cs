using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShopService.Conventions;

namespace ShopService.Entities
{
    public class ApplicationUser : IdentityUser<long>, IEntity
    {
    }
}