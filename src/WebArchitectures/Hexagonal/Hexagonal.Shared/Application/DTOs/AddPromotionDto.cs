using System.ComponentModel.DataAnnotations;

namespace Hexagonal.Shared.Application.DTOs;

public class AddPromotionDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public List<ItemDto> Items { get; set; }

    [Required]
    public decimal DiscountValue { get; set; }
}
