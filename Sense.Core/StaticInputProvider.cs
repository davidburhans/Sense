using System;
using Sense.Core;

namespace Sense.Device
{
    public class StaticInputProvider : IInputProvider
    {
        static public byte[] Input = new byte[]{100,100,100,100,100,100};

        public byte[] GetInput()
        {
            return Input;
        }
    }
}
