using Layered.Application.DTOs;
using Layered.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Layered.Api.Conrollers;


[ApiController]
[Route("api/[controller]")]
public class PromotionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PromotionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public Task<PromotionDto> Get([FromRoute] Guid id)
    {
        var promo = _mediator.Send(new GetPromotionsByIdQuery(id));
        return promo;
    }

    [HttpGet]
    public async Task<IEnumerable<PromotionDto>> Get()
    {
        var promotionDtos = await _mediator.Send(new GetAllPromotionsQuery());
        return promotionDtos;
    }

    [HttpPost]
    public async Task<ActionResult> AddPromotion([FromBody] PromotionDto newPromo)
    {
        var result = await _mediator.Send(new AddPromotionCommand(newPromo));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePromotion([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeletePromotionCommand(id));
        return Ok(result);
    }


    [HttpPost("CalculatePromo")]
    public async Task<ActionResult> CalculatePromo([FromBody] RawBasket rawBasket)
    {
        var result = await _mediator.Send(new CalculatePromotionForBasketCommand(rawBasket));
        return Ok(result);
    }

}