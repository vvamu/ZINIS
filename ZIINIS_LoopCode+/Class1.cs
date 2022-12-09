/*Console.WriteLine("lab 7");

int[] thread = new int[15];//15
int length = 15;
int countRows = 5;
int informWordLenght = 6;

int[] errorsIndexes = new int[] { 3, 4, 5 };

for(int i= 0; i< length; i++ )
{
    thread[i] = new Random().Next(0,2);
}

Progr.OutArray(thread);
var matr = Progr.GetInformationalWords(thread, informWordLenght, countRows);
Progr.OutArray(matr);



static class Progr
{
    public static void OutArray(int[] obj)
    {
        foreach (object o in obj)
        {
            Console.Write(o);
        }
    }
    public static void OutArray(int[,] obj)
    {
        for(int i = 0; i<obj.Length; i++)
        {
            for (int a = 0; a < obj.Rank; a++)
            {
                Console.Write(obj[i, a]);
            }
            Console.WriteLine();
        }
    }

    public static int[,] GetInformationalWords(int[] obj, int informWordLenght, int countRows)
    {
        if (informWordLenght * countRows != obj.Length)
            throw new ArgumentException("Размеры матрицы не соответствуют размерам сообщения");

        int[,] matrix = new int[informWordLenght, countRows];
        for (int i = 0; i < informWordLenght; i++)
        {
            for (int j = 0; j < countRows; j++)
            {
                matrix[i, j] = obj[i * countRows + j];
            }
        }
        return matrix;

        
                 var iii = new int[informWordLenght * countRows];

                for (int i = 0, k = 0; i < obj.Length; i++)
                {
                    if(i == informWordLenght)

                    iii[i] = obj[i];

                    if (i % informWordLenght == 0)
                    {
                        Console.WriteLine();
                    }

                    Console.Write(obj[i]);

                }
         
    }
}
*/
