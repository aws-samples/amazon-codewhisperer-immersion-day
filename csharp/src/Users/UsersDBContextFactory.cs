using Microsoft.EntityFrameworkCore;

public class UsersDBContextFactory : IUsersDBContextFactory
{
    IAppConfig _appConfig;
    public UsersDBContextFactory(IAppConfig appConfig)
    {
        _appConfig = appConfig;
    }
    public UsersDBContext CreateDbContext()
    {
        var userDbContext = new UsersDBContext(new DbContextOptionsBuilder<UsersDBContext>()
            .UseSqlite(_appConfig.GetConnectionString("UsersDB"))
            .Options);

        if(_appConfig.EnsureDBCreated)
        {
            userDbContext.Database.EnsureCreated();
            userDbContext.Database.Migrate();
        }

        return userDbContext;
    }
}

public interface IUsersDBContextFactory : IDbContextFactory<UsersDBContext> { }
