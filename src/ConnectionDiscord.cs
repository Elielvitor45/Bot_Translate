    public class connectionDiscord
    {
        public string getToken()
        {
            DotNetEnv.Env.Load();
            return Environment.GetEnvironmentVariable("URL_BOT") ?? "No token found";
        }
    }
