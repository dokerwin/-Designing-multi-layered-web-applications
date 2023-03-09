using Hexagonal.Application.DTOs;
using MediatR;
public record GetPromotionsByIdQuery(Guid Id) : IRequest<PromotionDto>;
