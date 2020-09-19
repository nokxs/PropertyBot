using Xunit;

namespace PropertyBot.Common.Test.DoubleExtensionsTest
{
    public class ToFormattedDoubleShould
    {
        [Theory]
        [InlineData(1000, "1.000")]
        [InlineData(5, "5")]
        [InlineData(1.5, "1,5")]
        [InlineData(1.51, "1,51")]
        [InlineData(1000000, "1.000.000")]
        [InlineData(1000000.13, "1.000.000,13")]
        public void FormatCorrectly(double value, string expectedOutcome)
        {
            Assert.Equal(expectedOutcome, value.Format());
        }
    }
}
