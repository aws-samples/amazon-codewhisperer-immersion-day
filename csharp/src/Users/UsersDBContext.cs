using Microsoft.EntityFrameworkCore;

public class UsersDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
    {
    }    
}