using Microsoft.EntityFrameworkCore;
using ZenDerivco.Models;

namespace ZenDerivco
{
    public class ZenDerivcoContext:DbContext
    {

        public ZenDerivcoContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}
