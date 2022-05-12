using API_REST_SQLSERVER.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_REST_SQLSERVER.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 
        }

        public DbSet<usuario> usuario { get; set; }
    }
}
