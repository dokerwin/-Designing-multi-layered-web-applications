using Layered.Application.DTOs;
using MediatR;

namespace Layered.Application.UseCases.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, PromotionResultDto>
{
    public Task<PromotionResultDto> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
