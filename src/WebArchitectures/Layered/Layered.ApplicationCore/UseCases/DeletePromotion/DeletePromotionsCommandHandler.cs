using Layered.Application.DTOs;
using Layered.Domain.Services.Interfaces;
using MediatR;

namespace Layered.Application.UseCases.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, bool>
{
    private readonly IPromoService _promoService;

    public DeletePromotionCommandHandler(IPromoService promoService)
    {
        _promoService = promoService;
    }

    public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var result = await _promoService.DeletePromotion(request.Id);

        return result;
    }
}
