using AutoMapper;
using MediatR;
using Onion.Application.DTOs;
using Onion.Domain.Model.Entities;
using Onion.Domain.Services.Services.Interfaces;

namespace Onion.Application.UseCases.CreatePromotion;

public class AddPromotionCommandHandler : IRequestHandler<AddPromotionCommand, PromotionResultDto>
{
    private readonly IPromoService _promoService;
    private readonly IMapper _mapper;
    public AddPromotionCommandHandler(IPromoService promoEngine, IMapper mapper)
    {
        _promoService = promoEngine;
        _mapper = mapper;
    }
    public async Task<PromotionResultDto> Handle(AddPromotionCommand request, CancellationToken cancellationToken)
    {
        var promo = _mapper.Map<Promotion>(request.PromotionDto);
        var result = await _promoService.AddNewPromotion(promo);

        return await Task.FromResult(new PromotionResultDto() { Success = result });
    }
}
