using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("SchoolContext")
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TableClass> TableClasses { get; set; }
        public DbSet<TeachersClasses> TeachersClasses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}