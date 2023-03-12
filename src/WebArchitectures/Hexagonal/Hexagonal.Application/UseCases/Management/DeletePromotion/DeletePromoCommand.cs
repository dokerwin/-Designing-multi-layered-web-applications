using MediatR;

namespace Hexagonal.Application.UseCases.Management;
public record DeletePromotionCommand(Guid Id) : IRequest<bool>;

