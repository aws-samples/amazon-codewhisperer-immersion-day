using System.Net;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserApi
{
    private readonly IUsersDBContextFactory _usersDBContextFactory;

    public UserApi(IUsersDBContextFactory usersDBContextFactory)
    {
        _usersDBContextFactory = usersDBContextFactory;
    }

    //Function to register a user and return a RegisterUserResponse object
    public RegisterUserResponse RegisterUser(User user)
    {
        
        //Uncomment the below lines once you have the validation functions implemented

        //if (!IsValidUser(user))
        //{
        //    return new RegisterUserResponse(HttpStatusCode.BadRequest, "Missing required fields");
        //}
        //if (!IsValidEmail(user.Email))
        //{
        //    return new RegisterUserResponse(HttpStatusCode.BadRequest, "Invalid email");
        //}
        //if (!IsValidZip(user.Zip))
        //{
        //    return new RegisterUserResponse(HttpStatusCode.BadRequest, "Invalid zip");
        //}

        //Save user to database using UsersDBContext
        using (var usersDBContext = _usersDBContextFactory.CreateDbContext())
        {
            usersDBContext.Users.Add(user);
            usersDBContext.SaveChanges();
        }

        return new RegisterUserResponse(HttpStatusCode.OK, "User registered successfully");
    }
}

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; } 
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}

public class RegisterUserResponse
{
    public RegisterUserResponse(HttpStatusCode statusCode, string Message)
    {
        this.StatusCode = statusCode;
        this.Message = Message;    
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}
