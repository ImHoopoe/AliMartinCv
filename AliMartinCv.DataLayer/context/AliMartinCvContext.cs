using AliMartinCv.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.context
{
    public class AliMartinCvContext : DbContext
    {
        public AliMartinCvContext(DbContextOptions<AliMartinCvContext> options) : base(options)
        {

        }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogGroup>().HasQueryFilter(option =>
            option.IsDeleted == false);
            modelBuilder.Entity<Blog>().HasQueryFilter(option =>
                option.BlogIsDeleted == false);
        }
    }
}




