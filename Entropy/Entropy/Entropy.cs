using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entropy
{

    public static partial class Entropya
    {
        public static Dictionary<string, string> alphabet = new Dictionary<string, string>()
        {
            ["Latin"] = "qwertyuiopasdfghjklzxcvbnm",
            ["Cyrillic"] = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
            ["Binary"] = "01",
            ["Base64"] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
        };

        public static string myName = "Бичун Надежда Дмитриевна";

        public static double ShennonAlphabetEntropyByFileName(string filename,string alphabetName = "Latin", float errorProbability = 0)
        {


            string thisAlphabet = DefineAlphabetByName(alphabetName);
            var entropy = Math.Log2(thisAlphabet.Length);
            var path = DefineFileByName(filename);

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                text = text.ToLower();
                var numberOfOccurrences = GetDictionaryByAlpabetName(alphabetName);


                foreach (var ch in text.Select((value, i) => new { i, value }))
                {
                    if (alphabet[alphabetName].Contains(ch.value))
                        numberOfOccurrences[ch.value]++;
                    else
                        text.Remove(ch.i);
                }

                double answer = 0;
                foreach (var ch in alphabet[alphabetName])
                {
                    if (numberOfOccurrences[ch] != 0)
                    {
                        double P = (double)numberOfOccurrences[ch] / (double)text.Length * (1 - errorProbability);
                        answer += P * Math.Log2(P);
                    }
                }
                return -answer;
            }
        }

        /*ChartlyEntropy if str == null and errorProb */
        public static double AlphabetEntropy(string alphabetName, string? str = null, float errorProbability = 0)
        {
            string thisAlphabet = DefineAlphabetByName(alphabetName);


            var entropy = Math.Log2(thisAlphabet.Length);

            //if we wont to get count info
            if (str != null)
            {
                return str.ToLower().Length * entropy;
            }

            if (errorProbability == 0)
                return entropy;
            if (errorProbability == 1)
                return 0;

            
            var numberOfOccurrences = GetDictionaryByAlpabetName(alphabetName);

            //ver1

            var path = DefineFileByName(thisAlphabet);

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                text = text.ToLower();

                foreach (var ch in text.Select((value, i) => new { i, value }))
                {
                    if (alphabet[alphabetName].Contains(ch.value))
                        numberOfOccurrences[ch.value]++;
                    else
                        text.Remove(ch.i);
                }

                double answer = 0;
                foreach (var ch in alphabet[alphabetName])
                {
                    if (numberOfOccurrences[ch] != 0)
                    {
                        double P = (double)numberOfOccurrences[ch] / (double)text.Length * (1 - errorProbability);
                        answer += P * Math.Log2(P);
                    }
                }
                return -answer;
            }


            return entropy;



        }

        public static double AlphabetEntropyByFile( string filename, string alphabetName = "Latin")
        {
            string thisAlphabet = DefineAlphabetByName(alphabetName);
            string text = GetTextFromFile(filename);

            return AlphabetEntropy(alphabetName, text);

        }

        public static Dictionary<char, int> GetDictionaryByAlpabetName(string alphabetName)
        {
            Dictionary<char, int> numberOfOccurrences = new Dictionary<char, int>();
            foreach (var ch in alphabet[alphabetName])
                numberOfOccurrences.Add(ch, 0);
            return numberOfOccurrences;
        }

        public static void frequency_Char(string alphabetName, string? str = null)
        {
            string thisAlphabet = "";
            Dictionary<char, double> result = new Dictionary<char, double>();
            str = str.ToLower();
            var lenght = str.Length;

            foreach (KeyValuePair<string, string> combi in alphabet)
            {
                if (combi.Key == alphabetName)
                    thisAlphabet = combi.Key;
            }

            Dictionary<char, int> numberOfOccurrences = new Dictionary<char, int>();
            foreach (var ch in alphabet[alphabetName])
                numberOfOccurrences.Add(ch, 0);

            var ap = alphabet[alphabetName];
            foreach (var ch in str.Select((value, i) => new { i, value }))
            {
                if (alphabet[alphabetName].Contains(ch.value))
                    numberOfOccurrences[ch.value]++;
                else
                    str.Remove(ch.i);
            }

            foreach (KeyValuePair<char, int> combi in numberOfOccurrences)
            {
                if (((int)combi.Value) != 0)
                    Console.WriteLine("P for " + combi.Key + $"({combi.Value}) - " + ((double)combi.Value / (double)lenght) * 100);

            }



        }

        public static string GetTextFromFile(string filename)
        {
            using (var stream = new StreamReader(filename))
            {

                return stream.ReadToEnd().ToLower();

            }

        }

        public static string DefineAlphabetByName(string alphabetName)
        {
            string thisAlphabet = String.Empty;
            foreach (KeyValuePair<string, string> combi in alphabet)
            {
                if (combi.Key == alphabetName)
                    thisAlphabet = combi.Key;
            }
            return thisAlphabet;
        }

        public static string DefineFileByName(string thisAlphabet)
        {
            if (thisAlphabet.Contains("."))
                return thisAlphabet;
            if (thisAlphabet != "Binary")
                return thisAlphabet + ".txt";
            else
                return thisAlphabet + ".bin";
        }






    }
}

