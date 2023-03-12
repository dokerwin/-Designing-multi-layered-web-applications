using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;
public record GetAllPromotionsQuery() : IRequest<IEnumerable<PromotionDto>>;

