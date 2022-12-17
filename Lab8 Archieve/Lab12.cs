//using NLog.Fluent;
//using System;

//Lab12();


//public partial class Program
//{
//    // a = b * q1 + k1
//    // b = k1 * q2 + k2
//    static int GCD(int a, int b)
//    {
//        if (a < b)
//        {
//            var k = a;
//            a = b;
//            b = k;
//        }
//        while (b != 0) //остаток 
//        {
//            Console.Write(a + " = " + b + " * x + ");
//            var t = b;
//            b = a % b; //k1
//            Console.WriteLine(b);
//            a = t;
//        }
//        return a;
//    }

//    public static bool IsPrime(int number)
//    {
//        for (int i = 2; i < number; i++)
//        {
//            if (number % i == 0)
//                return false;
//        }
//        return true;
//    }

//    static void Lab12()
//    {
//        var n1 = 450;
//        var n2 = 503;
//        PrimeNumbers(n2);
//        PrimeNumbers(n2, n1);




//        Console.WriteLine("Алгоритм Евклида");
//        Console.Write("A = ");
//        var a = Convert.ToInt32(Console.ReadLine());
//        Console.Write("B = ");
//        var b = Convert.ToInt32(Console.ReadLine());
//        Console.Write("С = ");
//        var с = Convert.ToInt32(Console.ReadLine());

//        int ab = GCD(a, b);
//        int abc = GCD(ab, с);

//        Console.WriteLine("Наибольший общий делитель чисел {0} и {1} равен {2}", a, b, ab);
//        Console.WriteLine("------");
//        Console.WriteLine("Наибольший общий делитель чисел {0} , {1} , {2} равен {3}", a, b, с, abc);

//        Console.WriteLine();
//        Console.WriteLine($"IsPrime({a.ToString() + b.ToString()}) " + IsPrime(Convert.ToInt32(a.ToString() + b.ToString())));
//        Console.WriteLine($"IsPrime({b.ToString() + a.ToString()}) " + IsPrime(Convert.ToInt32(b.ToString() + a.ToString())));
//        Console.ReadLine();






//    }

//    static void PrimeNumbers(int n2, int n1 = 0)
//    {
//        int countPrimeNumbers = 0;
//        for (int i = n1; i < n2; i++)
//        {
//            var element = i + 2;
//            if (IsPrime(element))
//            {
//                //Console.WriteLine(element + " - Prime"); 
//                countPrimeNumbers++;
//            }
//            //else Console.WriteLine(element + " - Not Prime");
//        }
//        Console.WriteLine($"{n1} - {n2}");
//        Console.WriteLine($"countPrimeNumbers - {countPrimeNumbers} \n {n2} / ln{n2} = {(float)Math.Log10(n2)}");
//        Console.WriteLine("-----------");

//    }

//    static void PrimeNumBySieveOfEratosthenes(int n2, int n1 = 0)
//    {
//        if (n2 < n1)
//        {
//            var k = n1;
//            n2 = n1;
//            n1 = k;
//        }
//        Range range = new Range(n1, n2);
//        //var nnn = range.ToString().Where(x=> Convert.ToInt32(x))
//        //ist<int> resList = new List<int>().AddRange();

//        for (int i = n1; i < n2; i++)
//        {

//            for (int j = n1 + 1; j < n2; j++)
//            {
//                //if (i % j == 0)

//            }
//        }

//    }

//}