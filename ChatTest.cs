namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AppliesTo_isTrue()
        {
            var chat = new Chat(414, 0.10);
            Assert.True(chat.AppliesTo(414));
            Assert.False(chat.AppliesTo(123));
        }
    }
}