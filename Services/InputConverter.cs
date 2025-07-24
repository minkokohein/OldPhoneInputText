using System.Text;
using System.Text.RegularExpressions;

namespace OldPhoneInputText.Services
{
    public static class InputConverter
    {
        private static readonly IReadOnlyDictionary<char, string> Keypad = new Dictionary<char, string>
        {
            { '1', "&’(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " },
            { '*', "backspace" },
            { '#', "send" }
        };

        public static string Convert(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // The '#' key must be present to terminate input.
            int sendIndex = input.IndexOf('#');
            if (sendIndex == -1)
            {
                return string.Empty;
            }

            input = input.Substring(0, sendIndex);

            var result = new StringBuilder();
            int i = 0;
            while (i < input.Length)
            {
                char currentChar = input[i];

                if (currentChar == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                    i++;
                }
                else if (Keypad.TryGetValue(currentChar, out var letters))
                {
                    int groupStart = i;
                    while (i + 1 < input.Length && input[i + 1] == currentChar)
                    {
                        i++;
                    }
                    int count = i - groupStart + 1;

                    int index = (count - 1) % letters.Length;
                    result.Append(letters[index]);
                    i++;
                }
                else
                {
                    i++;
                }
            }

            return result.ToString();
        }
    }
}
