using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ManipulationDiscord
{
    private DiscordSocketClient? _client;

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

        _client = new DiscordSocketClient(config);
        _client.Log += LogAsync;
        _client.MessageReceived += MessageReceivedAsync;

        await _client.LoginAsync(TokenType.Bot, this.GetTokenBot());
        await _client.StartAsync();
    }

    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log);
        return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (!(message is SocketUserMessage userMessage)) return;

        var channel = userMessage.Channel as SocketTextChannel;
        if (channel == null) return;

        //channel = channel.Name
        //guild = channel.Guild.Name

        if (_client == null) return;
        if (userMessage.Author.Id == _client.CurrentUser.Id) return;

        await SendMessageToChannel(channel.Guild.Name, channel.Name, "Hello world");
    }

    private async Task SendMessageToChannel(string guildName, string channelName, string messageContent)
    {
        if (_client == null) return;
        var guild = _client.Guilds.FirstOrDefault(g => g.Name == guildName);

        if (guild == null)
        {
            Console.WriteLine("Servidor não encontrado.");
            return;
        }

        var channel = guild.TextChannels.FirstOrDefault(c => c.Name == channelName);
        if (channel == null)
        {
            Console.WriteLine("Canal não encontrado.");
            return;
        }
        await channel.SendMessageAsync(messageContent);
    }
}
