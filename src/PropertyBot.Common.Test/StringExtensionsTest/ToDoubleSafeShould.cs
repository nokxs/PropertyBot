using PropertyBot.Common.Extensions;
using Xunit;

namespace PropertyBot.Common.Test.StringExtensionsTest
{
    public class ToFormattedDoubleShould
    {
        [Theory]
        [InlineData("1000", 1000)]
        [InlineData("100.000", 100000)]
        [InlineData("1000,0", 1000)]
        [InlineData("1000,00", 1000)]
        [InlineData(" 1000,00", 1000)]
        [InlineData("1000,00 ", 1000)]
        [InlineData(" 1000,00 ", 1000)]
        [InlineData("0,1", 0.1)]
        [InlineData("1000,50", 1000.5)]
        [InlineData("1000,3", 1000.3)]
        public void ParseCorrectly(string value, double expectedOutcome)
        {
            Assert.Equal(expectedOutcome, value.ToDoubleSafe());
        }

        [Theory]
        [InlineData("1000 abc", 0)]
        [InlineData("abc, 100", 0)]
        public void ReturnZeroForInvalidData(string value, double expectedOutcome)
        {
            Assert.Equal(expectedOutcome, value.ToDoubleSafe());
        }
    }
}
