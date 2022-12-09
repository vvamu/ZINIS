using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entropy
{
     public static partial class Entropya
    {

        static string surname = "Bichun",
                   name = "Nadezhda",
                   surnameASCII = "",
                   nameASCII = "";

        public static string GetAsciiToString(string strr)
        {
            string str = "";
            foreach (var VARIABLE in strr)
            {
                str += Convert.ToInt32(VARIABLE);
            }
            return str;

        }

        public static string GetStringByBytes(byte[] bytes)
        {
            string str = "";
            foreach (var VARIABLE in bytes)
            {
                str += VARIABLE.ToString();
            }

            return str;
        }
        public static string ConvertTextFromFileToBase64(string filename)
        {
            string text = GetTextFromFile(filename);

            return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(text));
        }

        public static void ConvertFileBase64Doc(string filename)
        {

            if (!File.Exists("base64.txt"))
                File.Create("base64.txt");


            using (FileStream fs = new FileStream("base64.txt", FileMode.OpenOrCreate))
            {
                var text = System.Text.Encoding.Unicode.GetBytes(ConvertTextFromFileToBase64(filename));
                fs.Write(text);
            }
        }

        public static byte[] XOR(byte[] buf1, byte[] buf2)
        {
            byte[] ans = new byte[buf1.Length];

            if (buf1.Length == buf2.Length)
            {
                for (int i = 0; i < buf1.Length; i++)
                {
                    ans[i] = (byte)(buf1[i] ^ buf2[i]);
                }
            }
            return ans;
        }
        public static byte[] myXOR(byte[] buf1, byte[] buf2)
        {
            byte[] ans = new byte[buf1.Length];

            if (buf1.Length == buf2.Length)
            {
                for (int i = 0; i < buf1.Length; i++)
                {
                    string buf1In2 = Convert.ToString(buf1[i], 2);
                    string buf2In2 = Convert.ToString(buf2[i], 2);
                    string bitAns = "";
                    while (buf1In2.Length != buf2In2.Length)
                    {
                        if (buf1In2.Length < buf2In2.Length)
                            buf1In2 += "0";
                        else
                            buf2In2 += "0";

                    }
                    for (int j = 0; j < buf2In2.Length; j++)
                    {
                        if (buf1In2[j] == '0' && buf2In2[j] == '0'
                           || buf1In2[j] == '1' && buf2In2[j] == '1')
                            bitAns += '0';
                        else
                            bitAns += '1';
                    }
                    ans[i] = (byte)Convert.ToInt32(bitAns, 2);
                }
            }
            return ans;
        }


        public static (string,string) NormolizeBytesLength(string a, string b)
        {

            string min = a;
            string max = b;

            if (a.Length == b.Length) return (a,b);
            if (a.Length > b.Length)
            {
                min = b;
                max = a;
            }


            while (min.Length != max.Length)
            {
                min = '0' + min;
            }
            return (min,max);
        }


    }
}
