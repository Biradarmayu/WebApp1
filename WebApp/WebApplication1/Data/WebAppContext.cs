using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;


namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        
       public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }


        // Include the new models for the one-to-one relationship
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAddress> TeacherAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Configure one-to-one relationship for Teacher and TeacherAddress
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Address)
                .WithOne(a => a.Teacher)
                .HasForeignKey<TeacherAddress>(a => a.TeacherId);

        }

        
    }


    
}







    












 




