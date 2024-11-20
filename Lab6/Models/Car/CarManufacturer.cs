namespace Lab6.Models;

public class CarManufacturer
{
    public int CarManufacturerNr { get; set; }
    public string? CarManufacturerName { get; set; }

    public ICollection<Car>? Cars { get; set; }
}