using System.Text;


class Program
{
    static void Main(string[] args)
    {

        string m = "надежда";
        string k = "ключ";

        int nomer; // Номер в алфавите
        int d; // Смещение
        string s; //Результат
        int j, f; // Переменная для циклов
        int t = 0; // Преременная для нумерации символов ключа.

        char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
        char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

        char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };


        for (int i = 0; i < alfavit.Length; i++)
        {
            Console.Write("\t" + alfavit[i]);
        }
        Console.WriteLine();
        for (int i = 0; i < alfavit.Length; i++)
        {
            Console.Write("\t" + (i + 1));
        }
        Console.WriteLine();

        Console.WriteLine(m);


        var iii = new List<int>();

        // Перебираем каждый символ сообщения
        for (int i = 0; i < massage.Length; i++)
        {

            // Ищем индекс буквы
            for (j = 0; j < alfavit.Length; j++)
            {
                if (massage[i] == alfavit[j])
                {
                    break;
                }
            }

            if (j != 33) // Если j равно 33, значит символ не из алфавита
            {
                nomer = j; // Индекс буквы

                // Ключ закончился - начинаем сначала.
                if (t > key.Length - 1) { t = 0; }

                // Ищем индекс буквы ключа
                for (f = 0; f < alfavit.Length; f++)
                {
                    if (key[t] == alfavit[f])
                    {
                        //Console.Write("\t" + key[t]);
                        Console.Write(key[t] + " - " + f + ";  ");
                        iii.Add(t);

                        break;
                    }
                }

                t++;

                if (f != 33) // Если f равно 33, значит символ не из алфавита
                {
                    d = nomer + f;
                }
                else
                {
                    d = nomer;
                }

                // Проверяем, чтобы не вышли за пределы алфавита
                if (d > 32)
                {
                    d = d - 33;
                }

                massage[i] = alfavit[d]; // Меняем букву
            }
        }

        //Console.WriteLine();
        //foreach(var i in iii)
        //{
        //    Console.Write("\t" + i);
        //}


        s = new string(massage); // Собираем символы обратно в строку.
        Console.WriteLine("\n" + s);

        //File.WriteAllText("3.txt", s); // Записываем результат в файл.

    }

}
