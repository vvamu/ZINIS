//using System;
//using System.Text;
//using static System.Net.Mime.MediaTypeNames;

//namespace BurrowsWheeler;

//class Program
//{
//    static void Main()
//    {
//        var binaryString = "";
//        foreach (var s in "вре")
//        {
//            binaryString += Convert.ToString(s, 2);
//        }
//        var tests = new string[] {
//            "надя",
//            "бичун",
//            "летоисчисление",
//             //binaryString
//        };

//        foreach (string test in tests)
//        {
            
//                var s = First(test);
//                Console.WriteLine();
//                SortStrings(ref s);
//                Console.WriteLine();
//                GetRusultMessage(s);
//                Operation(s);


//            Console.WriteLine("---------------------");
            


//            //Console.WriteLine("     " + test);
//            //Console.Write(" --> ");



//            //var r = Ibwt(t);
//            //Console.WriteLine(" --> {0}", r);
//            //Console.WriteLine();
//        }
//    }


//    static string[] First(string str)
//    {
//        Console.WriteLine("     " + str);
//        //var arr = str.ToArray();
//        //char buf;
//        var a = new string[str.Length];
//        a[0] = str;
//        for (int i = 1; i < str.Length; i++)
//        {
//            //a[i] = str;
//            //var e = str.Remove(1);
//            //str = str.Substring(1,str.Length);
//            var af = str.Substring(0, 1);
//            var e = str.Remove(0, 1);

//            str = e + af;
//            a[i] = str;
//        }

//        OutArray(a);

//        return a;

//    }

//    public static void OutArray(object[] s)
//    {
//        foreach (var ch in s)
//        {
//            Console.Write(" --> ");
//            Console.WriteLine(ch);
//        }
//    }


//    static void SortStrings(ref string[] strings)
//    {
//        strings = strings.OrderBy(x => x.Substring(0, x.Length)).ToArray();
//        OutArray(strings);


//    }

//    static string[] GetRusultMessage(string[] strings, string startMessage = "")
//    {
//        var r = new List<string>();
//        //int positionStartMessage = 0;

//        foreach (var ch in strings)
//        {
//            r.Add(ch.Substring(strings.Length - 1, 1));
//            //if(ch == startMessage)
//            // positionStartMessage = ch.in
//        }
//        return r.ToArray();

//    }

//    static void Operr(string[] strings)
//    {
//        var countSteps = strings[1].Length; //Like count letters
//        var countLettersInWord = strings[2].Length;
//        var outputMatrix = new string[strings.Length];



//        for (int ii = 0; ii < outputMatrix.Length; ii++) //step
//        {

//            while (outputMatrix[ii].Length == countLettersInWord)
//            {
//                outputMatrix[ii] += "0";
//            }




//            for (int i = 0; i < countSteps; i++)
//            {
//                var countLetters = countLettersInWord;
//                for (int j = 0; j < countLetters; j++)
//                {

//                }
//            }
//        }

//    }
//    static void Operation(string[] strings)
//    {
//        var strings2 = new string[strings.Length]; // новые строки

//        for (int k = 0; k < strings.Length; k++) //количество шагов k+1 - cколько надо вырезать или взять
//        {
//            var length = strings.Length;
//            int i = k + 1;

//            for (int g = 0; g < strings.Length; g++) //индекс строки
//            {

//                var b = strings[g].Substring(length - 1, 1); //take coding word

//                if (strings2[g] == null)
//                {
//                    int ind = 0;
//                    var str = "";
//                    while (ind != strings.Length)
//                    {
//                        str += 0;
//                        ind++;
//                    }
//                    strings2[g] = str;
//                }

//                var nuuuls = strings2[g].Substring(0, strings2[g].Length - k - 1);
//                var str2 = "";
//                if (k != 0)
//                    str2 = strings2[g].Substring(strings2[g].Length - k, k);


//                try
//                {
//                    nuuuls = strings2[g].Substring(0, strings2[g].Length - k - 1);
//                    str2 = strings2[g].Substring(strings2[g].Length - k, k);
//                }
//                catch { }



//                var res = nuuuls + b + str2;


//                //res += b + str2;
//                //Console.WriteLine("Str2 " + str2); Console.WriteLine("F " + f);


//                //if(i != 1) str += f;

//                //str += b;


//                Console.Write(res);
//                Console.WriteLine();
//                strings2[g] = res;


//            }
//            SortStrings(ref strings2);
//            Console.WriteLine();
//        }
//    }

//}


