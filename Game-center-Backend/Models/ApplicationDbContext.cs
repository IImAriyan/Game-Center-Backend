using Microsoft.EntityFrameworkCore;

namespace Game_center_Backend.Models;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<games> Games { get; set; }
    
    public DbSet<Posts> Posts { get; set; }
}                                                                          