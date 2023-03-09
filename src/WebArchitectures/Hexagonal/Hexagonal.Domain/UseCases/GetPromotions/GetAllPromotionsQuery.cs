using Hexagonal.Application.DTOs;
using MediatR;

public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDto>>;

