using MediatR;
using Onion.Application.DTOs;
using Onion.Domain.Model.ValueObjects;

public record CalculatePromotionForBasketCommand(RawBasketDto Basket) : IRequest<CalculatedBasket>;

