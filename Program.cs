﻿using OldPhoneInputText.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter keypad input (use space to pause between same-key letters):");
        string input = Console.ReadLine() ?? "";

        string result = InputConverter.Convert(input);
        Console.WriteLine($"Output: {result}");
    }
}
