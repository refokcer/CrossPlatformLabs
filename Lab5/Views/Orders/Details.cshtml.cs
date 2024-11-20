using Lab5.Services;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OrderDetailsModel : PageModel
{
    private readonly OrderService _orderService;

    public OrderDetailsModel(OrderService orderService)
    {
        _orderService = orderService;
    }

    public Order Order { get; set; }

    public async Task OnGetAsync(int id)
    {
        Order = await _orderService.GetOrderByIdAsync(id);
    }
}
