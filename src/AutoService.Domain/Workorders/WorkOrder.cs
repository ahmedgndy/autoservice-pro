using AutoService.Domain.Common;
using AutoService.Domain.WorkOrders.Enums;
using AutoService.Domain.Employees;
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



}