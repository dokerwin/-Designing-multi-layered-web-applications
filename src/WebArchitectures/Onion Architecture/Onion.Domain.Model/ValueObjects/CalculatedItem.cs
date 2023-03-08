namespace Onion.Domain.Model.ValueObjects;

public class CalculatedItem
{
    public Guid Id { get; set; }
    public decimal OldUnitPrice { get; set; }
    public decimal UnitPrice { get; set; }
    public double Quantitity { get; set; }
    public bool Promoted { get; set; }
}
