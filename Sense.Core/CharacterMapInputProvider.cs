using System;
using System.Text;
using Sense.Core;

namespace Sense.Core
{
    public class CharacterMapInputProvider : IInputProvider
    {
        public string Text = "ABCDEFG";

        private ICharacterMap _CharacterMap = null;

        public CharacterMapInputProvider(ICharacterMap characterMap)
        {
            _CharacterMap = characterMap;
        }

        public byte[] GetInput()
        {
            if (Text != null && Text.Trim().Length > 0)
            {
                var display = _CharacterMap.MappingFor(Text[0]);
                Text = Text.Substring(1);
                return display.Contents;
            }
            return null;
        }

        
    }
}
