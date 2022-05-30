namespace WebApp;

public class Client
{


    private readonly HttpClient _client;
    
    public Client(HttpClient client)
    {
        _client = client;
    }

    public async void SetX(double x)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"/calculator/SetX/{x}");
        
    }
    
}