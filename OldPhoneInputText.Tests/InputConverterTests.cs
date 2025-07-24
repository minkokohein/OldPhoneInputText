using OldPhoneInputText.Services;

namespace OldPhoneInputText.Tests
{
    public class InputConverterTests
    {
        [Theory]
        [InlineData("2#", "A")]
        [InlineData("22#", "B")]
        [InlineData("222#", "C")]
        [InlineData("3#", "D")]
        [InlineData("33#", "E")]
        [InlineData("333#", "F")]
        [InlineData("4#", "G")]
        [InlineData("44#", "H")]
        [InlineData("444#", "I")]
        [InlineData("5#", "J")]
        [InlineData("55#", "K")]
        [InlineData("555#", "L")]
        [InlineData("6#", "M")]
        [InlineData("66#", "N")]
        [InlineData("666#", "O")]
        [InlineData("7#", "P")]
        [InlineData("77#", "Q")]
        [InlineData("777#", "R")]
        [InlineData("7777#", "S")]
        [InlineData("8#", "T")]
        [InlineData("88#", "U")]
        [InlineData("888#", "V")]
        [InlineData("9#", "W")]
        [InlineData("99#", "X")]
        [InlineData("999#", "Y")]
        [InlineData("9999#", "Z")]
        [InlineData("0#", " ")]
        public void Convert_SingleGroup_ReturnsCorrectLetter(string input, string expected)
        {
            string result = InputConverter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_MultipleGroups_ReturnsCorrectText()
        {
            string input = "4433555 555666096667775553#";
            string expected = "HELLO WORLD";

            string result = InputConverter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_EmptyString_ReturnsEmpty()
        {
            string result = InputConverter.Convert("");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Convert_SequenceWithNumericOne_ReturnsCorrectText()
        {
            // 1 -> &, 11 -> ’, 111 -> (
            string result = InputConverter.Convert("111222#"); // 111 -> '(', 222 -> 'C'
            Assert.Equal("(C", result);
        }

        [Fact]
        public void Convert_WithInvalidCharacters_IgnoresThem()
        {
            string result = InputConverter.Convert("a22b2c#");
            Assert.Equal("BA", result);
        }

        [Fact]
        public void Convert_WithBackspace_ReturnsCorrectText()
        {
            // "HI" -> 444**44# -> "H"
            string input = "444**44#";
            string expected = "H";
            string result = InputConverter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_WithSendKey_TerminatesInput()
        {
            string input = "222#333";
            string result = InputConverter.Convert(input);
            Assert.Equal("C", result); // Input after '#' is ignored
        }

        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        [InlineData("833*3777*77#", "TDQ")]
        [InlineData("222 2 22#", "CAB")]
        public void Convert_WithComplexInputs_ReturnsCorrectText(string input, string expected)
        {
            string result = InputConverter.Convert(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_InputWithoutSendKey_ReturnsEmpty()
        {
            string result = InputConverter.Convert("4433555");
            Assert.Equal(string.Empty, result);
        }
    }
}
