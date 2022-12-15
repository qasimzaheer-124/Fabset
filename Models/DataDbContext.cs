using Microsoft.EntityFrameworkCore;

namespace fabset_project.Models
{
    public class DataDbContext : DbContext //Create db context class and inherit with base class
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) //configure dbContext option
        {
                
        }
        public DbSet<Signup> Signup { get; set; } // add your data models

    }
}
