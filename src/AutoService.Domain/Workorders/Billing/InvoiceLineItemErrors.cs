using System.Security.Permissions;
using AutoService.Domain.Common.Results;

namespace AutoService.Domain.WorkOrders.Billing;


public static class InvoiceLineItemErrors
{
    public static Error InvoiceIdRequired => Error.Validation(
        code: "InvoiceLineItem.InvoiceId.Required",
        description: "Invoice Id is required."
    );

    public static Error LineNumberInvalid => Error.Validation(
        code: "InvoiceLineItemErrors.LineNumberInvalid",
        description: "Line number must be greater than 0.");

    public static Error DescriptionRequired => Error.Validation(
        code: "InvoiceLineItemErrors.DescriptionRequired",
        description: "Description is required.");

    public static Error QuantityInvalid => Error.Validation(
        code: "InvoiceLineItemErrors.QuantityInvalid",
        description: "Quantity must be greater than 0.");

    public static Error UnitPriceInvalid => Error.Validation(
        code: "InvoiceLineItemErrors.UnitPriceInvalid",
        description: "Unit price must be greater than 0.");

}