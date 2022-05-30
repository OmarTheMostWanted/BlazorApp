namespace WebApp;

public class Client
{


    private readonly HttpClient _client;
    
    public Client(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7121/");
    }

    public async Task<bool> SetX(double x)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetX/{x}");
        var response = await _client.SendAsync(httpRequest, CancellationToken.None);
        return response.IsSuccessStatusCode;
    }
    
    
    public async Task<bool> SetY(double y)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetY/{y}");
        var response = await _client.SendAsync(httpRequest, CancellationToken.None);
        return response.IsSuccessStatusCode;
    }
    
    
    public async Task<bool> SetOp(char op)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetOp{op}");
        var response = await _client.SendAsync(httpRequest, CancellationToken.None);
        return response.IsSuccessStatusCode;
    }


    public async Task<double> Calculate()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/calculator/res");
        var response = await _client.SendAsync(httpRequest, CancellationToken.None);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<double>();
        }

        return 0;
    }

    public async Task<bool> Reset()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Delete, "calculator/reset");
        var response =  await _client.SendAsync(httpRequest, CancellationToken.None);
        return response.IsSuccessStatusCode;
    }

}