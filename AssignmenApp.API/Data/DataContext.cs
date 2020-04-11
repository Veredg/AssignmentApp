using Microsoft.EntityFrameworkCore;
using AssignmenApp.API.Entities;

namespace AssignmenApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<User> Users{ get; set; }
        public DbSet<MyTask> Tasks { get; set; }
    }
}