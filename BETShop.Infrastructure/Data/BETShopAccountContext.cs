using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BETShop.Infrastructure.Data
{
    public class BETShopAccountContext : IdentityDbContext<IdentityUser>
    {
        public BETShopAccountContext(DbContextOptions<BETShopAccountContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
