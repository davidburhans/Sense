using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Core;

namespace Sense.Server.DisplayProvider
{
    public class ConsoleDisplayProvider : IDisplayProvider
    {
        Display _Display;
        short NumberOfColumns = 2;
        public ConsoleDisplayProvider()
        {
            _Display = new Display(3, NumberOfColumns);
        }

        public Display GetDisplay()
        {
            return _Display;
        }

        public void RenderDisplay()
        {
            var colNum = 0;
            Console.Clear();
            foreach (var r in _Display.Contents)
            {
                Console.Write("\t{0}", r.ToString("x"));
                ++colNum;
                if (colNum >= NumberOfColumns)
                {
                    colNum = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
