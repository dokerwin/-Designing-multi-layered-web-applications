using Hexagonal.Shared.Application.DTOs;
using MediatR;

public record DeletePromotionCommand(Guid Id) : IRequest<PromotionResultDto>;

