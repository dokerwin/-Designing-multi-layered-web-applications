using System.ComponentModel.DataAnnotations;

namespace Hexagonal.Infrastructure.DTOs;

public class PromotionDatabaseDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public List<Guid> ItemList { get; set; }

    [Required]
    public decimal DiscountValue { get; set; }
}
