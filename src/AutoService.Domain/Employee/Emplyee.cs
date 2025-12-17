using AutoService.Domain.Common;
using AutoService.Domain.Common.Results;

namespace AutoService.Domain.Employee;

public sealed class Employee : AuditableEntity
{
    public string FirstName { get; }
    public string LastName { get; }

    public string FullName => $"{FirstName} {LastName}";

    private Employee() : base()
    {

    }

    private Employee(Guid id, string firstName, string lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Result<Employee> Create(Guid id, string firstName, string lastName)
    {
        if (id == Guid.Empty)
            return EmployeeErrors.IdRequired;

        if (string.IsNullOrWhiteSpace(firstName))
            return EmployeeErrors.FirstNameRequired;
        if (string.IsNullOrWhiteSpace(lastName))
            return EmployeeErrors.LastNameRequired;

        var employee = new Employee(id, firstName, lastName);
        return employee;
    }
}