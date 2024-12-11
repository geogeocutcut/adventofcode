using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD1Test
    {
        [Fact]
        public void a()
        {
            var datas = new string[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };

            IBot bot = new BotD3a();
            var resultat = bot.Compute(datas);
            Assert.Equal(11, resultat);

        }

        [Fact]
        public void b()
        {
            var datas = new string[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };

            IBot bot = new BotD1b();
            var resultat = bot.Compute(datas);
            Assert.Equal(31, resultat);

        }
    }
}