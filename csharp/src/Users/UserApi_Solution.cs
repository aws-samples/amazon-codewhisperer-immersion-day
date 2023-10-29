using System.Net;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

public class UserApi_Solution
{ 
    private readonly IUsersDBContextFactory _usersDBContextFactory;
    
    public UserApi_Solution(IUsersDBContextFactory usersDBContextFactory)
    {
        _usersDBContextFactory = usersDBContextFactory;
    }
    
    //Function to test if Email is not null, not empty and is a valid email
    public bool IsValidEmail(string Email)
    {
        if (Email == null || !new EmailAddressAttribute().IsValid(Email))
        {
            return false;
        }
        return true;
    }

    //Function to test if a string contains a five-digit US zip code
    public bool IsValidZip(string Zip)
    {
        if (Zip == null || !new Regex("^[0-9]{5}$").IsMatch(Zip))
        {
            return false;
        }
        return true;
    }    

    //Function to test if required fields are present in the User object
    public bool IsValidUser(User user)
    {
        if (user.UserName == null || user.Email == null || user.FirstName == null || user.LastName == null || user.Age == 0 || user.City == null || user.State == null || user.Zip == null || user.Country == null)
        {
            return false;
        }
        return true;
    } 

    //Function to validate a new user object for required fields, valid email, valid username, valid zip, save user object and return a RegisterUserResponse object
    public RegisterUserResponse RegisterUser(User user)
    {
        if (!IsValidUser(user))
        {
            return new RegisterUserResponse(HttpStatusCode.BadRequest, "Missing required fields");
        }
        if (!IsValidEmail(user.Email))
        {
            return new RegisterUserResponse(HttpStatusCode.BadRequest, "Invalid email");
        }
        if (!IsValidZip(user.Zip))
        {
            return new RegisterUserResponse(HttpStatusCode.BadRequest, "Invalid zip");
        }
        using (var context = _usersDBContextFactory.CreateDbContext())
        {
            if (context.Users.Any(u => u.UserName == user.UserName))
            {
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "Username already exists");
            }
            context.Users.Add(user);
            context.SaveChanges();
        }
        return new RegisterUserResponse(HttpStatusCode.OK, "User created");
    }

    
}
