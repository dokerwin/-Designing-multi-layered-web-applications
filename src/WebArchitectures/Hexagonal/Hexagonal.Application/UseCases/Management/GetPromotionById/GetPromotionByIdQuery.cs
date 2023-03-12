using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;
public record GetPromotionsByIdQuery(Guid Id) : IRequest<PromotionDto>;
