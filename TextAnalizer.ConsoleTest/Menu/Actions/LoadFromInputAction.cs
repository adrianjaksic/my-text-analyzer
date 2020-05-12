using System;

namespace TextAnalizer.ConsoleTest.Menu.Actions
{
    public class LoadFromInputAction : IAppAction
    {
        public string Name => "Load from input";

        public string GetText()
        {
            Console.WriteLine("Enter text:");
            return Console.ReadLine();
        }
    }
}
