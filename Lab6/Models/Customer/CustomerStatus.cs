namespace Lab6.Models;

public class CustomerStatus
{
    public int CustomerStatusId { get; set; }
    public int StatusCode { get; set; }
    public string? StatusDescription { get; set; }

    public ICollection<Customer>? Customers { get; set; }
}