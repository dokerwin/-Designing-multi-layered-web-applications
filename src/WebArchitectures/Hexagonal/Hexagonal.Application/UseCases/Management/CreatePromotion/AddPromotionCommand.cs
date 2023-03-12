using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;
public record AddPromotionCommand(PromotionDto PromotionDto) : IRequest<PromotionResultDto>;

