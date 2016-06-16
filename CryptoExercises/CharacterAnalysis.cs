using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExercises
{
    class CharacterAnalysis
    {
        public Dictionary<char, float> CharacterFrequencyMap;
        public List<char> Letters;

        public CharacterAnalysis()
        {
            CharacterFrequencyMap = new Dictionary<char, float>()
            {
                {'A', 8.2F },
                {'B', 1.5F },
                {'C', 2.8F },
                {'D', 4.3F },
                {'E', 12.7F },
                {'F', 2.2F },
                {'G', 2.0F },
                {'H', 6.1F },
                {'I', 7.0F },
                {'J', 0.2F },
                {'K', 0.8F },
                {'L', 4.0F },
                {'M', 2.4F },
                {'N', 6.7F },
                {'O', 7.5F },
                {'P', 1.9F },
                {'Q', 0.1F },
                {'R', 6.0F },
                {'S', 6.3F },
                {'T', 9.1F },
                {'U', 2.8F },
                {'V', 1.0F },
                {'W', 2.4F },
                {'X', 0.2F },
                {'Y', 2.0F },
                {'Z', 0.1F },
            };

            Letters = new List<char>();
            Letters.Add('a');
            Letters.Add('b');
            Letters.Add('c');
            Letters.Add('d');
            Letters.Add('e');
            Letters.Add('f');
            Letters.Add('g');
            Letters.Add('h');
            Letters.Add('i');
            Letters.Add('j');
            Letters.Add('k');
            Letters.Add('l');
            Letters.Add('m');
            Letters.Add('n');
            Letters.Add('o');
            Letters.Add('p');
            Letters.Add('q');
            Letters.Add('r');
            Letters.Add('s');
            Letters.Add('t');
            Letters.Add('u');
            Letters.Add('v');
            Letters.Add('w');
            Letters.Add('x');
            Letters.Add('y');
            Letters.Add('z');

        }
        
    }
}
