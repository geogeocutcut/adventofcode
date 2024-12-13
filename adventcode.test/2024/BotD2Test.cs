using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD2Test
    {
        string[] datas = new string[]
            {
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9"
            };

        [Fact]
        public void a()
        {
            

            IBot bot = new BotD2a();
            var resultat = bot.Compute(datas);
            Assert.Equal(2, resultat);

        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD2b();
            var resultat = bot.Compute(datas);
            Assert.Equal(4, resultat);

        }
    }
}