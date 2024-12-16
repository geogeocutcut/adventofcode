using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD9Test
    {
        string[] datas = new string[]
        {
            "2333133121414131402"
        };
        [Fact]
        public void a()
        {
            IBot bot = new BotD9a();
            var resultat = bot.Compute(datas);
            Assert.Equal(1928, resultat);
        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD9b();
            var resultat = bot.Compute(datas);
            Assert.Equal(2858, resultat);

        }
    }
}