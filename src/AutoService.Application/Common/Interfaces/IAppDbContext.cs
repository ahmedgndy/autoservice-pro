using AutoService.Domain.Customers;
using AutoService.Domain.Customers.Vehicles;
using AutoService.Domain.Employees;
using AutoService.Domain.Identity;
using AutoService.Domain.RepairTasks;
using AutoService.Domain.RepairTasks.Parts;
using AutoService.Domain.WorkOrders;
using AutoService.Domain.WorkOrders.Billing;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Application.Common.Interface;

public interface IAppDbContext
{
    public DbSet<Customer> Customers { get; }
    public DbSet<Part> Parts { get; }
    public DbSet<RepairTask> RepairTasks { get; }
    public DbSet<Vehicle> Vehicles { get; }
    public DbSet<WorkOrder> WorkOrders { get; }
    public DbSet<Employee> Employees { get; }
    public DbSet<Invoice> Invoices { get; }
    public DbSet<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}