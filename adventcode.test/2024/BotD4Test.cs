using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD4Test
    {
        string[] datas = new string[]
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        };

        [Fact]
        public void a()
        {
            

            IBot bot = new BotD4a();
            var resultat = bot.Compute(datas);
            Assert.Equal(18, resultat);

        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD4b();
            var resultat = bot.Compute(datas);
            Assert.Equal(9, resultat);

        }
    }
}