
namespace Bot_Translate
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ManipulationDiscord manipulationDiscord = new ManipulationDiscord();
            await manipulationDiscord.createConnectionDiscord();
            Console.ReadKey();


        }


    }
}
