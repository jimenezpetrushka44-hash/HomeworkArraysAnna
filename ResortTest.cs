namespace TestProject1
{
    public class ResortTest
    {
        [Fact]
        public void InvalidNights_ThrowsExcecpt()
        {
            var rates = new RePrice[]
            {
                new RePrice(1, 2, 200),
                new RePrice(3, 4, 180)
            };

            Assert.Throws<System.Exception>(() => ResortPricesApp.FindRate(rates, 0));
        }
    }
}