using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1 = new Set1();

            //Ex 1
            //Console.WriteLine(set1.ConvertHexStringToBase64(Set1.Ex1StartString));

            //Ex 2
            //var xorResult = set1.XOR2HexStrings("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965");
            //Console.WriteLine(xorResult);

            //Ex 3
            var result = set1.SingleByteXORCipher("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736");
        }
    }
}
