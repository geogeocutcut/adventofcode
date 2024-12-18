using adventcode._2024;

namespace adventcode
{
    internal class Program
    {
        static (IBot, string) config => (new BotD11b(), @"./2024/11/input1.txt");

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IBot bot = config.Item1;
            var datas = bot.LoadData(config.Item2);
            var resultats = bot.Compute(datas);
            Console.WriteLine($"Le résultat est : {resultats}");
        }
    }
}
