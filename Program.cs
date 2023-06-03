using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Linq;

namespace Module6
{
    internal class Program
    {
        static void StaffOutput()
        {
            foreach(string str in File.ReadAllLines("staff.txt"))
            {
                foreach(string temp in str.Split('#'))
                {
                    Write($" {temp} ");
                }
                WriteLine();
            }
        }
        static void StaffInput()
        {
            int id;
            if (!File.Exists("staff.txt"))
            {
                id = 0;
            }
            else
            {
                string[] str = File.ReadAllLines("staff.txt");
                var lastString = str[str.Length - 1];
                id = int.Parse(lastString.Split('#')[0]);
            }
            string note = Convert.ToString(++id);

            string now = DateTime.Now.ToString();
            note += $"#{now}";

            Write("Введите ФИО сотрудника: ");
            string fullName = ReadLine();
            note += $"#{fullName}";

            Write("Введите возраст сотрудника: ");
            string age = ReadLine();
            note += $"#{age}";

            Write("Введите рост сотрудника: ");
            string height = ReadLine();
            note += $"#{height}";

            Write("Введите дату рождения сотрудника в формате DD.MM.YYYY: ");
            string[] split = ReadLine().Split('.');
            double day = Double.Parse(split[0]), month = Double.Parse(split[1]), year = Double.Parse(split[2]);
            DateTime birthDate = new DateTime((int)year, (int)month, (int)day);
            note += $"#{birthDate.ToShortDateString()}";

            Write("Введите место рождения сотрудника: ");
            string city = ReadLine();
            note += $"#{city}\n";

            File.AppendAllText("staff.txt", note);
            
        }
        static void Main(string[] args)
        {
            Write("Введите 1 для вывода справочника и 2 для добавления записи: ");
            string ans = ReadLine();
            if (ans == "1")
            {
                StaffOutput();
            }
            else
            {
                StaffInput();
            }
            ReadKey();
        }
    }
}
