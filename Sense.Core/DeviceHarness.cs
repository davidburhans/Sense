using System;
using System.Text;
using System.Threading;

namespace Sense.Core
{
    public class DeviceHarness
    {
        private BaseDevice _TheDevice = null;
        public DeviceHarness(BaseDevice theDevice)
        {
            _TheDevice = theDevice;
        }

        public void Execute()
        {
            while (true)
            {
                _TheDevice.LedStatus = _TheDevice.ButtonStatus;
                if (_TheDevice.ButtonStatus)
                {
                    _TheDevice.ProcessData();
                }

                Thread.Sleep(_TheDevice.DisplayDelay);
            }

        }
    }
}
