using System;
using Microsoft.SPOT;

namespace Sense.Head
{
    public class Display
    {
        private short _Width;
        public short Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
                Clear();
            }
        }
        private short _Height;
        public short Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
                Clear();
            }
        }
        private byte[] _Contents = null;
        public byte[] Contents
        {
            get
            {
                return _Contents ?? (_Contents = new byte[_Height * _Width]);
            }
        }

        public Display(short rows, short columns)
        {
            Height = rows;
            Width = columns;
        }

        internal void Clear()
        {
            _Contents = null;
        }

        internal void Write(short r, short c, byte p)
        {
            Contents[r * _Height + c] = p;
        }
    }
}
