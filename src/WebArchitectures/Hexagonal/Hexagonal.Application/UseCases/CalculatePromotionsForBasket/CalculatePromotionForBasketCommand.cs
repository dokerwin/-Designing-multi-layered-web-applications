using Hexagonal.Shared.Application.DTOs;
using MediatR;

public record CalculatePromotionForBasketCommand(RawBasketDto Basket) : IRequest<CalculatedBasketDto>;

