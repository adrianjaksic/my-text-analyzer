using System;
using System.Collections.Generic;
using TextAnalizer.ConsoleTest.Menu;
using TextAnalizer.ConsoleTest.Menu.Actions;

namespace TextAnalizer.ConsoleTest
{
    class Program
    {
        private static List<IAppAction> AppActions = new List<IAppAction>() { new LoadFromFileAction(), new LoadFromDatabaseAction(), new LoadFromInputAction()};
  
        static void Main(string[] args)
        {
            char action = '0';
            do
            {
                try
                {
                    action = CreateMenuAndReadAction();
                    if (action != 'q')
                    {
                        string text = DoAction(action);
                        if (text != null)
                        {
                            var wordCounterAction = new WordCounterRequestAction(text);
                            wordCounterAction.Do();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error happened: {e.Message}");
                }
                Console.WriteLine();
            } while (action != 'q');
        }

        private static string DoAction(char action)
        {
            var i = (int)action - 48;
            if (AppActions.Count >= i)
            {
                var doAction = AppActions[i - 1];
                if (doAction != null)
                {
                    return doAction.GetText();
                }
            }
            return null;
        }

        private static char CreateMenuAndReadAction()
        {
            List<char> alowedKey = new List<char>();
            int i = 1;
            Console.WriteLine($"Chose action:");
            foreach (var action in AppActions)
            {
                var ch = Convert.ToChar(48 + i++);
                alowedKey.Add(ch);
                Console.WriteLine($"{ch}-{action.Name}");
            }
            alowedKey.Add('q');
            Console.WriteLine($"q - Quit");
            char character;
            do
            {
                character = Console.ReadKey().KeyChar;
            }
            while (!alowedKey.Contains(character));            
            Console.WriteLine();
            return character;
        }
    }
}
