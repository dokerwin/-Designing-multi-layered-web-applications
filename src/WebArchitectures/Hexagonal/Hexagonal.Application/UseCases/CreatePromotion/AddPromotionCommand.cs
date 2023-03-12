﻿using Hexagonal.Shared.Application.DTOs;
using MediatR;

public record AddPromotionCommand(PromotionDto PromotionDto) : IRequest<PromotionResultDto>;

