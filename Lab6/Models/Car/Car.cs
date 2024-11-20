namespace Lab6.Models;

public class Car
{
    public int CarId { get; set; }
    public int CarManufacturerNr { get; set; }
    public int CarYearOfManufacture { get; set; }
    public string? CarModel { get; set; }
    public string? OtherCarDetails { get; set; }

    public CarManufacturer? CarManufacturer { get; set; }
    public ICollection<PartsForCar>? PartsForCars { get; set; }
}