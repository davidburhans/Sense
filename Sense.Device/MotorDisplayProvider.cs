using System;
using System.Text;

namespace Sense.Device
{
    public class MotorDisplayProvider : IDisplayProvider
    {
        Display _Display;
        static Motor[] _Motors;
        public MotorDisplayProvider(Motor[] motors)
        {
            _Motors = motors;
            _Display = new Display(1, (short)_Motors.Length);
        }

        public Display GetDisplay()
        {
            return _Display;
        }

        public void RenderDisplay()
        {
            for (short c = 0; c < _Motors.Length; ++c)
            {
                _Motors[c].Pwm(_Display.Contents[c]);
            }
        }
    }
}
