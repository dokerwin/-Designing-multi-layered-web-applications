using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management.UpdatePromotion;
public record UpdatePromotionCommand(PromotionDto PromotionDto) : IRequest<bool>;

