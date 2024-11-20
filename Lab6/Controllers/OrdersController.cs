using Lab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _context.Orders.ToListAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchOrders([FromQuery] DateTime? date, [FromQuery] List<int> items, [FromQuery] string startswith, [FromQuery] string endswith)
    {
        var query = _context.Orders.AsQueryable();

        if (items != null && items.Any())
        {
            query = query.Where(o => items.Contains(o.OrderId));
        }

        if (!string.IsNullOrEmpty(startswith))
        {
            query = query.Where(o => o.Customer.OrganisationName.StartsWith(startswith));
        }

        if (!string.IsNullOrEmpty(endswith))
        {
            query = query.Where(o => o.Customer.OrganisationName.EndsWith(endswith));
        }

        var result = await query.Include(o => o.Customer).Include(o => o.PartsInOrders).ToListAsync();
        return Ok(result);
    }
}
