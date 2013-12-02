using System;

namespace Sense.Core
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
            set
            {
                if (value.Length != (_Height * _Width))
                {
                    throw new InvalidOperationException("Data is wrong size for display");
                }
                _Contents = (byte[])value.Clone();                
            }
        }

        public Display(short rows, short columns)
        {
            Height = rows;
            Width = columns;
        }

        public Display(short rows, short columns, byte[] contents) : this(rows, columns)
        {            
            Contents = contents;
        }

        public void Clear()
        {
            _Contents = null;
        }

        public void Write(short r, short c, byte p)
        {
            Contents[r * (_Height - 1) + c] = p;
        }
    }
}
