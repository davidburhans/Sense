using System;
using System.Text;

namespace Sense.Device
{
    public interface IInputProvider
    {
        byte[] GetInput();
    }
}
