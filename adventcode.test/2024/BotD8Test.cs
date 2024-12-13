using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD8Test
    {
        string[] datas = new string[]
        {
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............"
        };
        [Fact]
        public void a()
        {
            IBot bot = new BotD8a();
            var resultat = bot.Compute(datas);
            Assert.Equal(3749, resultat);
        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD7b();
            var resultat = bot.Compute(datas);
            Assert.Equal(11387, resultat);

        }
    }
}