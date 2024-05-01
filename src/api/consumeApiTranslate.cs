public class ApiTranslate
{

    private string GetUrlApiTranslate()
    {
        DotNetEnv.Env.Load();
        return Environment.GetEnvironmentVariable("URL_API_TRANSLATE") ?? "No url found";
    }
    private string getKeyApiTranslate()
    {
        DotNetEnv.Env.Load();
        return Environment.GetEnvironmentVariable("KEY_API_TRANSLATE") ?? "No key found";
    }

    public async Task TranslateText(string text)
    {
        string url = GetUrlApiTranslate();
        string key = getKeyApiTranslate();
        string urlComplete = $"{url}?key={key}&target=en&q={Uri.EscapeDataString(text)}";
        
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(urlComplete);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucesso requisição");
            }
            else
            {
                Console.WriteLine("Erro ao desserializar o JSON.");
            }
        }

    }

}
