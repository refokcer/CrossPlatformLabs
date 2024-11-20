namespace Lab6.Models;

public class PartMaker
{
    public string? PartMakerCode { get; set; }
    public string? PartMakerName { get; set; }

    public ICollection<Part>? Parts { get; set; }
}