using BookADinner.Application.Common.Interfaces.Services;

namespace BookADinner.Infrastructure.Services;


public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}