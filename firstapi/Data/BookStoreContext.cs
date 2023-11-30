using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using firstapi.Models;

namespace firstapi.Data
{
    public class BookStoreContext :IdentityDbContext<applicationuser>

    {
        public BookStoreContext(DbContextOptions<BookStoreContext>options):base(options) 
        { 
        }

        public DbSet<Book> Books { get; set; } 
        
    }
}
