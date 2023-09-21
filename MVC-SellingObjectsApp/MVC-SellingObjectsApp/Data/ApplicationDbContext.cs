using Microsoft.EntityFrameworkCore;
using MVC_SellingObjectsApp.Models;

namespace MVC_SellingObjectsApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // create constructor
        {
            
        }
        // creating Category table with Category collumns, where we wrote inside the category model
        public DbSet<Category> Categories { get; set; }
    }
}
