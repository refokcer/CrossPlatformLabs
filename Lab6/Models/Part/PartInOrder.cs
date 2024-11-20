namespace Lab6.Models;

public class PartInOrder
{
    public int PartInOrderId { get; set; }
    public int OrderId { get; set; }
    public int PartSupplierId { get; set; }
    public decimal ActualSalesPrice { get; set; }
    public int Quantity { get; set; }

    public Order? Order { get; set; }
    public PartSupplier? PartSupplier { get; set; }
}