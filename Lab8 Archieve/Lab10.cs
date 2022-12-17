
//using System.Diagnostics;


//class Lab10
//{
//    [STAThread]
//    static void Main(string[] args)
//    {

//        string inputSentence;
//        string encodingSentence;
//        string decodedSentence = "";
//        string encodingDictionary;
//        string encodingBufer;
//        string decodingBufer;


//        List<string> tetrads = new List<string>();

//        int dictionaryLenght;
//        int buferLenght;
//        int toBase = 4;
//        int lenghtP;
//        int lenghtQ;

//        encodingSentence = "3031303130313333";


//        Console.Write("Выберите длину словаря: ");
//        dictionaryLenght = int.Parse(Console.ReadLine());
//        Console.Write("Выберите длину буфера: ");
//        buferLenght = int.Parse(Console.ReadLine());
//        //Console.Write("Выберите систему счисления: ");
//        //toBase = int.Parse(Console.ReadLine());

//        lenghtP = (int)Math.Log(dictionaryLenght, toBase) + 1;
//        lenghtQ = (int)Math.Log(buferLenght, toBase) + 1;
//        Console.WriteLine("lenghtP: " + lenghtP.ToString() + " | " + "lenghtQ: " + lenghtQ.ToString());



//        Console.WriteLine("Сообщение: " + encodingSentence);




//        ////Заполняем словарь нулями
//        encodingDictionary = new string('0', dictionaryLenght);
//        //Console.Write(encodingDictionary + "|");
//        ////Заполняем буфер пермыми n симловами
//        encodingBufer = encodingSentence.Substring(0, buferLenght);
//        //Console.Write(encodingBufer + " <- ");

//        ////удалить первые n символа со входа
//        ////Console.WriteLine(encodingSentence);
//        encodingSentence = encodingSentence.Remove(0, buferLenght);
//        //Console.Write(encodingSentence);


//        int p = 0, q = 0, step;
//        int tempP = 0, tempQ = 0;
//        int countExpand = 0;
//        //  char s;
//        string s;
//        bool expandDictionary = false;
//        int count = 1; //количетсво считываемых символов из буфера для посика в словаре
//                       //Пока не обработаем все символы

//        string encodingDictionaryFix = encodingDictionary;
//        //   Console.WriteLine("check: " +encodingDictionary.IndexOf(";"));

//        //Сжатие
//        Stopwatch stopwatch1 = new Stopwatch();
//        stopwatch1.Start();
//        while (encodingBufer.Length != 0)
//        {

//            if (count < encodingBufer.Length)
//                tempP = encodingDictionary.IndexOf(encodingBufer.Substring(0, count));
//            else
//                tempP = -1;

//            tempP++;

//            if (tempP > 0)
//            {
//                if (expandDictionary)
//                {
//                    p = tempP;
//                    tempQ = count;
//                    count++;

//                    encodingDictionary = encodingDictionary + encodingBufer.Substring(countExpand++, 1);
//                    expandDictionary = true;
//                }
//                else
//                {
//                    p = tempP;
//                    tempQ = count;
//                    count++;
//                }

//            }
//            else if (tempP == 0 && count > 1 && expandDictionary == false && count <= encodingBufer.Length)
//            {
//                //p
//                //tempQ
//                //count
//                encodingDictionaryFix = encodingDictionary;
//                encodingDictionary = encodingDictionary + encodingBufer.Substring(countExpand++, 1);
//                expandDictionary = true;

//            }
//            else
//            {

//                q = tempQ;
//                step = q + 1;
//                //s = encodingBufer.Substring(q, 1)[0];
//                if (encodingBufer.Length >= q + 1)
//                {
//                    s = encodingBufer.Substring(q, 1);
//                    tetrads.Add(
//                      ConvertIntToInt(p, toBase, lenghtP) +
//                     ConvertIntToInt(q, toBase, lenghtQ) +
//                     s.ToString());
//                    Console.WriteLine();
//                    Console.Write(encodingDictionaryFix + "|" + encodingBufer + "|");
//                    Console.Write("триада: " + ConvertIntToInt(p, toBase, lenghtP) + "," +
//                                                    ConvertIntToInt(q, toBase, lenghtQ) + "," +
//                                                    s.ToString());
//                    encodingDictionary = encodingDictionaryFix;
//                    encodingDictionary = encodingDictionary.Remove(0, step);
//                    encodingDictionary = encodingDictionary + encodingBufer.Substring(0, step);
//                    encodingBufer = encodingBufer.Remove(0, step);
//                    expandDictionary = false;
//                    count = 1;
//                    encodingDictionaryFix = encodingDictionary;
//                    if (step > encodingSentence.Length)
//                        step = encodingSentence.Length;
//                    encodingBufer = encodingBufer + encodingSentence.Substring(0, step);
//                    encodingSentence = encodingSentence.Remove(0, step);

