using Layered.Application.DTOs;
using MediatR;

namespace Layered.Application.UseCases.UpdatePromotion;
public record UpdatePromotionCommand(PromotionDto PromotionDto) : IRequest<bool>;

