using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Server.InputProvider;
using Sense.Server.DisplayProvider;
using System.IO.Ports;
using Sense.Core;

namespace Sense.Server
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var characterMap = new BrailleCharacterMap();

            var inputProvider = new CharacterMapInputProvider(characterMap);
            inputProvider.Text = "abcdefg";
            
            var displayProvider = new ConsoleDisplayProvider();

            var theDevice = new VirtualDevice(inputProvider, displayProvider);
            DeviceHarness harness = new DeviceHarness(theDevice);

            harness.Execute();
        }
    }
}
