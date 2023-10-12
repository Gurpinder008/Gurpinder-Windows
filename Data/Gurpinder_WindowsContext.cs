using Microsoft.EntityFrameworkCore;
using Gurpinder_Windows.Models;

namespace Gurpinder_Windows.Data
{
    public class Gurpinder_WindowsContext : DbContext
    {
        public Gurpinder_WindowsContext(DbContextOptions<Gurpinder_WindowsContext> options)
            : base(options)
        {
        }

        public DbSet<Window> Window { get; set; }
    }
}
