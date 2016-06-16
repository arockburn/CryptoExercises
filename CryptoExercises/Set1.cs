﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExercises
{
    public class Set1
    {
        public const string Ex1StartString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";

        public string ConvertHexStringToBase64(string hexString)
        {
            Console.WriteLine($"Converting {hexString} from Hex to Base64.");
            
            var bytes = new Byte[hexString.Length / 2];
            for(int i = 0; i < hexString.Length; i+=2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i ,2), 16);
            }

            var convertedString = Convert.ToBase64String(bytes);
            

            return convertedString;
        }

        private Byte[] ConvertHexStringToByteArray(string hex)
        {
            //nifty LINQ conversion method found: http://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array
            return Enumerable.Range(0, hex.Length)
                                       .Where(x => x % 2 == 0)
                                       .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                       .ToArray();
        }

        private string ConvertByteArrayToHex(Byte[] ary)
        {
            var str = BitConverter.ToString(ary);
            return str.Replace("-", "");
        }

        public string XOR2HexStrings(string hex1, string hex2)
        {
            var bytes1 = ConvertHexStringToByteArray(hex1);
            var bytes2 = ConvertHexStringToByteArray(hex2);

            var xorBytes = new Byte[bytes1.Length];

            for(int i = 0; i < bytes1.Length; i++)
            {
                xorBytes[i] = (byte)(bytes1[i] ^ bytes2[i]);
            }

            return ConvertByteArrayToHex(xorBytes);
        }

        public string SingleByteXORCipher(string hex)
        {
            var bytes = ConvertHexStringToByteArray(hex);
            var scores = new Dictionary<char, float>();
            var xorStrings = new Dictionary<char, string>();

            for(var i = 0; i < CharacterAnalysis.Letters.Count(); i++)
            {
                var xorString = new char[bytes.Length];
                var letterAsByte = Convert.ToByte(CharacterAnalysis.Letters[i]);
                for(var j = 0; j < bytes.Length; j++)
                {
                    var xorChar = Convert.ToChar(j ^ letterAsByte);
                    Console.Write(xorChar);
                    xorString[j] = xorChar;
                }

                xorStrings.Add(CharacterAnalysis.Letters[i], xorString.ToString());

                Console.Write("\t");

                var score = 0.0;
                
                for (var j = 0; j < xorString.Length; j++)
                {
                    var standardFreq = CharacterAnalysis.CharacterFrequencyMap[xorString[j]];
                    var currFreq = Math.Round(((float)xorString.Length / (float)bytes.Length) * 100, 1);
                    score += Math.Abs(standardFreq - currFreq);
                }

                Console.Write(score);
                scores.Add(CharacterAnalysis.Letters[i], (float)score);
                
                
                Console.Write("\n");

            }

            char currWinner = default(char);
            foreach(var s in scores)
            {
                if (currWinner == default(char))
                    currWinner = s.Key;
                else
                    currWinner = scores[currWinner] < s.Value ? s.Key : currWinner;
            }

            Console.WriteLine($"The winning score was for the letter {currWinner}!\nHere is the winning string: {xorStrings[currWinner]}\n");
            return xorStrings[currWinner];
        }
        
    }
}