# Old Phone Pad Input Converter

This is a C# console application that converts T9-style "old phone pad" input into a standard text string. It's built with .NET 6 and includes a comprehensive xUnit test suite.

## Features

- **Full Keypad Support**: Converts sequences of digits (0-9) into their corresponding characters.
- **Backspace Functionality**: The `*` key acts as a backspace, deleting the previously entered character.
- **Mandatory Send Key**: The `#` key is required to finalize the input. Any characters entered after the first `#` are ignored.
- **Pause/Separator Support**: A space (` `) acts as a pause, allowing for the input of different characters that are on the same key (e.g., `222 2 22` -> `CAB`).
- **Robust Error Handling**: The application gracefully ignores any unrecognized characters in the input string.

## How to Run

1.  **Build the project:**
    ```bash
    dotnet build
    ```

2.  **Run the application:**
    ```bash
    dotnet run
    ```

You will be prompted to enter a string. For example: `4433555 555666#`

## How to Test

The project includes a suite of xUnit tests to ensure correctness and handle edge cases.

1.  **Run the tests:**
    ```bash
    dotnet test
    ```

## Design Decisions

Several key design decisions were made to ensure the code is robust, maintainable, and clear.

### 1. Static `InputConverter` Class

The `InputConverter` is a `static` class because the conversion logic is a pure function—it takes an input, produces an output, and holds no internal state between calls. This makes it a stateless utility, and a static class is the most appropriate and efficient representation for this in C#. It simplifies the API, as consumers can call `InputConverter.Convert()` without needing to instantiate an object.

### 2. Mandatory `#` Send Key

The requirement for a `#` key to be present in every valid input string provides a clear, unambiguous signal that the user has finished entering their text. This avoids ambiguity and makes the parsing logic simpler and more reliable. If the `#` is missing, the input is considered invalid, and an empty string is returned.

### 3. Manual Parsing Loop over Regular Expressions

An initial implementation might use a regular expression like `(\d)\1*` to group consecutive digits. While clever, this approach becomes complex and less readable when trying to handle special characters like backspace (`*`) and spaces as separators.

The final implementation uses a standard `while` loop to iterate through the input string character by character. This approach is more explicit, easier to debug, and provides the flexibility needed to handle the different behaviors of digits, spaces, backspaces, and the send key in a single, clean pass.

### 4. `IReadOnlyDictionary` for Keypad Mapping

The mapping from a digit character to its possible letters (`'2' -> "ABC"`) is fixed and should never change at runtime. Using an `IReadOnlyDictionary<char, string>` clearly communicates this intent. It provides an immutable view of the collection, preventing accidental modification and making the code safer, especially in a multi-threaded context (though not a factor in this specific console app).

### 5. Comprehensive Test Suite

A thorough test suite was developed using xUnit. It leverages both `[Fact]` for single-condition tests and `[Theory]` with `[InlineData]` for data-driven tests. This allows for wide coverage of simple inputs, complex sequences, and a variety of edge cases (e.g., backspacing on an empty buffer, invalid characters, multiple send keys) to ensure the converter is reliable and behaves as expected under all conditions.