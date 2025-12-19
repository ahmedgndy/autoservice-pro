using AutoService.Application.Features.Customers.Dtos;
using AutoService.Domain.Common.Results;
using MediatR;

namespace AutoService.Application.Features.Customers.Commands;

public sealed record CreateCustomerCommand(string Name,
                                           string PhoneNumber,
                                           string Email,
                                           List<CreateCustomerCommand> Vehicles
                                           ) : IRequest<Result<CustomerDto>>;