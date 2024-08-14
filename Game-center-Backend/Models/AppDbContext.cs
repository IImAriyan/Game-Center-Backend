using Microsoft.EntityFrameworkCore;

namespace Game_center_Backend.Models;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}