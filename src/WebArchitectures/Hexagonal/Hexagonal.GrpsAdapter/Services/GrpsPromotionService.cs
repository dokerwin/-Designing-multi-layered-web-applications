using AutoMapper;
using Grpc.Core;
using MediatR;

namespace Hexagonal.GrpsAdapter.Services;
public class GrpsPromotionService : PromotionService.PromotionServiceBase
{
    private readonly ILogger<GrpsPromotionService> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public GrpsPromotionService(ILogger<GrpsPromotionService> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async Task<PromotionResponse> CreatePromotion(CreatePromotionRequest request, ServerCallContext context)
    {
        var requet = _mapper.Map<AddPromotionDto>(request);

        var result = await _mediator.Send(new AddPromotionCommand(requet));

        return new PromotionResponse
        {
            PromotionId = result.PromotionId.ToString(),
            Name= request.Name,
            Description = request.Description,
        };
    }
}
