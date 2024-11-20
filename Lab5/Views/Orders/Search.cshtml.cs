using Lab5.Services;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class SearchModel : PageModel
{
    private readonly OrderService _orderService;

    public SearchModel(OrderService orderService)
    {
        _orderService = orderService;
    }

    [BindProperty(SupportsGet = true)]
    public DateTime? Date { get; set; }
    [BindProperty(SupportsGet = true)]
    public string StartsWith { get; set; }
    [BindProperty(SupportsGet = true)]
    public string EndsWith { get; set; }

    public List<Order> Orders { get; set; }

    public async Task OnGetAsync()
    {
        Orders = await _orderService.SearchOrdersAsync(Date, null, StartsWith, EndsWith);
    }
}
