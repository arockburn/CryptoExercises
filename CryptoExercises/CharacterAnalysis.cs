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
        public static Dictionary<char, char> Letters;
        public static List<char> SpecialChars;

        public CharacterAnalysis()
        {
            CharacterFrequencyMap = new Dictionary<char, float>()
            {
                {'A', 4F },
                {'B', 2F },
                {'C', 3F },
                {'D', 3F },
                {'E', 4F },
                {'F', 2F },
                {'G', 2F },
                {'H', 3F },
                {'I', 4F },
                {'J', 1F },
                {'K', 1F },
                {'L', 3F },
                {'M', 2F },
                {'N', 4F },
                {'O', 4F },
                {'P', 2F },
                {'Q', 1F },
                {'R', 3F },
                {'S', 3F },
                {'T', 4F },
                {'U', 3F },
                {'V', 1F },
                {'W', 2F },
                {'X', 1F },
                {'Y', 2F },
                {'Z', 1F },
                {'a', 4F },
                {'b', 2F },
                {'c', 3F },
                {'d', 3F },
                {'e', 4F },
                {'f', 2F },
                {'g', 2F },
                {'h', 3F },
                {'i', 4F },
                {'j', 1F },
                {'k', 1F },
                {'l', 3F },
                {'m', 2F },
                {'n', 4F },
                {'o', 4F },
                {'p', 2F },
                {'q', 1F },
                {'r', 3F },
                {'s', 3F },
                {'t', 4F },
                {'u', 3F },
                {'v', 1F },
                {'w', 2F },
                {'x', 1F },
                {'y', 2F },
                {'z', 1F }
            };

            Letters = new Dictionary<char, char>()
            {
                { 'A','a'},
                { 'B','b'},
                { 'C','c'},
                { 'D','d'},
                { 'E','e'},
                { 'F','f'},
                { 'G','g'},
                { 'H','h'},
                { 'I','i'},
                { 'J','j'},
                { 'K','k'},
                { 'L','l'},
                { 'M','m'},
                { 'N','n'},
                { 'O','o'},
                { 'P','p'},
                { 'Q','q'},
                { 'R','r'},
                { 'S','s'},
                { 'T','t'},
                { 'U','u'},
                { 'V','v'},
                { 'W','w'},
                { 'X','x'},
                { 'Y','y'},
                { 'Z','z' }
            };
            

            SpecialChars = new List<char>
            {
                '?',
                '/',
                '\'',
                '\"',
                ',',
                '.',
                '!',
                '\n',
                '\r',
                '\t',
                ' '
            };
        }
        
    }
}
