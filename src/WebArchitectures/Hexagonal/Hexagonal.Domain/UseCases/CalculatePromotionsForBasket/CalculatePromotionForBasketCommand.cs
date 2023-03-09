using MediatR;
using Hexagonal.Application.DTOs;
using Hexagonal.Domain.Model.ValueObjects;

public record CalculatePromotionForBasketCommand(RawBasketDto Basket) : IRequest<CalculatedBasket>;

