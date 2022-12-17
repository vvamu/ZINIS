//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.ComponentModel;
//using System.Data;
//using System.Drawing;


//namespace StatisticalMethods
//{
//    public class characterInfo
//    {
//        public string character;
//        public float probabilities;
//    }
//    class Program
//    {
//        const int mantisLenght = 4;
//        [STAThread]
//        static void Main(string[] args)
//        {
//            #region DefineText

//            Console.OutputEncoding = Encoding.UTF8;
//            Dictionary<string, float> valuePairs = new Dictionary<string, float>();

//            var text = "бичуннадеждадмитриевна";
//            #endregion




//            Console.WriteLine("бичуннадеждадмитриевна");
//            int countTc;
//            List<characterInfo> charactersInfo = CalculateProbability(text, out countTc);
//            valuePairs = charactersInfo.OrderByDescending(p => p.probabilities).ToDictionary(p => p.character, p => p.probabilities);

//            float probability = 0.0f;
//            foreach (var cI in valuePairs)
//            {
//                Console.WriteLine(cI.Key + ":" + cI.Value);
//                probability = (float)Math.Round(probability += cI.Value, mantisLenght);
//            }
//            Console.WriteLine("Сумма вероятностей: " + probability);

//            Shennona_Phano(valuePairs, "бичун");


//            for (int i = 0; i < 10; i++)
//                Console.WriteLine();
//            //----------------------------------
//            //----------------------------------
//            //Haffman
//            List<SingleBinaryTree> dictionaryNodes = new List<SingleBinaryTree>();
//            List<SingleBinaryTree> dictionaryNodesFix = dictionaryNodes;
//            foreach (var symbol in valuePairs)
//            {
//                dictionaryNodes.Add(new SingleBinaryTree() { Symbol = symbol.Key, Probability = symbol.Value });
//            }

//            ////Выведем наш словарь
//            //foreach (var node in dictionaryNodes)
//            //{
//            //    Console.WriteLine("Dictionary : " + node.Symbol + " : " + node.Probability);
//            //}

//            Console.WriteLine();
//            Console.WriteLine();
//            Console.WriteLine("- -- - -- -- - - -- -");
//            Console.WriteLine();
//            Console.WriteLine();

//            #region Haffman

//            //do
//            //{
//            //    dictionaryNodes = dictionaryNodes.OrderByDescending(p => p.Probability).ToList();

//            //    Console.WriteLine();
//            //    Console.WriteLine("Sorted");
//            //    foreach (var node in dictionaryNodes)
//            //    {
//            //        Console.WriteLine(node.Symbol + " : " + node.Probability);
//            //    }

//            //    //Берём два последних символа
//            //    SingleBinaryTree temp = new SingleBinaryTree();
//            //    temp.Symbol = "(" + dictionaryNodes[dictionaryNodes.Count - 1].Symbol + "," + dictionaryNodes[dictionaryNodes.Count - 2].Symbol + ")";
//            //    temp.Probability = (float)Math.Round(dictionaryNodes[dictionaryNodes.Count - 1].Probability + dictionaryNodes[dictionaryNodes.Count - 2].Probability, mantisLenght);

//            //    dictionaryNodes[dictionaryNodes.Count - 1].Code = "0";  //нижестоящее
//            //    dictionaryNodes[dictionaryNodes.Count - 2].Code = "1"; //вышестоящее

//            //    dictionaryNodes[dictionaryNodes.Count - 1].Parent = temp;
//            //    dictionaryNodes[dictionaryNodes.Count - 2].Parent = temp;

//            //    //Удаляем из текущего два последний и добаляем новый лист
//            //    dictionaryNodes.RemoveRange(dictionaryNodes.Count - 2, 2);
//            //    //
//            //    Console.WriteLine("удалили два");
//            //    foreach (var node in dictionaryNodes)
//            //    {
//            //        Console.WriteLine(node.Symbol + " : " + node.Probability);
//            //    }
//            //    dictionaryNodes.Add(temp);

//            //    Console.WriteLine("Добавили лист с суммой двух удаленных листов");
//            //    foreach (var node in dictionaryNodes)
//            //    {
//            //        Console.WriteLine(node.Symbol + " : " + node.Probability);
//            //    }

//            //} while (dictionaryNodes.Count != 1);

//            //Console.WriteLine("Получим коды наших символов");

//            //foreach (var node in dictionaryNodesFix)
//            //{
//            //    SingleBinaryTree tempNode;
//            //    string code = "";
//            //    tempNode = node;
//            //    do
//            //    {

