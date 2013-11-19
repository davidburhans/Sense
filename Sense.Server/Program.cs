using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Server.InputProvider;
using Sense.Server.DisplayProvider;

namespace Sense.Server
{
    class Program
    {
        static void Main(string[] args)
        {            
            BrailleInputProvider.CharacterMap.LoadFromFile("Text2Braille.txt");
            var input = new BrailleInputProvider();
            input.Text = "This is a test";

            var displayProvider = new ConsoleDisplayProvider();
            var display = displayProvider.GetDisplay();
            var displayContents = input.GetInput();
            
            while (displayContents != null)
            {
                display.Contents = displayContents;
                displayProvider.RenderDisplay();
                displayContents = input.GetInput();
                Console.ReadLine();
            }
        }
    }
}
