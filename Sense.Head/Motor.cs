using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Sense.Head
{
    public class Motor
    {
        public static readonly Cpu.Pin[] motorPins = new Cpu.Pin[] { Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D6, Pins.GPIO_PIN_D5, Pins.GPIO_PIN_D4, Pins.GPIO_PIN_D3, Pins.GPIO_PIN_D2 };

        private static Motor[] _Motors = null;
        public static Motor[] GetMotors()
        {
            if (_Motors == null)
            {
                _Motors = new Motor[motorPins.Length];
                int c = 0;
                foreach (var pin in motorPins)
                {
                    _Motors[c] = new Motor(pin, false);
                    ++c;
                }
            }

            return _Motors;
        }

        public static bool IsMotorPin(Cpu.Pin pin)
        {
            foreach (var motorPin in motorPins)
            {
                if (pin == motorPin)
                {
                    return true;
                }
            }
            return false;
        }

        protected OutputPort Port { get; set; }

        private bool _Enabled = false;
        public bool Enabled
        {
            get
            {
                return _Enabled;
            }
            private set
            {
                Write(value);
            }
        }

        public Motor(Cpu.Pin pin, bool initialState = false)
        {
            if (!IsMotorPin(pin))
            {
                throw new IndexOutOfRangeException(string.Concat(pin.ToString(), " is not a valid pin for motor usage."));
            }
            _Enabled = initialState;
            Port = new OutputPort(pin, _Enabled);
        }

        public bool Read()
        {
            return _Enabled;
        }

        public void Write(bool state)
        {
            if (state != _Enabled)
            {
                _Enabled = state;
                Port.Write(Enabled);
            }
        }

        public bool Toggle()
        {
            Enabled = !Enabled;
            return Enabled;
        }

        private byte currentDuty = 0;
        private byte maxDuty = 100;
        public bool Pwm(byte dutyCycle)
        {
            float divisor = 2.0f;
            if (dutyCycle > maxDuty)
            {
                throw new IndexOutOfRangeException("Invalid dutyCycle value. Must be less than " + maxDuty);
            }
            ++currentDuty;
            Enabled = currentDuty < dutyCycle / divisor;

            if (currentDuty >= maxDuty / divisor)
            {
                currentDuty = 0;
            }

            return Enabled;
        }
    }
}
