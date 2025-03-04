
using Microsoft.EntityFrameworkCore;
using BTL_NMCNPM.Models;

namespace BTL_NMCNPM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
    }

    
}
