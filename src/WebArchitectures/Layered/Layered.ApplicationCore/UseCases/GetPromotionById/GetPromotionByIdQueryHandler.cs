using Layered.Application.DTOs;
using MediatR;

namespace Onion.Application.UseCases.GetPromotionById;

public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionsByIdQuery, PromotionDto>
{
    public Task<PromotionDto> Handle(GetPromotionsByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
