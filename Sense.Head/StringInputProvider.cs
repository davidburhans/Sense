using System;
using Microsoft.SPOT;

namespace Sense.Head
{
    public class StaticInputProvider : IInputProvider
    {
        static public byte[] Input = new byte[] { 0, 0x77, 0xff };

        public byte[] GetInput()
        {
            return Input;
        }
    }
}