//            //        code = tempNode.Code + code;
//            //        tempNode = tempNode.Parent;

//            //    } while (tempNode != null);
//            //    Console.WriteLine(node.Symbol + " : " + code);
//            //}
//            #endregion


//            Console.ReadKey();
//        }

//        public static List<characterInfo> CalculateProbability(string text, out int countTC)
//        {
//            List<characterInfo> charactersInfo = new List<characterInfo>();
//            List<string> characters = new List<string>();
//            int countCharacters = 0;
//            int countTextCharacters = 0;


//            foreach (char character in text)
//            {
//                if (character != '\r' && character != '\n')
//                {
//                    if (charactersInfo.Find(p => p.character == character.ToString()) == null)
//                        charactersInfo.Add(new characterInfo() { character = character.ToString() });
//                    countTextCharacters++;
//                }
//            }

//            for (int i = 0; i < charactersInfo.Count; i++)
//            {
//                countCharacters = 0;
//                countCharacters = text.Count(c => c == charactersInfo[i].character[0]);
//                charactersInfo[i].probabilities = (float)Math.Round(((double)countCharacters) / ((double)countTextCharacters), mantisLenght);
//            }
//            float lastProbability = 0.0f;
//            lastProbability = (float)Math.Round(lastProbability, mantisLenght);
//            for (int i = 0; i < charactersInfo.Count - 1; i++)
//            {
//                lastProbability = (float)Math.Round(lastProbability += charactersInfo[i].probabilities, mantisLenght);
//            }

//            charactersInfo[charactersInfo.Count - 1].probabilities = (float)Math.Round((float)Math.Round(1.0, mantisLenght) - lastProbability, mantisLenght);
//            countTC = countTextCharacters;
//            return charactersInfo;


//        }

//        static void Shennona_Phano(Dictionary<string, float> valuePairs, string message = "")
//        {
//            //Второй словарь хранящий кодировку символов
//            Dictionary<string, string> valuePairsCode = new Dictionary<string, string>();

//            //Словарь для выбора оптимальной пары групп
//            Dictionary<int, float> valuePairsDifference = new Dictionary<int, float>();

//            //начнем разбивать на группы
//            bool flag = false;
//            float currentProbability = 0.0f;
//            float prevProbability = 0.0f;
//            float prevDifferenceBetweenGroups = 100;
//            float currentDifferenceBetweenGroups = 100;
//            for (int i = 0; i < valuePairs.Count; i++)
//            {
//                currentProbability = 0.0f;
//                for (int j = 0; j < i + 1; j++)
//                {
//                    currentProbability = (float)Math.Round(currentProbability += valuePairs.ElementAt(j).Value, mantisLenght);

//                }
//                valuePairsDifference.Add(key: i + 1, value: (float)Math.Round(Math.Abs((1.0f - currentProbability) - currentProbability), 4));
//            }

//            foreach (var cI in valuePairsDifference)
//            {
//                //Console.WriteLine(cI.Key + ":" + cI.Value);

//            }
//            valuePairsDifference = valuePairsDifference.OrderBy(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
//            //Console.WriteLine("Сортировка: ");
//            foreach (var cI in valuePairsDifference)
//            {
//                //Console.WriteLine(cI.Key + ":" + cI.Value);

//            }

//            //-----
//            valuePairsCode = valuePairs.ToDictionary(p => p.Key, p => "");
//            CalculateCode(0, valuePairs.Count, valuePairs, valuePairsCode);

//            Console.WriteLine("ResultSymbols" + message);

//            int resultLength = 0;

//            foreach (var ch in valuePairsCode)
//            {
//                if (ch.Key == "р")
//                {
//                    Console.WriteLine("ValuePairCode " + "р" + " - " + ch.Value + "1");
//                }
//                else if (ch.Key == "в")
//                {
//                    Console.WriteLine("ValuePairCode " + "в" + " - " + ch.Value + "0");
//                }
//                else
//                    Console.WriteLine("ValuePairCode " + ch.Key + " - " + ch.Value);

//            }

//            message = "бичун";
//            Console.WriteLine("Result Message " + message);

//            string[] arr = new string[message.Length - 1];
//            for (int i = 0; i < arr.Length; i++)
//            {
//                arr[i] = message[i].ToString();

//            }

//            for (int i = 0; i < arr.Length; i++)
//            {

