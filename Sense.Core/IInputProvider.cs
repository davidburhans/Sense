using System;
using System.Text;

namespace Sense.Core
{
    public interface IInputProvider
    {
        byte[] GetInput();
    }
}
