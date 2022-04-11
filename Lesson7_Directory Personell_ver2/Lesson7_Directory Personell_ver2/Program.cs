using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Directory_Personell_ver2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите нужное действие: \n1-Вывести сотрудника по ID. \n2-Создать записи.\n3-Удалить запись \n4-Редактировать запись \n5-Загрузка в диапозоне дат. \n6 -Сортировать по дате ");
            string WorkBase = Console.ReadLine();
            string path = @"Directory Personell";
            Repository worker= new Repository(path);
            switch(WorkBase)
            {
                case "1": worker.PrintID(path); break;
                case "2": worker.DataInput(path); break;
                case "3": worker.DelPersonell(path);break;
                case "4": worker.RePersonell(path); break;
                case "5": worker.Data(); break;
                case "6": worker.SortData() ; break;
                default: Console.Write("Вы ввели не существующую команду"); break;
            }
            Console.ReadKey();



           
        }
    }
}