//                foreach (var ch in valuePairsCode)
//                {
//                    if (arr[i] == ch.Key)
//                    {
//                        if (ch.Key == "р")
//                        {
//                            Console.Write(ch.Value + "1" + " ");
//                        }
//                        else if (ch.Key == "в")
//                        {
//                            Console.Write(ch.Value + "0" + " ");
//                        }
//                        else
//                            Console.Write(ch.Value + " ");
//                        resultLength += ch.Value.Length;

//                        //break;
//                    }
//                }
//            }
//            Console.Write("110\n");

//foreach(var ch in arr)
//            {

//                Console.Write(ch + " ");
//            }
//            Console.Write("н ");

//            var eff1 = (float)((float)message.Length / (float)(resultLength + 4));
//            var eff2 = (float)((float)(message.Length / (float)(message.Length * 8)));


//            Console.WriteLine("\nПервоначальная длина - " + message.Length);
//            Console.WriteLine("Результирующая длина - " + (resultLength + 4) + "\tЭффективность сжатия - " + eff1);
//            Console.WriteLine("Длина при использовании ASCII (8 бит на символ) - " + (message.Length * 8) + "\tЭффективность сжатия - " + eff2);



//        }

//        static void CalculateCode(int start, int end, Dictionary<string, float> valuePairs, Dictionary<string, string> valuePairsCode)
//        {

//            Console.WriteLine("Рекурсия");
//            int separator = 0;
//            //Нам пришёл набор, нужно разделить его на две группы!
//            //Делим
//            //----------------------
//            //Словарь для выбора оптимальной пары групп
//            Dictionary<int, float> valuePairsDifference = new Dictionary<int, float>();

//            //начнем разбивать на группы

//            //Посчитаем суммарную вероятность группы
//            float sumGroupProbability = 0;
//            for (int i = start; i < end; i++)
//            {
//                sumGroupProbability = (float)Math.Round(sumGroupProbability += valuePairs.ElementAt(i).Value, mantisLenght);
//            }

//            Console.WriteLine("Суммарная вероятность группы: " + sumGroupProbability.ToString());
//            float currentProbability = 0.0f;
//            for (int i = start, ii = 0; i < end; i++, ii++)
//            {
//                currentProbability = 0.0f;
//                for (int j = 0; j < ii + 1; j++)
//                {
//                    currentProbability = (float)Math.Round(currentProbability += valuePairs.ElementAt(start + j).Value, mantisLenght);

//                }
//                valuePairsDifference.Add(key: ii + 1, value: (float)Math.Round(Math.Abs((sumGroupProbability - currentProbability) - currentProbability), mantisLenght));


//            }

//            foreach (var cI in valuePairsDifference)
//            {
//                //Console.WriteLine(cI.Key + ":" + cI.Value);

//            }
//            valuePairsDifference = valuePairsDifference.OrderBy(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
//            //Console.WriteLine("Сортировка: ");
//            foreach (var cI in valuePairsDifference)
//            {
//                //Console.WriteLine(cI.Key + ":" + cI.Value);

//            }

//            //-----------------------
//            separator = valuePairsDifference.ElementAt(0).Key;
//            separator += start;
//            //Заполняем 1 и 0
//            for (int i = start; i < separator; i++)
//            {
//                valuePairsCode[valuePairsCode.ElementAt(i).Key] += "1";
//            }

//            for (int i = separator; i < end; i++)
//            {
//                valuePairsCode[valuePairsCode.ElementAt(i).Key] += "0";
//            }

//            foreach (var cI in valuePairsCode)
//            {
//                Console.WriteLine(cI.Key + ":" + cI.Value);

//            }

//            if (separator - 1 - start > 0)
//            {
//                CalculateCode(start, separator, valuePairs, valuePairsCode);

//                if (end - 1 - separator > 0)
//                {
//                    CalculateCode(separator, end, valuePairs, valuePairsCode);
//                }
//            }

//        }

//        class SingleBinaryTree
//        {
//            string symbol = null;
//            float probability = 0.0f;
//            string code = null;
//            SingleBinaryTree left = null;
//            SingleBinaryTree right = null;
//            SingleBinaryTree parent = null;


//            public string Code { get => code; set => code = value; }
//            public float Probability { get => probability; set => probability = value; }
//            public string Symbol { get => symbol; set => symbol = value; }
//            internal SingleBinaryTree Left { get => left; set => left = value; }
//            internal SingleBinaryTree Right { get => right; set => right = value; }
//            internal SingleBinaryTree Parent { get => parent; set => parent = value; }
//        }
//    }
//}
