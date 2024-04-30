internal class connectionDiscord{

    

    public string getToken(){
        DotNetEnv.Env.Load();
        return Environment.GetEnvironmentVariable("KEY_BOT") ?? "No token found";
    }
}