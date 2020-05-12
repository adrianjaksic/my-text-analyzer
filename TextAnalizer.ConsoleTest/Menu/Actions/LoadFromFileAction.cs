using System;
using System.IO;

namespace TextAnalizer.ConsoleTest.Menu.Actions
{
    public class LoadFromFileAction : IAppAction
    {
        public string Name => "Load from file";

        public string GetText()
        {
            Console.WriteLine("Enter file path:");
            return File.ReadAllText(Console.ReadLine());
        }
    }
}
