using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

using Sense.Core;

namespace Sense.Head
{
    public class TheDevice : BaseDevice
    {        
        private bool _LedStatus = false;
        public override bool LedStatus
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
        public override bool ButtonStatus
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

        public TheDevice(IInputProvider inputProvider, IDisplayProvider displayProvider) : base(inputProvider, displayProvider)
        {

        }

                
    }
}
