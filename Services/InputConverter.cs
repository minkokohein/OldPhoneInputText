using System.Text;
using System.Text.RegularExpressions;

namespace OldPhoneInputText.Services
{
    public static class InputConverter
    {
        private static readonly IReadOnlyDictionary<char, string> Keypad = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        public static string Convert(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            var groups = Regex.Matches(input, @"(\d)\1*");

            foreach (Match group in groups)
            {
                var digit = group.Value[0];
                int count = group.Value.Length;

                if (!Keypad.ContainsKey(digit))
                    continue;

                var letters = Keypad[digit];
                int index = (count - 1) % letters.Length;

                result.Append(letters[index]);
            }

            return result.ToString();
        }
    }
}
