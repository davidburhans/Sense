using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Sense.Device
{
    public class TheDevice
    {
        private IInputProvider _Input = null;
        private Display _Display = null;

        private bool _LedStatus = false;
        public bool LedStatus
        {
            get
            {
                return _LedStatus;
            }
            set
            {
                _LedStatus = value;
                _LedPort.Write(_LedStatus);
            }
        }
        public bool ButtonStatus
        {
            get
            {
                return _ButtonPort.Read();
            }
        }

        private static OutputPort _LedPort;
        private static InputPort _ButtonPort;

        static TheDevice()
        {
            _LedPort = new OutputPort(Pins.ONBOARD_LED, false);
            _ButtonPort = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);
        }

        public TheDevice(IInputProvider inputProvider, IDisplayProvider displayProvider)
        {
            _Input = inputProvider;
            _Display = displayProvider.GetDisplay();            
        }

        public void ProcessData()
        {
            WriteDataToDisplay(GetDataForOutput());
        }

        private byte[] GetDataForOutput()
        {
            return _Input.GetInput();
        }

        private void WriteDataToDisplay(byte[] outputData)
        {
            _Display.Clear();
            for(short r = 0; r < _Display.Height; ++r)
            {
                int rowOffset = r * _Display.Height;
                if (rowOffset >= outputData.Length)
                {
                    break;
                }
                for (short c = 0; c < _Display.Width; ++c )
                {
                    int idx = rowOffset + c;
                    if(idx >= outputData.Length)
                    {
                        break;
                    }
                    _Display.Write(r, c, outputData[idx] );
                }                
            }
            
        }
    }
}
