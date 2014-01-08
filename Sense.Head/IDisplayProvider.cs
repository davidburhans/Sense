using System;
using System.Text;

namespace Sense.Head
{
    public interface IDisplayProvider
    {
        Display GetDisplay();
        void RenderDisplay();
    }
}
