using MediatR;
using Onion.Application.DTOs;
using Onion.Domain.Services.Services.Interfaces;

namespace Onion.Application.UseCases.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, PromotionResultDto>
{
    private readonly IPromoService _promoService;

    public DeletePromotionCommandHandler(IPromoService promoService)
    {
        _promoService = promoService;
    }

    public async Task<PromotionResultDto> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var result = await _promoService.DeletePromotion(request.Id);

        return new PromotionResultDto() { Success = result };
    }
}
