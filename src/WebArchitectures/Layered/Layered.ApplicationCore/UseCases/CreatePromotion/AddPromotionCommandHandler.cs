using AutoMapper;
using Layered.Application.DTOs;
using Layered.Domain.Entities;
using Layered.Domain.Services.Interfaces;
using MediatR;

namespace Layered.Application.UseCases.CreatePromotion;

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
