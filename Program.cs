﻿using OldPhoneInputText.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter keypad input (use space to pause, and '#' to end the input):");
        string input = Console.ReadLine() ?? "";
        string result = OldPhonePad(input);
        Console.WriteLine($"Output: {result}");
    }

    public static String OldPhonePad(string input) {
        return InputConverter.Convert(input);
    }
}
