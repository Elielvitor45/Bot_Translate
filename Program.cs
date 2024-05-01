using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;


        async Task RunBotAsync()
        {
            connectionDiscord connection = new connectionDiscord();
            
            var client = new DiscordSocketClient();
            string token = connection.getToken();
            Console.WriteLine(token);
            await client.LoginAsync(TokenType.Bot, token);
            
            Console.WriteLine(client.LoginState);
            
            await client.StartAsync();

            client.Ready += async () =>
            {
                var guild = client.GetGuild(1235242325500887050);
                var channel = guild.GetTextChannel(1235242325500887053);
    
                await channel.SendMessageAsync("Hello World");
    
                await client.DisposeAsync();
            };


        }

        await RunBotAsync();
        Console.ReadKey();
    

