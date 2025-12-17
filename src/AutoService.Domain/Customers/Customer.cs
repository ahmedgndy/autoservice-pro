using AutoService.Domain.Common;
using AutoService.Domain.Customers.Vehicles;

namespace AutoService.Domain.Customers;

public sealed class Customer : AuditableEntity
{
    public string? Name { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }

    private readonly List<Vehicle> _vehicles = [];


    public Customer(Guid id, string firstName, string lastName, string email, string phoneNumber)
    {
        Name = $"{firstName} {lastName}";
        Email = email;
        PhoneNumber = phoneNumber;
    }
}