using AutoMapper;
using Hexagonal.Domain.Services.Services.Interfaces;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;

public class SetPromotionStatusCommandHandler : IRequestHandler<SetPromotionStatusCommand, bool>
{
    private readonly IPromoService _promoService;
    public SetPromotionStatusCommandHandler(IPromoService promoEngine)
    {
        _promoService = promoEngine;
    }
    public async Task<bool> Handle(SetPromotionStatusCommand request, CancellationToken cancellationToken)
    {
        var fetchedPromo = await _promoService.GetPromotionById(request.PromotionId);
        if (fetchedPromo is not null)
        {
            fetchedPromo.Status = request.NewStatus;
            return await _promoService.UpdatePromotion(fetchedPromo);
        }
        return false;
    }
}
