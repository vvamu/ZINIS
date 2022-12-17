//int nomer; // Номер в алфавите
//int d = 5; // Смещение
//string s; //Результат
//int j; // Переменная для циклов

//string m = "надя";
//char[] massage = m.ToCharArray(); // Превращаем строку в массив символов.

//char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };


//for (int i = 0; i < alfavit.Length; i++)
//{
//    Console.Write("\t" + alfavit[i]);
//}
//Console.WriteLine(m);
//Console.WriteLine(d);

//// Перебираем каждый символ сообщения
//for (int i = 0; i < massage.Length; i++)
//{
//    // Ищем индекс буквы
//    for (j = 0; j < alfavit.Length; j++)
//    {
//        if (massage[i] == alfavit[j])
//        {
//            break;
//        }
//    }

//    if (j != 33) // Если j равно 33, значит символ не из алфавита
//    {
//        nomer = j; // Индекс буквы
//        d = nomer +1; // Делаем смещение

//        // Проверяем, чтобы не вышли за пределы алфавита
//        if (d > 32)
//        {
//            d = d - 33;
//        }

//        massage[i] = alfavit[d]; // Меняем букву
//    }
//}

//s = new string(massage); // Собираем символы обратно в строку.
//Console.WriteLine(s);
