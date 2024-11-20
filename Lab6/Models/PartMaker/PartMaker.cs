namespace Lab6.Models;

public class PartMaker
{
    public int PartMakerId { get; set; }
    public string? PartMakerCode { get; set; }
    public string? PartMakerName { get; set; }

    public ICollection<Part>? Parts { get; set; }
}