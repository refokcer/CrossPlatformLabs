using Lab6.Models;
using Microsoft.AspNetCore.Http.Extensions;

public class OrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("Lab6API");
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        var response = await _httpClient.GetAsync("orders");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Order>>();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"orders/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Order>();
    }

    public async Task<List<Order>> SearchOrdersAsync(DateTime? date, List<int> items, string startswith, string endswith)
    {
        var query = new QueryBuilder();
        if (date.HasValue) query.Add("date", date.Value.ToString("yyyy-MM-dd"));
        if (items != null && items.Any()) query.Add("items", string.Join(",", items));
        if (!string.IsNullOrEmpty(startswith)) query.Add("startswith", startswith);
        if (!string.IsNullOrEmpty(endswith)) query.Add("endswith", endswith);

        var response = await _httpClient.GetAsync($"orders/search{query.ToQueryString()}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Order>>();
    }
}
