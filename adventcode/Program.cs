using adventcode._2024;

namespace adventcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IBot bot = new BotD6b();
            var datas = bot.LoadData(@"./2024/06/input1.txt");
            var resultats = bot.Compute(datas);
            Console.WriteLine($"Le résultat est : {resultats}");
        }
    }
}
