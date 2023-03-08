using Layered.Domain.ValueObjects;
using Layered.Application.DTOs;
using MediatR;

public record CalculatePromotionForBasketCommand(RawBasketDto Basket) : IRequest<CalculatedBasketDto>;