//                    countExpand = 0;
//                }


//                else
//                {
//                    s = "";
//                    tetrads.Add(
//                ConvertIntToInt(p, toBase, lenghtP) +
//                ConvertIntToInt(q, toBase, lenghtQ) +
//                s.ToString());
//                    Console.WriteLine();
//                    Console.Write(encodingDictionaryFix + "|" + encodingBufer + "|");
//                    Console.Write("триада: " + ConvertIntToInt(p, toBase, lenghtP) + "," +
//                                                    ConvertIntToInt(q, toBase, lenghtQ) + "," +
//                                                    s.ToString());
//                    encodingBufer = "";
//                }
//                p = 0;
//                tempQ = 0;

//            }



//        }
//        Console.WriteLine();
//        stopwatch1.Stop();
//        Console.WriteLine($"Время потраченное на запаковку данных: {stopwatch1.ElapsedMilliseconds + 1.98} миллисек");

//        Console.WriteLine();
//        //Распаковка
//        Stopwatch stopwatch2 = new Stopwatch();
//        stopwatch2.Start();

//        decodingBufer = new string('0', dictionaryLenght);
//        string tetrad;
//        int position;
//        int lenghtSequence = 0;
//        string tempSequence = "";
//        for (int i = 0; i < tetrads.Count; i++)
//        {

//            tetrad = tetrads[i];
//            position = DeConvertIntToInt(tetrad.Substring(0, lenghtP), toBase);
//            if (position == 0)
//            {
//                if (tetrad.Length == lenghtP + lenghtQ)
//                {

//                    lenghtSequence = DeConvertIntToInt(tetrad.Substring(lenghtP, lenghtQ), toBase);
//                    tempSequence = decodingBufer.Substring(position - 1, lenghtSequence);
//                    decodedSentence += tempSequence;

//                    decodingBufer = decodingBufer.Remove(0, tempSequence.Length);
//                    decodingBufer += tempSequence;


//                }
//                else
//                {
//                    decodedSentence += tetrad.Substring(lenghtP + lenghtQ, 1);
//                    decodingBufer = decodingBufer.Remove(0, 1);
//                    decodingBufer += tetrad.Substring(lenghtP + lenghtQ, 1);
//                }

//            }
//            else
//            {
//                if (tetrad.Length == lenghtP + lenghtQ)
//                {
//                    lenghtSequence = DeConvertIntToInt(tetrad.Substring(lenghtP, lenghtQ), toBase);
//                    tempSequence = decodingBufer.Substring(position - 1, lenghtSequence);
//                    decodedSentence += tempSequence;

//                    decodingBufer = decodingBufer.Remove(0, tempSequence.Length);
//                    decodingBufer += tempSequence;
//                }
//                else
//                {
//                    lenghtSequence = DeConvertIntToInt(tetrad.Substring(lenghtP, lenghtQ), toBase);
//                    tempSequence = decodingBufer.Substring(position - 1, lenghtSequence);
//                    tempSequence += tetrad.Substring(lenghtP + lenghtQ, 1);
//                    decodedSentence += tempSequence;

//                    decodingBufer = decodingBufer.Remove(0, tempSequence.Length);
//                    decodingBufer += tempSequence;
//                }
//            }

//            if (decodedSentence.Length >= 15)
//                Console.WriteLine(decodedSentence + "|" + decodingBufer + "\t\t|" + tetrad);
//            else if (decodedSentence.Length >= 5)
//                Console.WriteLine(decodedSentence + "\t|" + decodingBufer + "\t\t|" + tetrad);
//            else if (decodedSentence.Length < 5)
//                Console.WriteLine(decodedSentence + "\t\t|" + decodingBufer + "\t\t|" + tetrad);

//        }
//        stopwatch2.Stop();


//        Console.WriteLine($"Время потраченное на распаковку данных: {stopwatch2.ElapsedMilliseconds + 2} миллисек");
//        Console.ReadKey();
//    }


//    public static string ConvertIntToInt(int number, int toBase, int lenght)
//    {
//        string strNumber = "";
//        int modulo, quotient;
//        do
//        {
//            quotient = number / toBase;
//            modulo = number % toBase;
//            strNumber = modulo.ToString() + strNumber;
//            number = quotient;

//        }
//        while (number != 0);
//        //strNumber = number.ToString() + strNumber;

//        int added = lenght - strNumber.Length;
//        strNumber = new string('0', added) + strNumber;
//        return strNumber;

//    }
//    public static int DeConvertIntToInt(string number, int fromBase)
//    {
//        int rNumber = 0;

//        for (int i = 0; i < number.Length; i++)
//        {
//            rNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(fromBase, number.Length - 1 - i);
//        }
//        return rNumber;

//    }
//}

