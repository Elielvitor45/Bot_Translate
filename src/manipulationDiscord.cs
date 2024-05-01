using Discord;
using Discord.WebSocket;
public class ManipulationDiscord
{

    private string GetTokenBot()
    {
        DotNetEnv.Env.Load();
        return Environment.GetEnvironmentVariable("KEY_BOT") ?? "No token found";
    }

    public async Task createConnectionDiscord()
    {
        var config = new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
        };

        var client = new DiscordSocketClient(config);
        client.Log += LogAsync;

        client.MessageReceived += MessageReceivedAsync;

        await client.LoginAsync(TokenType.Bot, this.GetTokenBot());

        Console.WriteLine(client.LoginState);

        await client.StartAsync();

        // client.Ready += async () =>
        // {
        //     var guild = client.GetGuild(1235242325500887050);
        //     var channel = guild.GetTextChannel(1235242325500887053);

        //     await channel.SendMessageAsync("Hello World");

        //     await client.DisposeAsync();
        // };
    }
    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log);
        return Task.CompletedTask;
    }
    private async Task MessageReceivedAsync(SocketMessage message)
    {
        // Verifica se a mensagem vem de um usuário
        if (!(message is SocketUserMessage userMessage)) return;


        var channel = userMessage.Channel as SocketTextChannel;
        if(channel == null) return;
        Console.WriteLine($"Channel: {channel.Name}, Guild: {channel.Guild.Name}");

        Console.WriteLine("message.Content" + message.Content);
        Console.WriteLine($"{userMessage.Author.Username}: {userMessage.Content}");



    
    }
}




