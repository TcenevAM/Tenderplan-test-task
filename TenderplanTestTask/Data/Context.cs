using Microsoft.EntityFrameworkCore;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}