using OldPhoneInputText.Services;

namespace OldPhoneInputText.Tests
{
    public class InputConverterTests
    {
        private readonly InputConverter _converter = new();

        [Theory]
        [InlineData("2", "A")]
        [InlineData("22", "B")]
        [InlineData("222", "C")]
        [InlineData("3", "D")]
        [InlineData("33", "E")]
        [InlineData("0", " ")]
        public void Convert_SingleGroup_ReturnsCorrectLetter(string input, string expected)
        {
            string result = _converter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_MultipleGroups_ReturnsCorrectText()
        {
            string input = "4433555 555666096667775553";
            string expected = "HELLO WORLD";

            string result = _converter.Convert(input.Replace(" ", ""));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_EmptyString_ReturnsEmpty()
        {
            string result = _converter.Convert("");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Convert_UnknownDigit_IgnoresIt()
        {
            string result = _converter.Convert("111222");
            Assert.Equal("C", result); // 111 is ignored, 222 → C
        }
    }
}
