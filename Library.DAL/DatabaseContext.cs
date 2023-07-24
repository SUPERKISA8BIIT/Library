
using Library.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;

    public static async Task SeedDataAsync(DatabaseContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();
        await dbContext.SaveChangesAsync();
    }


}
