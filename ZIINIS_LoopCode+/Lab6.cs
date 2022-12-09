/*

string Xk = "10000000111";
string Xr = "11001";

int k = Xk.Length;
int n = 15;
int r = n - k;

int error;

int[] masXk = new int[k];
Calculator.StrInMas(masXk, Xk);

int[] masXr = new int[Xr.Length];
Calculator.StrInMas(masXr, Xr);

var XXr = masXr;

Console.WriteLine("Входная строка: " + Xk);
Console.WriteLine("Порождающий полином: " + Xr);
Console.WriteLine("k = {0} - длина строки, r = log2({0})+1 = {1}, n = r + k = {2}", k, r, n);
Console.WriteLine("Порождающая матрица k - строк, r - столбцов");


int[,] generationMatrix = new int[k, n];
Calculator.CreateGenerationMatrix(generationMatrix, masXr, k, n);

Console.WriteLine("\nПорождающая матрица");
Calculator.OutMatrix(generationMatrix, k, n);

Calculator.CreateCanonicalMatrix(generationMatrix, k, n);

Console.WriteLine("\nКаноническая матрица");
Calculator.OutMatrix(generationMatrix, k, n);

int[,] checkMatrix = new int[n, r];
Calculator.CreateCheckMatrix(checkMatrix, generationMatrix, k, n);

Console.WriteLine("\nПроверочная матрица");
Calculator.OutMatrix(checkMatrix, n, r);
//6.2

//Console.WriteLine();
//Calculator.SHOW_MYCHECKMATRIX(checkMatrix,k,n);

int[] masXn = new int[n];
Calculator.Shift(masXn, masXk, r);

//2.
Console.WriteLine("\nДеление");
Console.WriteLine("Первоначальный полином: "); Calculator.OutMass(masXr); Calculator.OutMass(masXn); Console.WriteLine("-------------------------");
Calculator.SearchResidue(masXn, masXr);

Console.WriteLine("Остаток:");
Calculator.OutMass(masXn);

Console.WriteLine("Итоговая строка:");
Calculator.Shift(masXn, masXk, r);
Calculator.Shift2(masXn, masXk, r);

var masXXn = masXn;
var masXXk = masXk;
var Rr = r;
//Calculator.OutMass(masXn);



Console.WriteLine("Введите место первой ошибки");
error = Convert.ToInt32(Console.ReadLine()) - 1;
int err1 = error;
if (masXn[error] == 1) masXn[error] = 0;
else masXn[error] = 1;





Console.WriteLine("Ошибочная строка:");
Calculator.Shift2(masXn, masXk, r);
Console.WriteLine("Первоначальный полином: "); Calculator.OutMass(masXr); Calculator.OutMass(masXn); Console.WriteLine("-------------------------");
Calculator.SearchError(masXn, masXr, checkMatrix, r);



Console.WriteLine("Введите место второй ошибки");
error = Convert.ToInt32(Console.ReadLine()) - 1;
if (masXn[error] == 1) masXn[error] = 0;
else masXn[error] = 1;
if (masXn[err1] == 0) masXn[err1] = 1;
else masXn[err1] = 0;


Console.WriteLine("Ошибочная строка:");
Console.WriteLine("Первоначальный полином: "); Calculator.OutMass(masXr); Calculator.OutMass(masXn); Console.WriteLine("-------------------------");

Calculator.Shift2(masXn, masXk, r);
Calculator.SearchError2(masXn, masXr, checkMatrix, r, err1, error);

for (var i = 0; i < checkMatrix.Length - checkMatrix.Rank; i++)
{

}

#region solve

if (masXn[error] == 1) masXn[error] = 0;
else masXn[error] = 1;
if (masXn[err1] == 0) masXn[err1] = 1;
else masXn[err1] = 0;
Calculator.Shift2(masXn, masXk, r);

#endregion

//Calculator.Shift2(masXXn, masXXk, r);

//var masXXn = masXn;
//var masXXk = masXk;
//var Rr = r;



public static class Calculator
{

    public static int[] SearchError(int[] masXn, int[] masXr, int[,] checkMatrix, int r)
    {
        int n = masXn.Length;
        int k = n - r;

        int[] masXnSecond = new int[n];

        for (int i = 0; i < n; i++)
        {
            masXnSecond[i] = masXn[i];
        }

        Console.WriteLine("\nДеление");
        SearchResidue(masXnSecond, masXr);

        Console.WriteLine("\nОстаток:");
        Calculator.OutMass(masXnSecond);

        for (int i = 0; i < n; i++)
        {
            int coincidence = 0;
            for (int j = 0; j < r; j++)
            {
                if (checkMatrix[i, j] == masXnSecond[k + j])
                {
                    coincidence++;
                }

            }
            if (coincidence == r)
            {
                masXn[i] = (masXn[i] + 1) % 2;
                break;
            }
        }
        Console.WriteLine("\nИсправленная строка:");
        Calculator.OutMass(masXn);

        return masXn;
    }

    public static int[] SearchError2(int[] masXn, int[] masXr, int[,] checkMatrix, int r, int err1, int err2)
    {
        int n = masXn.Length;
        int k = n - r;

        int[] masXnSecond = new int[n];

        for (int i = 0; i < n; i++)
        {
            masXnSecond[i] = masXn[i];
        }

        Console.WriteLine("\nДеление");
        SearchResidue(masXnSecond, masXr);

        Console.WriteLine("\nОстаток:");
        Calculator.OutMass(masXnSecond);

        int[] searchRes = new int[masXnSecond.Length];


        for (int j = 0; j < r; j++)
        {

            var cou1 = checkMatrix[err1, j];
            var cou2 = checkMatrix[err2, j];


            if (cou1 + cou2 % 2 == 0)
            {
                searchRes[j] = 0;
            }
            else
                searchRes[j] = 1;

            Console.Write(cou1);

        }
        Console.Write("  ");
        for (int j = 0; j < r; j++)
        {

            var cou1 = checkMatrix[err1, j];
            var cou2 = checkMatrix[err2, j];

            Console.Write(cou2);

        }




        Console.WriteLine();
        return searchRes;
    }


    public static int[] SearchResidue(int[] masXn, int[] masXr)
    {
        int end = masXn.Length - masXr.Length + 1;

        for (int i = 0; i < end; i++)
        {
            if (masXn[i] == 1)
            {
                AddingMasMod2(masXn, masXr, i);
                Calculator.OutMass(masXn);
            }
        }

        return masXn;
    }

    //Сложение массивов по модулю 2 с опр. позиции
    public static int[] AddingMasMod2(int[] mas1, int[] mas2, int pos)
    {
        int end = pos + mas2.Length;

        for (int i = pos; i < end; i++)
        {
            mas1[i] = (mas1[i] + mas2[i - pos]) % 2;
        }
        return mas1;
    }

    //Смещение на массива r 
    public static int[] Shift(int[] shiftMas, int[] mas, int r)
    {
        for (int i = 0; i < mas.Length; i++)
        {

            shiftMas[i] = mas[i];
        }
        return shiftMas;
    }

    public static void Shift2(int[] shiftMas, int[] mas, int r)
    {
        for (int i = 0; i < shiftMas.Length; i++)
        {
            if (i == mas.Length) Console.Write(" | ");
            Console.Write(shiftMas[i]);
        }
        Console.WriteLine();
    }

    //Преобразование сторки в массив
    public static int[] StrInMas(int[] mas, string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == 49)
                mas[i] = 1;
            else mas[i] = 0;
        }
        return mas;
    }

    //Создание Порождающей матрицы 
    public static int[,] CreateGenerationMatrix(int[,] generationMatrix, int[] mas, int k, int n)
    {
        //Заполняем первую строку в проверочной матрице
        for (int i = 0; i < n; i++)
        {
            if (i < mas.Length)
            {
                generationMatrix[0, i] = mas[i];
            }
            else
            {
                generationMatrix[0, i] = 0;
            }
        }

        //Сдвигаем каждую строки вправо от предыдущей
        for (int i = 1; i < k; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                generationMatrix[i, j + 1] = generationMatrix[i - 1, j];
            }
            generationMatrix[i, 0] = generationMatrix[i - 1, n - 1];
        }



        return generationMatrix;
    }

    //Приведение порождающей матрицы к каноническому виду
    public static int[,] CreateCanonicalMatrix(int[,] generationMatrix, int k, int n)
    {
        //Перебираем строки для преведению к каноническому виду
        for (int i = 0; i < k; i++)
        {
            int i2 = i + 1;
            //Перебираем элементы строки, но только до k-элемента
            for (int j = i + 1; j < k; j++)
            {

                //если мы нашли единицу в строке, то...
                if (generationMatrix[i, j] == 1)
                {

                    //перебираем этот столбец, пока не найдем единицу
                    for (; i2 < k; i2++)
                    {
                        bool repeat = false;
                        //Если нашли, то складываем обе строки
                        if (generationMatrix[i2, j] == 1)
                        {
                            for (int j2 = j - 1; j2 > 0; j2--)
                            {
                                //Проверяем, есть ли до этой 1 еще 1, если есть то эту строку пропускаем
                                if (generationMatrix[i2, j2] == 1)
                                {
                                    repeat = true;
                                }
                            }
                            if (repeat)
                                continue;
                            //Console.WriteLine(i + " " + i2);
                            AddingLinesMatrixMod2(generationMatrix, i, i2, n);
                            i2++;
                            break;
                        }
                    }
                }
            }
        }

        return generationMatrix;
    }

    //Преобразование канонической матрицы в проверочную
    public static int[,] CreateCheckMatrix(int[,] checkMatrix, int[,] generationMatrix, int k, int n)
    {
        int r = n - k;

        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < r; j++)
            {
                checkMatrix[i, j] = generationMatrix[i, k + j];
            }
        }

        for (int i = k; i < n; i++)
        {
            for (int j = 0; j < r; j++)
            {
                if (j == i - k)
                {
                    checkMatrix[i, j] = 1;
                }
                else
                {
                    checkMatrix[i, j] = 0;
                }
            }
        }

        return checkMatrix;
    }



    //public static void SHOW_MYCHECKMATRIX(int[,] checkMatrix, int k, int n)
    //{
    //    for(int i = 0; i < k; n++)
    //    {
    //        for(int j = 0; j < n; j++)
    //        {
    //            Console.Write(checkMatrix[i, j]);
    //        }
    //        Console.WriteLine();
    //    }
    //}

    //Сложение строк матрицы
    public static int[,] AddingLinesMatrixMod2(int[,] matrix, int str1, int str2, int lengthString)
    {
        //Console.WriteLine(str1 + " и " + str2);
        for (int i = 0; i < lengthString; i++)
        {
            matrix[str1, i] = (matrix[str1, i] + matrix[str2, i]) % 2;
        }
        return matrix;
    }

    //вывод матрицы
    public static void OutMatrix(int[,] matrix, int k, int n)
    {
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j]);
                //if (j + 1 == k) Console.Write("|");
            }
            Console.WriteLine();
        }
    }

    //вывод одномерного массива
    public static void OutMass(int[] mas)
    {

        for (int i = 0; i < mas.Length; i++)
        {
            //if (i == k) Console.Write("|");
            Console.Write(mas[i]);
        }
        Console.WriteLine("\n");
    }
}

*/