using Layered.Application.DTOs;
using MediatR;

namespace Layered.Application.UseCases.GetPromotions;
public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDto>>;

