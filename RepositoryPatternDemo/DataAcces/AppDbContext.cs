using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace RepositoryPatternDemo.DataAcces;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Animal> Animals { get; set; }
}