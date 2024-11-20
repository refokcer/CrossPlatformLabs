namespace Lab6.Models;

public class Supplier
{
    public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? StreetAddress { get; set; }
    public string? Town { get; set; }
    public string? County { get; set; }
    public string? Postcode { get; set; }
    public string? Phone { get; set; }
    public string? OtherDetails { get; set; }

    public ICollection<PartSupplier>? PartSuppliers { get; set; }
}