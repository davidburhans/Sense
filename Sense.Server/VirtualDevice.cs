using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Core;
using System.Windows.Input;

namespace Sense.Server
{
    public class VirtualDevice : BaseDevice
    {
        public override bool LedStatus { get; set; }
        public override bool ButtonStatus
        {
            get
            {
                return (Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) == KeyStates.Down;
            }
        }

        public VirtualDevice(IInputProvider inputProvider, IDisplayProvider displayProvider) : base(inputProvider, displayProvider)
        {

        }
    }
}
