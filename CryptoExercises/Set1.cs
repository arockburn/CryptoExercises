using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using CryptoExercises.Models;

namespace CryptoExercises
{
    public class Set1
    {
        public const string Ex1StartString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
        public readonly string OutputFileDump = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\ProblemFiles\\4dump.txt";

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
            using (var writer = File.AppendText(OutputFileDump))
            {

                var ca = new CharacterAnalysis();
                var bytes = ConvertHexStringToByteArray(hex);
                var scores = new Dictionary<char, float>();
                var xorStrings = new Dictionary<char, string>();

                for (var i = 0; i < CharacterAnalysis.Letters.Count(); i++)
                {
                    var xorString = new char[bytes.Length];
                    var letterAsByte = Encoding.UTF8.GetBytes(CharacterAnalysis.Letters.Keys.ToList()[i].ToString());
                    for (var j = 0; j < bytes.Length; j++)
                    {
                        var tempChar = bytes[j] ^ letterAsByte[0];
                        var xorChar = Convert.ToChar(tempChar);
                        xorString[j] = xorChar;
                    }
                    var stringToAdd = new string(xorString);
                    Console.Write(stringToAdd);
                    xorStrings.Add(CharacterAnalysis.Letters.Keys.ToList()[i], stringToAdd);

                    var score = GetScoreForDecryptedString(new string(xorString));
                    Console.Write(score);
                    scores.Add(CharacterAnalysis.Letters.Keys.ToList()[i], (float)score);
                    
                    Console.Write("\n");

                    var ser = JsonConvert.SerializeObject(new StringScoreCharCount
                    {
                        CharAry = xorString,
                        Score = Convert.ToInt32(score),
                        CharCount = stringToAdd.Count(char.IsLetter)
                    });
                    
                    writer.WriteLine(ser);
                }

                char currWinner = default(char);
                foreach (var s in scores)
                {
                    if (currWinner == default(char))
                        currWinner = s.Key;
                    else
                        currWinner = scores[currWinner] < s.Value ? s.Key : currWinner;
                }

                var winningString = xorStrings[currWinner];
                Console.WriteLine(string.Format("The winning score was for the letter {0} with a score of {2}!\nHere is the winning string: {1}", currWinner, winningString, scores[currWinner]));
                return xorStrings[currWinner];
            }
        }



        public string FindEncryptedLineInFile(string path)
        {
            if (!File.Exists(OutputFileDump))
                File.Create(OutputFileDump);
            else
                File.WriteAllText(OutputFileDump, string.Empty);

            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                var line = "";
                while((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            
            var winner = "";
            var bestScore = 0.0;
            var winners = new List<string>();
            foreach(var line in lines)
            {
                var temp = SingleByteXORCipher(line);
                winners.Add(temp);
                var score = GetScoreForDecryptedString(temp);
                if(score > bestScore)
                {
                    winner = temp;
                    bestScore = score;
                }
                Console.WriteLine(string.Format("{0}\n\t\t\t\tVS.\n{1}\n{1} wins with score of: {2}", winner, temp, bestScore));
            }

            var scoresDict = SortDecryptedStringsByScore();
            var scores = scoresDict.Keys;
            var maxScore = scores.Max();
            var maxScoreList = scoresDict[maxScore];
            var maxScoreStrings = new List<string>();
            foreach(var charary in maxScoreList)
            {
                maxScoreStrings.Add(new string(charary));
            }

            Console.WriteLine($"The winning string is: {winner}");

            return winner;
        }

        private float GetScoreForDecryptedString(string s)
        {
            float score = 0.0f;

            for (var j = 0; j < s.Length; j++)
            {
                char temp;
                char currLetter = s[j];

                if (CharacterAnalysis.Letters.TryGetValue(s[j], out temp) || CharacterAnalysis.Letters.Values.Contains(s[j]))
                {
                    score += CharacterAnalysis.CharacterFrequencyMap[currLetter];
                    //score += 2;
                }
                else if (CharacterAnalysis.SpecialChars.Contains(currLetter))
                {
                    score += 1;
                }
            }

            return score;
        }

        public Dictionary<int, List<char[]>> SortDecryptedStringsByScore()
        {
            var scoresAndStrings = new Dictionary<int, List<char[]>>();
            
            using (var reader = File.OpenText(OutputFileDump))
            {
                var line = "";
                while((line = reader.ReadLine()) != null)
                {
                    StringScoreCharCount obj = JsonConvert.DeserializeObject<StringScoreCharCount>(line);

                    if (scoresAndStrings.ContainsKey(obj.Score))
                        scoresAndStrings[obj.Score].Add(obj.CharAry);
                    else
                        scoresAndStrings.Add(obj.Score, new List<char[]> { obj.CharAry});
                }
            }
            
            return scoresAndStrings;
        }
    }
}
