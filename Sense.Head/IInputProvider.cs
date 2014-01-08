using System;
using System.Text;

namespace Sense.Head
{
    public interface IInputProvider
    {
        byte[] GetInput();
    }
}
