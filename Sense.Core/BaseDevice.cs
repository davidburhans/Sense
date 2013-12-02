using System;
using System.Text;

namespace Sense.Core
{
    public abstract class BaseDevice
    {
        public int DisplayDelay = 500;

        public abstract bool LedStatus { get; set; }
        public abstract bool ButtonStatus { get; }

        protected IDisplayProvider _DisplayProvider;
        protected IInputProvider _Input;
        protected Display _Display;

        public BaseDevice(IInputProvider inputProvider, IDisplayProvider displayProvider)
        {
            _Input = inputProvider;
            _Display = displayProvider.GetDisplay();
            _DisplayProvider = displayProvider;
        }

        public void ProcessData()
        {
            WriteDataToDisplay(GetDataForOutput());
            _DisplayProvider.RenderDisplay();
        }

        private byte[] GetDataForOutput()
        {
            return _Input.GetInput();
        }

        private void WriteDataToDisplay(byte[] outputData)
        {
            _Display.Clear();
            if (outputData == null)
            {
                return;
            }
            for (short r = 0; r < _Display.Height; ++r)
            {
                int rowOffset = r * _Display.Height;
                if (rowOffset >= outputData.Length)
                {
                    break;
                }
                for (short c = 0; c < _Display.Width; ++c)
                {
                    int idx = rowOffset + c;
                    if (idx >= outputData.Length)
                    {
                        break;
                    }
                    _Display.Write(r, c, outputData[idx]);
                }
            }

        }
    }
}
