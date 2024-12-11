using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD6Test
    {
        string[] datas = new string[]
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        };
        [Fact]
        public void a()
        {
            

            IBot bot = new BotD6a();
            var resultat = bot.Compute(datas);
            Assert.Equal(41, resultat);

        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD6b();
            var resultat = bot.Compute(datas);
            Assert.Equal(123, resultat);

        }
    }
}