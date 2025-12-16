using AutoService.Domain.Common;

namespace AutoService.Domain.WorkOrders.Events;

public sealed class WorkOrderCompleted : DomainEvent
{
    public Guid WorkOrderId { get; }
}