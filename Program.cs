using OldPhoneInputText.Services;

class Program
{
    static void Main(string[] args)
    {
        var converter = new InputConverter();

        Console.WriteLine("Enter keypad input:");
        string input = Console.ReadLine()?.Replace(" ", "") ?? "";

        string result = converter.Convert(input);
        Console.WriteLine($"Output: {result}");
    }
}
