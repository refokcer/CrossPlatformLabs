namespace Lab6.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal OrderAmountDue { get; set; }
    public string? OtherDetails { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<PartInOrder>? PartsInOrders { get; set; }
}