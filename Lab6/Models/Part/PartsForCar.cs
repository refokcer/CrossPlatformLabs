namespace Lab6.Models;

public class PartsForCar
{
    public int PartId { get; set; }
    public int CarId { get; set; }

    public Part? Part { get; set; }
    public Car? Car { get; set; }
}