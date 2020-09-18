using System;
using Xunit;

namespace PropertyBot.Common.Test
{
    public class ToIntSafeShould
    {
        [Theory]
        [InlineData("1000", 1000)]
        [InlineData("100.000", 100000)]
        [InlineData("1000,0", 1000)]
        [InlineData("1000,00", 1000)]
        [InlineData("1000 €", 1000)]
        [InlineData("1000,00 €", 1000)]
        [InlineData("100.000,00 €", 100000)]
        [InlineData(" 1000,00", 1000)]
        [InlineData("1000,00 ", 1000)]
        [InlineData(" 1000,00 ", 1000)]
        public void ParseCorrectly(string value, int expectedOutcome)
        {
            Assert.Equal(expectedOutcome, value.ToIntSafe());
        }

        [Theory]
        [InlineData("1000 abc", 0)]
        [InlineData("abc, 100", 0)]
        public void ReturnZeroForInvalidData(string value, int expectedOutcome)
        {
            Assert.Equal(expectedOutcome, value.ToIntSafe());
        }
    }
}
