using Hexagonal.Domain.Services.Services.Interfaces;
using MediatR;

namespace Hexagonal.Application.UseCases.Management;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, bool>
{
    private readonly IPromoService _promoService;

    public DeletePromotionCommandHandler(IPromoService promoService)
    {
        _promoService = promoService;
    }

    public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var result = await _promoService.DeletePromotion(request.Id);

        return result;
    }
}
