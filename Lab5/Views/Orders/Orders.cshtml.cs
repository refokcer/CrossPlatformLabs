using Lab5.Services;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OrdersModel : PageModel
{
    private readonly OrderService _orderService;

    public OrdersModel(OrderService orderService)
    {
        _orderService = orderService;
    }

    public List<Order> Orders { get; set; }

    public async Task OnGetAsync()
    {
        Orders = await _orderService.GetAllOrdersAsync();
    }
}
