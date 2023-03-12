using Hexagonal.Shared.Application.DTOs;
using MediatR;

public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDto>>;

