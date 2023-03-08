using Onion.Application.DTOs;
using MediatR;

public record AddPromotionCommand(PromotionDto PromotionDto) : IRequest<PromotionResultDto>;

