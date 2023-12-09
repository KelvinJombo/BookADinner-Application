using BookADinner.Domain.Entities;

namespace BookADinner.Application.Common.Interface.Persistence;


public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}