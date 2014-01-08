using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Core;
using System.Text.RegularExpressions;

namespace Sense.SkullSaw.InputProvider
{
    public class CharacterMapProvider : ICharacterMapProvider
    {
        
        private static Regex CoordinateParsingRegEx = new Regex(@"((\d+)\W*,\W*(\d+))", RegexOptions.Compiled);
        private static Regex LineParsingRegEx = new Regex(@"^(\w)\W*=\W*((\d+\W*,\W*\d+;?\W*)+)$", RegexOptions.Compiled);

        public ICharacterMap FromFile(string filename)
        {
            var lines = System.IO.File.ReadAllLines(filename);
            return FromString(lines);
        }

        public ICharacterMap FromString(string[] characterMappings)
        {
            var charMap = new CharacterMap();
            foreach (var line in characterMappings)
            {
                char mappingFor = default(char);
                var display = ParseLine(line, out mappingFor);
                charMap.SetMapping(char.ToLower(mappingFor), display ?? charMap.Default);
                
                // use to generate hard-coded character maps
                //var pixelContents = string.Empty;
                //bool first = true;
                //foreach (var pixel in display.Contents)
                //{
                //    if (!first)
                //    {
                //        pixelContents += ",";
                //    }
                //    pixelContents += pixel.ToString();
                    
                //    first = false;
                //}
                //Console.WriteLine("braille.SetMapping('{0}', new byte[] {{{1}}});", char.ToLower(mappingFor), pixelContents);
            }
            return charMap;
        }


        private Display ParseLine(string line, out char mappingFor)
        {
            Display display = new Display(3, 2);
            var match = LineParsingRegEx.Match(line);
            if (match.Success)
            {
                mappingFor = char.ToLower(match.Groups[1].Value.FirstOrDefault());
                var coords = match.Groups[2].Value;
                var coordsMatches = CoordinateParsingRegEx.Matches(coords);
                foreach (Match coordsMatch in coordsMatches)
                {
                    if (coordsMatch.Success)
                    {
                        var r = short.Parse(coordsMatch.Groups[2].Value);
                        var c = short.Parse(coordsMatch.Groups[3].Value);
                        display.Write(--r, --c, byte.MaxValue);
                    }
                }

            }
            else
            {
                mappingFor = char.MinValue;
                display = null;
            }
            return display;
        }
    }
}
