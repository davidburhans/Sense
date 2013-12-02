using System;
namespace Sense.Core
{
    public interface ICharacterMap
    {        
        Sense.Core.Display MappingFor(char c);
        void SetMapping(char c, Display display);
    }

    public interface ICharacterMapProvider
    {
        ICharacterMap FromFile(string filename);
        ICharacterMap FromString(string[] characterMappings);        
    }
}
