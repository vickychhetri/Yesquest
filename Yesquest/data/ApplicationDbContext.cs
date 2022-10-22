using Microsoft.EntityFrameworkCore;
using Yesquest.Models;

namespace Yesquest.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<ItemCategorytable> ItemCategorytable { get; set; }
        public DbSet<Itemtable> Itemtable { get; set; }

    }
}
