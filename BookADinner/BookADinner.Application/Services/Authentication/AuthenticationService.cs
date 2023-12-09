using BookADinner.Application.Common.Interface.Authentication;
using BookADinner.Application.Common.Interface.Persistence;
using BookADinner.Domain.Entities;

namespace BookADinner.Application.Services.Authentication;

public class AuthenticationServices : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

     

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1 Check/Validate if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
            //return new AuthenticationResult(false, "User already Exists");
        }

        //2 Create a user (generate unique ID) & Persist to DB
        var user = new User
        {   FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password
        };

        _userRepository.Add(user);

        //3 Create JWT token
       
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
             user,
            token );
    }


    public AuthenticationResult Login(string email, string password)
    {
        //1 Validate the User Exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doea=s not exist");
        }

        //2 Validate the Password is correct
        if (user.Password != password)
        {
            throw new Exception ("Invalid Password");
        }


        //3 Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
             
            user,
            token );
    }

    
}
