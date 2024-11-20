namespace Lab6.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public int StatusCode { get; set; }
    public string? OrganisationName { get; set; }
    public string? IndividualFirstName { get; set; }
    public string? IndividualMiddleName { get; set; }
    public string? IndividualLastName { get; set; }
    public string? OtherDetails { get; set; }

    public CustomerStatus? CustomerStatus { get; set; }
    public ICollection<Order>? Orders { get; set; }
}