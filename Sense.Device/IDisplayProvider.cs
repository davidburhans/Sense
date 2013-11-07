using System;
using System.Text;

namespace Sense.Device
{
    public interface IDisplayProvider
    {
        Display GetDisplay();
        void RenderDisplay();
    }
}
