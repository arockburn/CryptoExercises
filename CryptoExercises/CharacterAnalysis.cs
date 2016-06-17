using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExercises
{
    class CharacterAnalysis
    {
        public static Dictionary<char, float> CharacterFrequencyMap;
        public static List<char> Letters;

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
                {'a', 8.2F },
                {'b', 1.5F },
                {'c', 2.8F },
                {'d', 4.3F },
                {'e', 12.7F },
                {'f', 2.2F },
                {'g', 2.0F },
                {'h', 6.1F },
                {'i', 7.0F },
                {'j', 0.2F },
                {'k', 0.8F },
                {'l', 4.0F },
                {'m', 2.4F },
                {'n', 6.7F },
                {'o', 7.5F },
                {'p', 1.9F },
                {'q', 0.1F },
                {'r', 6.0F },
                {'s', 6.3F },
                {'t', 9.1F },
                {'u', 2.8F },
                {'v', 1.0F },
                {'w', 2.4F },
                {'x', 0.2F },
                {'y', 2.0F },
                {'z', 0.1F }
            };

            Letters = new List<char>()
            {
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z'
            };

        }
        
    }
}
