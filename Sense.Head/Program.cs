﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO.Ports;
using Sense.Core;
using System.IO;

namespace Sense.Head
{
    public class Program
    {

        
        public static void Main()
        {
            var characterMap = new BrailleCharacterMap();

            //var inputProvider = new CharacterMapInputProvider(characterMap);
            //inputProvider.Text = "abcdefg";
            var inputProvider = new CyclicInputProvider();            


            var displayProvider = new MotorDisplayProvider(Motor.GetMotors());
            var theDevice = new TheDevice(inputProvider, displayProvider);

            DeviceHarness harness = new DeviceHarness(theDevice);

            harness.Execute();
            
        }
       

    }
}
