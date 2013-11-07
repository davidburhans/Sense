using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Sense.Device
{
    public class Program
    {       
   
        public static void Main()
        {
            try
            {
                var inputProvider = new StaticInputProvider();
                var displayProvider = new MotorDisplayProvider(Motor.GetMotors());
                var theDevice = new TheDevice(inputProvider, displayProvider);

                while (true)
                {
                    theDevice.ProcessData();
                    theDevice.LedStatus = theDevice.ButtonStatus;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

    }
}
