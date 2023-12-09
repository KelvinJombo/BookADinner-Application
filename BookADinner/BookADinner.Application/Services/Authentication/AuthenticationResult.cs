using BookADinner.Domain.Entities;

namespace BookADinner.Application.Services.Authentication;

public record AuthenticationResult(
     User User,
    string Token
);