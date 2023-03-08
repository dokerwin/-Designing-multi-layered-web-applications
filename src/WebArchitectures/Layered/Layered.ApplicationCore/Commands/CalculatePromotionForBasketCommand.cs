using Layered.Application.DTOs;
using Layered.Domain.ValueObjects;
using MediatR;

public record CalculatePromotionForBasketCommand(RawBasket Basket) : IRequest<CalculatedBasket>;

