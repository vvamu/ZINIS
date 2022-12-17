using System;






namespace ЛР__5
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            do
            {
                Console.Clear();
                Console.Write("Введите строку (не менее трех символов) = ");
                str = Console.ReadLine();
            }
            while (str.Length < 3);


            Console.WriteLine("Введите k1 (количество строк)"); int k1 = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Введите k2 (количество столбцов)"); int k2 = Convert.ToInt32(Console.ReadLine());
            var first = str;


            if (str.Length < k1 * k2)
                while(str.Length != k1 * k2)
                {
                    var ss = "0"; ss += str;
                    str = ss;   
                }   
            else
            {
                Console.WriteLine("Нельзя получить"); return;
                return;
            }
                



            int k = str.Length;
            int r = LenghtHemminga(k);
            int n = k + r;

            int[] mas = new int[str.Length + r];
            int[,] checkMatrix = new int[n, r];

            int error;


            //Преобразование строки в массив
            mas = StrInMas(str, k);
            Console.Write("\nВходная строка = "); /*OutMass(mas, k);*/
            Console.WriteLine(str + " | " + "0000");

            //---------------------

            var checkmatrrr = ReturnMatrixxx(mas, k1, k2);

            Console.Write("Horizontal Paritet : ");
            var horiz = HorizontalParitet(checkmatrrr);

            string paritets = "";
            foreach (var h in horiz)
            {
                paritets += h.ToString();
                Console.Write(h.ToString());
            }

            Console.Write(" Vertical Paritet: ");
            var vert = VerticalParitet(checkmatrrr);
            //OutMass(vert);


            foreach (var h in vert)
            {
                paritets += h.ToString();
                Console.Write(h.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Result str:");
            Console.WriteLine(first + " | " + paritets);
            //Получение проверочной матрицы
            checkMatrix = CheckMatrix(k);


            
            string strr;
            try
            {
                Console.WriteLine("--------------------\n");
                Console.WriteLine("Введите место первой ошибки");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                var arr = str.ToCharArray();
                if (arr[error] == '1') arr[error] = '0';
                else arr[error] = '1';

                var s = "";


                foreach (var a in arr)
                {
                    s += a;
                }

                var mmas = StrInMas(s, k);
                var ck = ReturnMatrixxx(mmas, k1, k2);

                #region paritets

                Console.Write("Horizontal Paritet : ");
                var horiz1 = HorizontalParitet(ck);

                string paritets1 = "";
                foreach (var h in horiz1)
                {
                    paritets1 += h.ToString();
                    Console.Write(h.ToString());
                }

                Console.Write(" Vertical Paritet: ");
                var vert1 = VerticalParitet(ck);

                foreach (var h in vert1)
                {
                    paritets1 += h.ToString();
                    Console.Write(h.ToString());
                }

                #endregion

                Console.WriteLine("\nResult str:");
                Console.WriteLine(s + " | " + paritets1);


                CheckVertParitets(vert, vert1);
                CheckHorizParitets(horiz, horiz1);
                Console.WriteLine();
                Console.WriteLine("Correcting: ");
                Console.WriteLine(first + " | " + paritets);




                Console.WriteLine("----------");
                Console.WriteLine("Введите место второй ошибки\n");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                var arr2 = s.ToCharArray();
                if (arr2[error] == '1') arr2[error] = '0';
                else arr2[error] = '1';


                var s2 = "";
                foreach (var a in arr2)
                {
                    s2 += a;
                }

                var mmas2 = StrInMas(s2, k);
                var ck2 = ReturnMatrixxx(mmas2, k1, k2);

                #region paritets

                Console.Write("Horizontal Paritet : ");
                var horiz2 = HorizontalParitet(ck2);

                string paritets2 = "";
                foreach (var h in horiz2)
                {
                    paritets2 += h.ToString();
                    Console.Write(h.ToString());
                }

                Console.Write(" Vertical Paritet: ");
                var vert2 = VerticalParitet(ck2);

                foreach (var h in vert2)
                {
                    paritets2 += h.ToString();
                    Console.Write(h.ToString());
                }

                #endregion

                Console.WriteLine("\nResult str:");
                Console.WriteLine(s2 + " | " + paritets2);

                int[] resSTR2 = new int[s2.Length];
                if(CheckVertParitets(vert, vert2).Count == CheckHorizParitets(horiz, horiz2).Count)
                {
                    resSTR2 = StrInMas(s2,k);
                    Console.WriteLine("Correct is not responce");

                }
                

            }
            catch {
                Console.WriteLine("Error");
            }


        }

        private static List<int> CheckVertParitets(int[] vert, int[] vert1)
        {
            List<int> errors = new List<int>(); 
            for (int i = 0; i < vert.Length; i++)
            {
                if (vert[i] != vert1[i])
                {

                    Console.WriteLine("Vert error :" + (i + 1));
                    errors.Add(i);
                }
            }
            return errors;
        }

        private static List<int> CheckHorizParitets(int[] horiz, int[] horiz1)
        {
            List<int> errors = new List<int>();
            for (int i = 0; i < horiz.Length; i++)
            {
                if (horiz[i] != horiz1[i])
                {
                    
                    Console.WriteLine("Horiz error :" + (i + 1));
                    errors.Add(i);
                }
            }
            return errors;
        }

        private static void OutMass(int[] mas)
        {
            foreach (var m in mas)
                Console.Write(m);
        }

        public static int[,] ReturnMatrixxx(int[] m, int k1,int k2)
        {
            var mm = new ArraySegment<int>(m, 0, k1 * k2);
            var arr = mm.ToArray();
            int[,] result = new int[k1,k2] ;

            int wordPosition = 0;

            for (int stroka = 0; stroka < k1; stroka++)
            {
                for (int stolbez = 0; stolbez < k2; stolbez++)
                {                       
                    result[stroka, stolbez] = arr[wordPosition];
                    Console.Write(result[stroka, stolbez]);

                    wordPosition++;                 
                   
                }
                Console.WriteLine();
            }
                
            
            return result ;



        }

        public static int[] HorizontalParitet(int[,] matrix)
        {
            int heigh = matrix.GetUpperBound(0) + 1;
            int weight = matrix.Length / heigh;

            int[] matrr = new int[weight];
            for(int w = 0; w < weight; w++)
            {
                int result = 0;
                for (int a = 0;a< heigh; a++)
                {
                    
                        if (result == 1 && matrix[a,w] == 1)
                            result = 0;
                        else
                            result += matrix[a,w];


                }
                matrr[w] = result;

            }

            return matrr;
        }

        public static int[] VerticalParitet(int[,] matrix)
        {
            int heigh = matrix.GetUpperBound(0) + 1;
            int weight = matrix.Length / heigh;

            int[] matrr = new int[weight];
            for (int w = 0; w < weight; w++)
            {
                int result = 0;
                for (int a = 0; a < heigh; a++)
                {

                    if (result == 1 && matrix[w, a] == 1)
                        result = 0;
                    else
                        result += matrix[w, a];


                }
                matrr[w] = result;

            }



            return matrr;
        }

        //Считаем r (кол-во пров. симв.)
        public static int LenghtHemminga(int k)
        {
            int r = (int)(Math.Log(k, 2) + 2.99f);
            return r;
        }

        //Создание пров. матрицы
        public static int[,] CheckMatrix(int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;
            int[,] mas = new int[n, r];


            double rDouble = r - 1;
            int rPow = (int)(Math.Pow(2, rDouble));

            int[,] combinations = new int[rPow, r];

            //все заполняем нулями
            for (int i = 0; i < rPow; i++)
                for (int j = 0; j < r; j++)
                    combinations[i, j] = 0;

            //генератор бит.мн.
            for (int segmentLenght = 0; segmentLenght < r - 2; segmentLenght++)
            {

                for (int i = 0; i < segmentLenght + 2; i++)
                {
                    combinations[segmentLenght * (r - 1), i] = 1;
                }

                for (int segmentPositin = 1; segmentPositin < r - 1; segmentPositin++)
                {

                    for (int i = 0; i < r - 2; i++)
                    {
                        combinations[segmentLenght * (r - 1) + segmentPositin, i + 1] = combinations[segmentLenght * (r - 1) + segmentPositin - 1, i];
                    }
                    combinations[segmentLenght * (r - 1) + segmentPositin, 0] = combinations[segmentLenght * (r - 1) + segmentPositin - 1, r - 2];
                }

                //Заполнение посл. сроки 1-ми
                if (segmentLenght == r - 2)
                {
                    for (int i = 0; i < r; i++)
                    {
                        combinations[rPow - 1, i] = 1;
                    }
                }
            }
            for (int i = 0; i < k; i++)
            {
                int amount = 0;
                for (int j = 0; j < r - 1; j++)
                {
                    if (combinations[i, j] == 1) amount++;
                }
                if (amount % 2 == 0)
                    combinations[i, r - 1] = 1;
            }


            for (int i = 0; i < k; i++)
                for (int j = 0; j < r; j++)
                    mas[i, j] = combinations[i, j];

            for (int i = 0; i < r; i++)
                mas[i + k, i] = 1;

            return mas;
        }

        //Поиск синдрома
        public static int[] Sindrom(int[,] CheckMatrix, int[] mas, int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;
            int[] sindrom = new int[r];

            for (int i = 0, l = 0; i < r; i++, l = 0)
            {
                for (int j = 0; j < k; j++)
                {
                    if (CheckMatrix[j, i] == 1 && mas[j] == 1) l++;
                    else sindrom[i] = 0;
                }
                if (l % 2 == 1) sindrom[i] = 1;
                else sindrom[i] = 0;
            }

            for (int i = 0; i < r; i++)
            {
                mas[i + k] = sindrom[i];
            }

            return mas;
        }

        //Нахождение ошибок
        public static int[] SearchError(int[] mas, int[,] checkMatrix, int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;

            int[] beforeSindrom = new int[r];

            //запоминаем проверочные биты
            for (int i = k; i < n; i++)
            {
                beforeSindrom[i - k] = mas[i];
            }

            mas = Sindrom(checkMatrix, mas, k);

            //Складываем синдром по модулю два
            for (int i = k, j = 0; i < n; i++)
            {
                if (beforeSindrom[i - k].Equals(mas[i]))
                {
                    mas[i] = 0;

                    j++;
                    //если сумма по модулю два все пров. бит равны нулю
                    if (j == r)
                    {
                        for (int l = k; l < n; l++)
                        {
                            mas[l] = beforeSindrom[l - k];
                        }
                        Console.WriteLine("Ошибок нет");
                        return mas;
                    }
                }
                else
                {
                    mas[i] = 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                for (int j = 0; j < r; j++)
                {
                    if (checkMatrix[i, j].Equals(mas[j + k])) l++;
                }
                if (l == r)
                {
                    mas[i] = (mas[i] + 1) % 2;
                }
                if (l != r && i == n - 1)
                {
                    Console.WriteLine("Ошибок кратно 2 и они исправлены неправильно");
                }
            }
            mas = Sindrom(checkMatrix, mas, k);

            return mas;
        }

        //Преобразование строки в массив
        public static int[] StrInMas(string str, int k)
        {
            int r = LenghtHemminga(k);
            int[] mas = new int[str.Length + r];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 49)
                    mas[i] = 1;
                else mas[i] = 0;
            }
            return mas;
        }

        //вывод матрицы
        public static void OutMass(int[,] mas, int k)
        {
            int r = LenghtHemminga(k);
            int n = r + k;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[j, i]);
                    if (j + 1 == k) Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        //вывод одномерного массива
        public static void OutMass(int[] mas, int k)
        {
            int n = LenghtHemminga(k) + k;

            for (int i = 0; i < n; i++)
            {
                if (i == k) Console.Write("|");
                Console.Write(mas[i]);
            }
            Console.WriteLine("\n");
        }

        public static void OutMass(int[] mas, int k , string str="")
        {
            int n = LenghtHemminga(k) + k;

            for (int i = 0; i < n; i++)
            {
                if (i == k) {Console.Write("|");break;}
                Console.Write(mas[i]);
            }
            //Console.WriteLine("\n");
        }
    }

}
