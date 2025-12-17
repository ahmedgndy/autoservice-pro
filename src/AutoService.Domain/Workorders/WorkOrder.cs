using AutoService.Domain.Common;
using AutoService.Domain.WorkOrders.Enums;
using AutoService.Domain.Employees;
using AutoService.Domain.Customers.Vehicles;
using AutoService.Domain.WorkOrders.Billing;
namespace AutoService.Domain.WorkOrders;

public sealed class WorkOrder : AuditableEntity
{
    public Guid VehicleId { get; }
    public DateTimeOffset StartAtUtc { get; private set; }
    public DateTimeOffset EndAtUtc { get; private set; }
    public Guid LaborId { get; private set; }
    public Spot Spot { get; private set; }
    public WorkOrderState State { get; private set; }

    public Employee? Labor { get; set; }
    public Vehicle? Vehicle { get; set; }

    public Invoice? Invoice { get; set; }

    public decimal? Discount { get; private set; }
    public decimal? Tax { get; private set; }

    private

}