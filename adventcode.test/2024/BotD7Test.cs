using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD7Test
    {
        string[] datas = new string[]
        {
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20"
        };
        [Fact]
        public void a()
        {
            

            IBot bot = new BotD7a();
            var resultat = bot.Compute(datas);
            Assert.Equal(3749, resultat);

        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD6b();
            var resultat = bot.Compute(datas);
            Assert.Equal(6, resultat);

        }
    }
}