namespace Lab6.Models;

public class CarManufacturer
{
    public int CarManufacturerId { get; set; }
    public string? CarManufacturerName { get; set; }

    public ICollection<Car>? Cars { get; set; }
}