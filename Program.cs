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
