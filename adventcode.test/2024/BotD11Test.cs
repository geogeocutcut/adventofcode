using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD11Test
    {
        string[] datas = new string[]
        {
            "125 17"
        };
        [Fact]
        public void a()
        {
            IBot bot = new BotD11a();
            var resultat = bot.Compute(datas);
            Assert.Equal(55312, resultat);
        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD11b();
            var resultat = bot.Compute(datas);
            Assert.Equal(65601038650482, resultat);

        }
    }
}