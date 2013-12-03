using System;
using System.Text;
using System.Collections;

namespace Sense.Core
{
    public class CyclicInputProvider : IInputProvider
    {
        protected byte[][] _Inputs = new byte[][]
        {
            new byte[]{100,0,0,0,0,0},
            new byte[]{0,100,0,0,0,0},
            new byte[]{0,0,100,0,0,0},
            new byte[]{0,0,0,100,0,0},
            new byte[]{0,0,0,0,100,0},
            new byte[]{0,0,0,0,0,100},
        };
        IEnumerator _Enumerator = null;
        protected IEnumerator Enumerator
        {
            get
            {
                if (_Enumerator == null)
                {
                    _Enumerator = _Inputs.GetEnumerator();
                    _Enumerator.MoveNext();
                }         
                return _Enumerator;
            }
        }

        public byte[] GetInput()
        {
            var result = (byte[])Enumerator.Current;
            if (!Enumerator.MoveNext())
            {
                Enumerator.Reset();
                Enumerator.MoveNext();
            }
            return result;
        }
    }
}
