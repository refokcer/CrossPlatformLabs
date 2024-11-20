namespace Lab6.Models;

public class Brand
{
    public int BrandId { get; set; }
    public string? BrandName { get; set; }
    public string? BrandDetails { get; set; }

    public ICollection<Part>? Parts { get; set; }
}