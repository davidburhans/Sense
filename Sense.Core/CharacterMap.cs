using System;
using System.Text;
using Sense.Core;

namespace Sense.Core
{
    public class CharacterMap : ICharacterMap
    {
        private System.Collections.Hashtable _Mapping = new System.Collections.Hashtable();
                
        public Display Default = new Display(3, 2);
        public Display MappingFor(char c)
        {           
            return _Mapping.Contains(c) ? (Display)_Mapping[c] : Default;
        }

        public void SetMapping(char c, Display display)
        {
            if (_Mapping.Contains(c))
            {
                _Mapping.Remove(c);
            }
            _Mapping.Add(c, display);
        }       

    }

    public class BrailleCharacterMap : CharacterMap
    {
        public BrailleCharacterMap()
        {
            this.SetMapping('a', new Display(3,2, new byte[] { 100, 0, 0, 0, 0, 0 }));
            this.SetMapping('b', new Display(3,2, new byte[] { 100, 0, 100, 0, 0, 0 }));
            this.SetMapping('c', new Display(3,2, new byte[] { 100, 100, 0, 0, 0, 0 }));
            this.SetMapping('d', new Display(3,2, new byte[] { 100, 100, 0, 100, 0, 0 }));
            this.SetMapping('e', new Display(3,2, new byte[] { 100, 0, 0, 100, 0, 0 }));
            this.SetMapping('f', new Display(3,2, new byte[] { 100, 100, 100, 0, 0, 0 }));
            this.SetMapping('g', new Display(3,2, new byte[] { 100, 100, 100, 100, 0, 0 }));
            this.SetMapping('h', new Display(3,2, new byte[] { 100, 0, 100, 100, 0, 0 }));
            this.SetMapping('i', new Display(3,2, new byte[] { 0, 100, 100, 0, 0, 0 }));
            this.SetMapping('j', new Display(3,2, new byte[] { 0, 100, 100, 100, 0, 0 }));
            this.SetMapping('k', new Display(3,2, new byte[] { 100, 0, 0, 0, 100, 0 }));
            this.SetMapping('l', new Display(3,2, new byte[] { 100, 0, 100, 0, 100, 0 }));
            this.SetMapping('m', new Display(3,2, new byte[] { 100, 100, 0, 0, 100, 0 }));
            this.SetMapping('n', new Display(3,2, new byte[] { 100, 100, 0, 100, 100, 0 }));
            this.SetMapping('o', new Display(3,2, new byte[] { 100, 0, 0, 100, 100, 0 }));
            this.SetMapping('p', new Display(3,2, new byte[] { 100, 100, 100, 0, 100, 0 }));
            this.SetMapping('q', new Display(3,2, new byte[] { 100, 100, 100, 100, 100, 0 }));
            this.SetMapping('r', new Display(3,2, new byte[] { 100, 0, 100, 100, 100, 0 }));
            this.SetMapping('s', new Display(3, 2, new byte[] { 0, 100, 100, 0, 100, 0 }));
            this.SetMapping('t', new Display(3,2, new byte[] { 0, 100, 100, 100, 100, 0 }));
            this.SetMapping('u', new Display(3,2, new byte[] { 100, 0, 0, 0, 100, 100 }));
            this.SetMapping('v', new Display(3,2, new byte[] { 100, 0, 100, 0, 100, 100 }));
            this.SetMapping('w', new Display(3,2, new byte[] { 0, 100, 100, 100, 0, 100 }));
            this.SetMapping('x', new Display(3,2, new byte[] { 100, 100, 0, 0, 100, 100 }));
            this.SetMapping('y', new Display(3,2, new byte[] { 100, 100, 0, 100, 100, 100 }));
            this.SetMapping('z', new Display(3,2, new byte[] { 100, 0, 0, 100, 100, 100 }));
        }
    }
}
