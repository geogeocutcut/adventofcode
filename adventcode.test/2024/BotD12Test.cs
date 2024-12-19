using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD12Test
    {
        string[] datas = new string[]
        {
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        };
        string[] datas2 = new string[]
        {
            "OOOOO",
            "OXOXO",
            "OXXXO"
        };
        [Fact]
        public void a()
        {
            IBot bot = new BotD12a();
            var resultat = bot.Compute(datas);
            Assert.Equal(1930, resultat);
        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD12b();
            var resultat = bot.Compute(datas);
            Assert.Equal(1206, resultat);

        }

        [Fact]
        public void c()
        {

            IBot bot = new BotD12b();
            var resultat = bot.Compute(datas2);
            Assert.Equal(160, resultat);

        }
    }
}