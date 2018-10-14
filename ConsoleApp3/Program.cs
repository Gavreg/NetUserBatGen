using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = File.ReadAllLines("names.txt",System.Text.Encoding.GetEncoding(1251));
            string[] pswd = new string[names.Count<string>()];
            
           

            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFJHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();

            for (int i = 0; i < pswd.Count<string>(); ++i)
            {
                string s = string.Empty;
                for (int j = 0; j < 6; ++j)
                {
                    s += chars[r.Next(chars.Length)];
                }
                pswd[i] = s;
            }

            for (int i = 0; i < pswd.Count<string>(); ++i)
            {

            }


            StreamWriter sw = new StreamWriter("result.txt", false, System.Text.Encoding.GetEncoding(1251));


            for (int i = 0; i < pswd.Count<string>(); ++i)
            {
                string s = string.Concat(names[i], "    ", pswd[i]);
                Console.WriteLine(s);
                sw.WriteLine(s);
            }
            sw.Close();

            sw = new StreamWriter("COMAND.BAT", false, System.Text.Encoding.GetEncoding(1251));
            sw.WriteLine("chcp 1251");
            for (int i = 0; i < pswd.Count<string>(); ++i)
            {
                string comand = string.Format("net user \"{0}\" {1} /add", names[i], pswd[i]);
                string comand2 = string.Format("net localgroup \"{0}\" \"{1}\" /add", "Пользователи удаленного рабочего стола", names[i]);
                sw.WriteLine(comand);
                sw.WriteLine(comand2);
            }
            sw.WriteLine("pause");
            sw.Close();


            sw = new StreamWriter("COMAND_DEL.BAT", false, System.Text.Encoding.GetEncoding(1251));
            sw.WriteLine("chcp 1251");
            for (int i = 0; i < pswd.Count<string>(); ++i)
            {
                string comand = string.Format("net user \"{0}\" /delete", names[i]);
                
                sw.WriteLine(comand);               
            }
            sw.WriteLine("pause");
            sw.Close();
        }
    }
}
