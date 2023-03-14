using AutoMapper;
using Layered.Domain.Entities;
using Layered.Domain.Services.Interfaces;
using MediatR;

namespace Layered.Application.UseCases.UpdatePromotion;

public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, bool>
{
    private readonly IPromoService _promoService;
    private readonly IMapper _mapper;
    public UpdatePromotionCommandHandler(IPromoService promoEngine, IMapper mapper)
    {
        _promoService = promoEngine;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var promo = _mapper.Map<Promotion>(request.PromotionDto);
        return await _promoService.UpdatePromotion(promo);
    }
}
