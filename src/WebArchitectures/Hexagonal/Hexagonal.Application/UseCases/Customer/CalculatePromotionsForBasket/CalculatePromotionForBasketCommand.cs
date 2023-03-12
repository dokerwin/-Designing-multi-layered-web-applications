using Hexagonal.Shared.Application.DTOs;
using MediatR;

namespace Hexagonal.Application.UseCases.Customer.CalculatePromotionsForBasket;
public record CalculatePromotionForBasketCommand(RawBasketDto Basket) : IRequest<CalculatedBasketDto>;

