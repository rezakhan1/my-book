using Microsoft.EntityFrameworkCore;
using my_book.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().
                HasOne(b => b.Book).
                WithMany(ba => ba.Author_Books).
                HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Author_Book>().
                HasOne(b => b.Author).
              WithMany(ba => ba.Author_Books).
              HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Log>().HasKey(id => id.Id);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Author_Book> Author_Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Log> Logs { get; set; }

    }
}
