using Layered.Application.DTOs;
using MediatR;

namespace Layered.Application.Handlers;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, PromotionResultDto>
{
    public Task<PromotionResultDto> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
