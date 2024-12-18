using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD10Test
    {
        string[] datas = new string[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        };
        [Fact]
        public void a()
        {
            IBot bot = new BotD10a();
            var resultat = bot.Compute(datas);
            Assert.Equal(36, resultat);
        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD10b();
            var resultat = bot.Compute(datas);
            Assert.Equal(81, resultat);

        }
    }
}