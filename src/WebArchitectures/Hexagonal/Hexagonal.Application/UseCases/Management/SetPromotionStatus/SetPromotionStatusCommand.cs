using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;
public record SetPromotionStatusCommand(Guid PromotionId, bool NewStatus) : IRequest<bool>;

