using Xunit;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void IsAscending()
        {
            int[] temps = { 10, 20, 30, 40, 50 };
            Assert.True(TemperaturesComparisonApp.isAscending(temps));
            Assert.False(TemperaturesComparisonApp.IsDescending(temps));
        }

        [Fact]
        public void IsDescending()
        {
            int[] temps = { 50, 40, 30, 20, 10};
            Assert.True(TemperaturesComparisonApp.IsDescending(temps));
            Assert.False(TemperaturesComparisonApp.isAscending(temps));
        }
    }
}