using AutoService.Application.Features.Customers.Dtos;
using AutoService.Domain.Common.Results;
using MediatR;

namespace AutoService.Application.Features.Customers.Commands;


public sealed record CreateVehicleCommand(
 string Make,
 string Model,
 int Year,
 string LicensePlate) : IRequest<Result<VehicleDto>>;
