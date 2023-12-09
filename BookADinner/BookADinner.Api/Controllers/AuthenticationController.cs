 
using BookADinner.Contracts.Authentication;
//Userusing Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;


namespace BookADinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.FirstName,
                                                         request.LastName,
                                                         request.Email,
                                                         request.Password);

        var response = new AuthenticationResponse(authResult.User.Id,
                                                  authResult.User.FirstName,
                                                  authResult.User.LastName,
                                                  authResult.User.Email,
                                                  authResult.token);

        return Ok(request);
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(authResult.User.Id,
                                                  authResult.User.FirstName,
                                                  authResult.User.LastName,
                                                  authResult.User.Email,
                                                  authResult.token);

        
        return Ok(Response);
    }


}