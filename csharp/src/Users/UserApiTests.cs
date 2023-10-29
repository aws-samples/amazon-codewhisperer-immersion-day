using System.Net;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

public class UserApiTests
{
    private IUsersDBContextFactory _usersDBContextFactory;  

    public UserApiTests()
    {
        var appConfig = Substitute.For<IAppConfig>();
        appConfig.GetConnectionString(default).ReturnsForAnyArgs($"Filename={nameof(UserApiTests)}DB.db");
        appConfig.EnsureDBCreated.Returns(true);
        _usersDBContextFactory = new UsersDBContextFactory(appConfig);
    }    

    [Fact]
    public void InvalidEmailShouldReturn400Test()
    {
        var user = new User 
        {
            UserName = $"john_{DateTime.Now:yyyyMMddHHmmss}", 
            Email = "InvalidEmail",
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            City = "New York",
            State = "NY",
            Zip = "10001",
            Country = "USA"
        };

        var userApi = new UserApi(_usersDBContextFactory);
        var response = userApi.RegisterUser(user);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);    
    }

    [Fact]
    public void InvalidZipShouldReturn400Test()
    {
        var user = new User 
        {
            UserName = $"john_{DateTime.Now:yyyyMMddHHmmss}", 
            Email = "InvalidEmail",
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            City = "New York",
            State = "NY",
            Zip = "invalid-zip",
            Country = "USA"
        };
        var userApi = new UserApi(_usersDBContextFactory);
        var response = userApi.RegisterUser(user);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);    
    }

    [Fact]
    public void MissingValuesForRequiredFieldsShouldReturn400Test()
    {
        var user = new User 
        {
            UserName = $"john_{DateTime.Now:yyyyMMddHHmmss}", 
            Email = "InvalidEmail",
            FirstName = "",
            LastName = "Doe",
            Age = 30,
            City = "New York",
            State = "NY",
            Zip = "invalid-zip",
            Country = ""
        };
        var userApi = new UserApi(_usersDBContextFactory);
        var response = userApi.RegisterUser(user);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);    
    }

    [Fact]
    public void ValidUserShouldReturn200Test()
    {
        //Create sample User
        var user = new User 
        {
            UserName = $"john_{DateTime.Now:yyyyMMddHHmmss}", 
            Email = "john@example.com",
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            City = "New York",
            State = "NY",
            Zip = "10001",
            Country = "USA"
        };
        var userApi = new UserApi(_usersDBContextFactory);
        var response = userApi.RegisterUser(user);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
