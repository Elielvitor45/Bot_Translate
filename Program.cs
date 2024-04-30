namespace Bot_Translate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            connectionDiscord connection = new connectionDiscord();
            Console.WriteLine(connection.getToken());
        }
    }
}
