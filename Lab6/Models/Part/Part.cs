namespace Lab6.Models;

public class Part
{
    public int PartId { get; set; }
    public int BrandId { get; set; }
    public int MainSupplierNr { get; set; }
    public string? PartGroupID { get; set; }
    public string? PartMakerCode { get; set; }
    public string? PartTypeCode { get; set; }
    public string? PartName { get; set; }
    public string? MainSupplierName { get; set; }
    public decimal PriceToUs { get; set; }
    public decimal PriceToCustomer { get; set; }
    public string? OtherPartDetails { get; set; }

    public Brand? Brand { get; set; }
    public PartMaker? PartMaker { get; set; }
    public ICollection<PartSupplier>? PartSuppliers { get; set; }
}