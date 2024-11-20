namespace Lab6.Models;

public class PartSupplier
{
    public int PartSupplierId { get; set; }
    public int PartId { get; set; }
    public int SupplierNr { get; set; }

    public Part? Part { get; set; }
    public Supplier? Supplier { get; set; }
}