# Copy Content

A simple C# console application that adds a "Copy Contents" option to the right-click context menu in Windows. When a user right-clicks on a file, they can choose "Copy Contents" to copy the plaintext content of the file to the clipboard.
Developed with the help of GPT4.

## Prerequisites

- .NET 6.0 or later
- TextCopy NuGet package

## Usage

1. Build the C# console application using Visual Studio or the .NET CLI.
2. Create a `.reg` file with the following contents to add the "Copy Contents" option to the context menu:

Windows Registry Editor Version 5.00

[HKEY_CLASSES_ROOT*\shell\CopyContents]
@="Copy Contents"

[HKEY_CLASSES_ROOT*\shell\CopyContents\command]
@=""C:\path\to\your\executable\Copy_Contents.exe" "%1""

csharp
Copy code

Replace `C:\\path\\to\\your\\executable\\Copy_Contents.exe` with the actual path to the built `Copy_Contents.exe` executable.

3. Double-click the `.reg` file to update the registry. This will add the "Copy Contents" option to the right-click context menu for files.

## Code Overview

The console application is based on the following `Program.cs` file:

```csharp
using System;
using System.IO;
using TextCopy;

namespace CopyContents
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filePath = args[0];
                CopyContentsToClipboard(filePath);
            }
        }

        static void CopyContentsToClipboard(string filePath)
        {
            string content = File.ReadAllText(filePath);
            ClipboardService.SetText(content);
        }
    }
}
