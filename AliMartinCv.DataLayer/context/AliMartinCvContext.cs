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
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<StudentInformation> StudentsInformations { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogGroup>().HasQueryFilter(option =>
            option.IsDeleted == false);
            modelBuilder.Entity<Blog>().HasQueryFilter(option =>
                option.BlogIsDeleted == false);
            
            

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Student)
                .WithOne(s => s.Parent)
                .HasForeignKey<Student>(s => s.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HomeWork>()
                .HasOne(h => h.Class)
                .WithMany(c => c.HomeWorks)
                .HasForeignKey(h => h.ClassId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            modelBuilder.Entity<StudentHomeWork>()
                .HasOne(sh => sh.HomeWork)
                .WithMany(h => h.StudentHomeWorks)
                .HasForeignKey(sh => sh.HomeWorkId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            modelBuilder.Entity<StudentHomeWork>()
                .HasOne(sh => sh.Student)
                .WithMany(s => s.StudentHomeWorks)
                .HasForeignKey(sh => sh.StudentId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<StudentHomeWork>()
                .HasIndex(sh => new { sh.HomeWorkId, sh.StudentId })
                .IsUnique();

            
            modelBuilder.Entity<HomeWork>()
                .Property(h => h.HomeWorkTitle)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<HomeWork>()
                .Property(h => h.HomeWorkDescriptions)
                .HasMaxLength(2000);
        }


    }
}




