using Newtonsoft.Json;

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

    public async Task<string> TranslateText(string text)
    {
        string url = GetUrlApiTranslate();
        string key = getKeyApiTranslate();
        string urlComplete = $"{url}?key={key}&target=en&q={Uri.EscapeDataString(text)}";

        // Criando um cliente HttpClient
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(urlComplete);

            if (response.IsSuccessStatusCode)
            {

                string json = await response.Content.ReadAsStringAsync();


                dynamic? result = JsonConvert.DeserializeObject(json);


                if (result is not null)
                {
                    return result.data.translations[0].translatedText;

                }
                else
                {
                    Console.WriteLine("Erro ao desserializar o JSON.");
                }

            }
        }
        return "";
    }

}
