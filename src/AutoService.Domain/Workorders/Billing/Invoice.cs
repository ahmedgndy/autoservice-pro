using AutoService.Domain.Common;
using AutoService.Domain.Common.Results;

namespace AutoService.Domain.WorkOrders.Billing;

public class Invoice : AuditableEntity
{
    public Guid WorkOrderId { get; }
    public DateTimeOffset IssuedAtUtc { get; }
    public decimal DiscountAmount { get; private set; }

    public decimal TaxAmount { get; }
    public decimal Subtotal => LineItems.Sum(x => x.LineTotal);
    public decimal Total => Subtotal - DiscountAmount + TaxAmount;
    public DateTimeOffset? PaidAt { get; private set; }
    public WorkOrder? WorkOrder { get; set; }
    public InvoiceStatus Status { get; private set; }

    private readonly List<InvoiceLineItem> _lineItems = [];

    public IReadOnlyList<InvoiceLineItem> LineItems => _lineItems;

    private Invoice()
    { }
    private Invoice(
         Guid id,
         Guid workOrderId,
         DateTimeOffset issuedAt,
         List<InvoiceLineItem> lineItems,
         decimal discountAmount,
         decimal taxAmount)
         : base(id)
    {
        WorkOrderId = workOrderId;
        IssuedAtUtc = issuedAt;
        DiscountAmount = discountAmount;
        Status = InvoiceStatus.Unpaid;
        TaxAmount = taxAmount;
        _lineItems = lineItems;
    }

    public static Result<Invoice> Create(
        Guid id,
        Guid workOrderId,
        DateTimeOffset issuedAt,
        List<InvoiceLineItem> lineItems,
        decimal discountAmount,
        decimal taxAmount)
    {
        if (workOrderId == Guid.Empty)
            return InvoiceErrors.WorkOrderIdInvalid;

        if (lineItems == null || !lineItems.Any())
            return InvoiceErrors.LineItemsEmpty;

        if (discountAmount < 0)
            return InvoiceErrors.DiscountNegative;

        var subtotal = lineItems.Sum(x => x.LineTotal);
        if (discountAmount > subtotal)
            return InvoiceErrors.DiscountExceedsSubtotal;

        var invoice = new Invoice(
            id,
            workOrderId,
            issuedAt,
            lineItems,
            discountAmount,
            taxAmount);

        return invoice;
    }

    public Result<Updated> ApplyDiscount(decimal discountAmount)
    {
        if (Status != InvoiceStatus.Unpaid)
        {
            return InvoiceErrors.InvoiceLocked;
        }

        if (discountAmount < 0)
        {
            return InvoiceErrors.DiscountNegative;
        }

        if (discountAmount > Subtotal)
        {
            return InvoiceErrors.DiscountExceedsSubtotal;
        }

        DiscountAmount = discountAmount;

        return Result.Updated;
    }


    public Result<Updated> MarkAsPaid(TimeProvider timeProvider)
    {
        if (Status != InvoiceStatus.Unpaid)
        {
            return InvoiceErrors.InvoiceLocked;
        }

        Status = InvoiceStatus.Paid;
        PaidAt = timeProvider.GetUtcNow();

        return Result.Updated;
    }

}