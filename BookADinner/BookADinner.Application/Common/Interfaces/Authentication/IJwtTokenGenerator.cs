using BookADinner.Domain.Entities;

namespace BookADinner.Application.Common.Interface.Authentication;
 

 public interface IJwtTokenGenerator
 {
    string GenerateToken( User user);
 }