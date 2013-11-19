using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sense.Core;
using System.Text.RegularExpressions;

namespace Sense.Server.InputProvider
{
    public class BrailleInputProvider : IInputProvider
    {
        public static class CharacterMap
        {
            static Dictionary<char, Display> _Mapping = new Dictionary<char,Display>();

            static public void LoadFromFile(string filename)
            {
                var lines = System.IO.File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    char mappingFor = default(char);
                    var display = ParseLine(line, out mappingFor);
                    if (display != Default)
                    {
                        _Mapping[mappingFor] = display;                        
                    }
                }
            }

            private static Regex LineParsingRegEx = new Regex(@"^(\w)\W*=\W*((\d+\W*,\W*\d+;?\W*)+)$", RegexOptions.Compiled);
            private static Regex CoordinateParsingRegEx = new Regex(@"((\d+)\W*,\W*(\d+))", RegexOptions.Compiled);

            static public Display MappingFor(char c)
            {
                var key = char.ToLower(c);
                return _Mapping.ContainsKey(key) ? _Mapping[key] : Default;
            }

            static public Display Default = new Display(3, 2);
            static private Display ParseLine(string line, out char mappingFor)
            {
                Display display = new Display(3,2);
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
                    display = Default;
                }
                return display;
            }
        }

        public string Text = "ABCDEFG";

        public BrailleInputProvider()
        {

        }


        public byte[] GetInput()
        {
            if(!string.IsNullOrWhiteSpace(Text))
            {
                var display = CharacterMap.MappingFor(Text.First());
                Text = Text.Substring(1);
                return display.Contents;
            }
            return null;
        }
    }
}
