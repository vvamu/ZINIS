﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entropy
{
     public static partial class Entropya
    {


        //Считаем r (кол-во пров. симв.)
        public static int LenghtHemminga(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1f);
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
        public static void OutMass(int[] mas)
        {
            int n = LenghtHemminga(mas.Length) + mas.Length;

            for (int i = 0; i < n; i++)
            {
                if (i == mas.Length) Console.Write("|");
                Console.Write(mas[i]);
            }
            Console.WriteLine("\n");
        }


    }
}
