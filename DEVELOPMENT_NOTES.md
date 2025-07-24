# Development Process Notes

This document outlines the high-level development process followed for creating the Old Phone Pad Input Converter.

### 1. Define the Key Mappings

- Create a dictionary to map the phone pad digits (0-9) and special characters (`*`, `#`) to their corresponding string values (e.g., '2' -> "ABC", '*' -> "backspace").

### 2. Implement Core Conversion Logic

- Process the input string by grouping consecutive identical keystrokes.
- For each group, determine the correct character from the key mapping based on the number of keystrokes.

### 3. Handle Special Characters and Edge Cases

- **Backspace (`*`):** Implement logic to remove the last character from the result.
- **Send (`#`):** Use this key to signify the end of the input. All subsequent characters are ignored.
- **Pause (` `):** Use a space to separate character groups, allowing for different characters on the same key to be typed consecutively.
- **Invalid Characters:** Gracefully ignore any characters in the input that are not part of the defined keypad.

### 4. Produce the Final Output

- Combine the processed characters into a final output string.

### 5. Refactor for Quality and Clarity

- Review the initial implementation for improvements. Refactor the conversion logic into a dedicated, stateless utility class (`InputConverter`) and choose appropriate data structures (e.g., `IReadOnlyDictionary`) to ensure immutability and express intent.

### 6. Unit Testing

- Create a comprehensive suite of unit tests using a framework like xUnit. Cover basic functionality, complex sequences, and a wide range of edge cases to ensure the converter is robust and reliable.

### 7. Documentation

- Create a `README.md` file to document the project's features, setup instructions, and key design decisions.