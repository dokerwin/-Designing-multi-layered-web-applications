using AutoMapper;
using MediatR;
using Hexagonal.Application.DTOs;
using Hexagonal.Domain.Model.Entities;
using Hexagonal.Domain.Services.Services.Interfaces;

namespace Hexagonal.Application.UseCases.CreatePromotion;

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
