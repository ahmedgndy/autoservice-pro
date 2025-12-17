using AutoService.Domain.Common;
using AutoService.Domain.Common.Results;
using AutoService.Domain.Identity;

namespace AutoService.Domain.Employees;

public sealed class Employee : AuditableEntity
{
    public string FirstName { get; }
    public string LastName { get; }

    public string FullName => $"{FirstName} {LastName}";

    public Role Role { get; }

    private Employee() : base() { }

    private Employee(Guid id, string firstName, string lastName, Role role) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }

    public static Result<Employee> Create(Guid id, string firstName, string lastName, Role role)
    {
        if (id == Guid.Empty)
            return EmployeeErrors.IdRequired;

        if (string.IsNullOrWhiteSpace(firstName))
            return EmployeeErrors.FirstNameRequired;

        if (string.IsNullOrWhiteSpace(lastName))
            return EmployeeErrors.LastNameRequired;

        if (!Enum.IsDefined(role))
            return EmployeeErrors.RoleInvalid;

        var employee = new Employee(id, firstName.Trim().ToLower(), lastName.Trim().ToLower(), role);
        return employee;
    }
}