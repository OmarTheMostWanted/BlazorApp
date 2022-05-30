namespace WebApp;

public class Client
{


    private readonly HttpClient _client;
    
    public Client(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7121/");
    }

    public async Task<bool> SetX(double x , CancellationToken cancellationToken = default)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetX/{x}");
        var response = await _client.SendAsync(httpRequest, cancellationToken);
        return response.IsSuccessStatusCode;
    }
    
    
    public async Task<bool> SetY(double y, CancellationToken cancellationToken = default)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetY/{y}");
        var response = await _client.SendAsync(httpRequest , cancellationToken);
        return response.IsSuccessStatusCode;
    }
    
    
    public async Task<bool> SetOp(char op, CancellationToken cancellationToken = default)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetOp{op}");
        var response = await _client.SendAsync(httpRequest, cancellationToken);
        return response.IsSuccessStatusCode;
    }


    public async Task<double> Calculate(CancellationToken cancellationToken = default)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/calculator/res");
        var response = await _client.SendAsync(httpRequest, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<double>();
        }

        return 0;
    }

    public async Task<bool> Reset(CancellationToken cancellationToken = default)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "calculator/reset");
        var response =  await _client.SendAsync(httpRequest,cancellationToken);
        return response.IsSuccessStatusCode;
    }

}