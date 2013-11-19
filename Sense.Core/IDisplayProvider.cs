using System;
using System.Text;

namespace Sense.Core
{
    public interface IDisplayProvider
    {
        Display GetDisplay();
        void RenderDisplay();
    }
}
