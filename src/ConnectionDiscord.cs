using DotNetEnv;

public class connectionDiscord{
    public string getToken(){
        Env.Load();
        return Environment.GetEnvironmentVariable("KEY_BOT") ?? "No token found";
    }
}