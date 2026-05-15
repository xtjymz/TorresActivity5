using Microsoft.EntityFrameworkCore;
using TorresActivity5.Models.Entities;

namespace TorresActivity5.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       public DbSet<Student> Students { get; set; }
    }
}
