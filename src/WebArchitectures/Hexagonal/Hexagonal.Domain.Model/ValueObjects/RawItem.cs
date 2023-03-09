namespace Hexagonal.Domain.Model.ValueObjects;

public class RawItem
{
    public Guid Id { get; set; }
    public decimal UnitPrice { get; set; }
    public double Quantitity { get; set; }
}