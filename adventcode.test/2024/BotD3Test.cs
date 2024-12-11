using adventcode._2024;

namespace adventcode.test._2024
{
    public class BotD3Test
    {
        string[] datasa = new string[]
            {
                "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
            };
        string[] datasb = new string[]
            {
                "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
            };

        [Fact]
        public void a()
        {
            

            IBot bot = new BotD3a();
            var resultat = bot.Compute(datasa);
            Assert.Equal(161, resultat);

        }

        [Fact]
        public void b()
        {

            IBot bot = new BotD3b();
            var resultat = bot.Compute(datasb);
            Assert.Equal(48, resultat);

        }
    }
}