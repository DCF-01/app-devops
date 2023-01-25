while (true)
{
    using var client = new HttpClient();
    var pingUri = "https://google.com";
        
    client.BaseAddress = new Uri(pingUri);
    var res = client.GetAsync("/");
    Console.WriteLine($"App1 pinged {pingUri}, response: {(int)res.Result.StatusCode} {res.Result.StatusCode}");
    Thread.Sleep(1000);
}