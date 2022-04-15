using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Directory_Personell_ver2
{
    struct Repository
    {
        private Personell[] personells;//основной массив для хранения данных 
        private string path;//путь к файлу с данными 
        int index;//текуший элемент для добавления в файл


        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.personells = new Personell[1];

            this.Load(this.path);

        }
        /// <summary>
        /// Увелечение массива для хранения данных 
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
                Array.Resize(ref this.personells, this.personells.Length * 2);
        }
        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="ConcretePersonell"></param>
        public void Add(Personell ConcretePersonell)
        {

            this.Resize(index >= this.personells.Length);
            this.personells[index] = ConcretePersonell;
            this.index++;
        }
        /// <summary>
        /// Ввод даннызх о сотруднике с клавиатуру 
        /// </summary>
        public void DataInput(string Path)
        {
            Personell personell = new Personell();

            int ID = 1;


            if (File.Exists(Path))
                ID = personells.Max(x => x.ID) + 1;
            
            Console.WriteLine($"ID: {ID}");
            personell.ID = Convert.ToInt32(ID);

            DateTime Date = DateTime.Now;
            Console.WriteLine($"\nДата и время:{Date}");
            personell.Date = Date;

            Console.Write("\n Ф.И.О: ");
            personell.LastName = Console.ReadLine();


            Console.Write("\n Возраст: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            personell.Age = Age;

            Console.Write("\n Рост: ");
            int Hieght = Convert.ToInt32(Console.ReadLine());
            personell.Hieght = Hieght;

            Console.Write("\n Дата рождения: ");
            string DateBirt = Convert.ToDateTime(Console.ReadLine()).ToString("dd.MM.yyyy");
            personell.DateBirt = DateBirt;

            Console.Write("\n Место рождение: ");
            personell.PlaceBirth = Console.ReadLine();

            Add(new Personell(Convert.ToInt32(personell.ID), Convert.ToDateTime(personell.Date), personell.LastName, Convert.ToInt32(personell.Age), Convert.ToInt32(personell.Hieght), personell.DateBirt, personell.PlaceBirth));

            Save(Path);
        }


        /// <summary>
        /// Загрузка данных с диска
        /// </summary>
        /// <param name="Path"></param>
        private void Load(string Path)
        {

            if (!File.Exists(Path))
                Console.WriteLine("Данных в файле нет");
            else
            {
                {

                    using (StreamReader sr = new StreamReader(Path))
                    {


                        while (!sr.EndOfStream)
                        {




                            string[] str = sr.ReadLine().Split('#');
                            if (!(str[0] == ""))
                                Add(new Personell(Convert.ToInt32(str[0]), Convert.ToDateTime(str[1]), str[2], Convert.ToInt32(str[3]), Convert.ToInt32(str[4]), str[5], str[6]));
                           

                        }
                    }
                }
            }
        }



        //}
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="Path"></param>
        public void Save(string Path)
        {
            string temp = String.Empty;
            for (int i = 0; i < this.index; i++)
                temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                        this.personells[i].ID,
                                        this.personells[i].Date,
                                        this.personells[i].LastName,
                                        this.personells[i].Age,
                                        this.personells[i].Hieght,
                                        this.personells[i].DateBirt,
                                        this.personells[i].PlaceBirth);
            File.AppendAllText(Path, $"{temp}\n");
        }
        /// <summary>
        /// Вывод по id
        /// </summary>
        /// <param name="Path"></param>
        public void PrintID(string Path)
        {

            Console.WriteLine("Ввидите ID:");
            int Idconsole = int.Parse(Console.ReadLine());
            bool proverka = false;
            for (int i = 0; i < personells.Length; i++)
            {

                if (Idconsole == this.personells[i].ID)
                {
                    Console.WriteLine(this.personells[i].Print());
                    proverka = true;
                }
            }
            if (!proverka)
                Console.WriteLine("Сотрудника с данным ID нет");
        }
        /// <summary>
        /// Удаление записи о сотруднике по ID
        /// </summary>
        /// <param name="Path"></param>
        public void DelPersonell(string Path)
        {



            Console.WriteLine("Введите ID строки, которую нужно удалить");

            int Idconsole = int.Parse(Console.ReadLine());

            string[] pred = File.ReadAllLines(@Path);

            for (int i = 0; i < pred.Length; i++)
            {

                if (Idconsole == personells[i].ID)
                    pred[i] = null;

            }
            File.WriteAllLines(Path, pred);
            Console.WriteLine(" Данные удалены ");

        }
        /// <summary>
        /// Измененния данных сотрудника по ID
        /// </summary>
        /// <param name="Path"></param>
        public void RePersonell(string Path)
        {
            //string temppath = @"temp";


            Console.WriteLine("Введите ID сотрудника для изменения ");
            int Idconsole = int.Parse(Console.ReadLine());
            string[] pred = File.ReadAllLines(@Path);


            for (int i = 0; i < personells.Length; i++)
            {


                if (Idconsole == this.personells[i].ID)
                {
                    Console.WriteLine($"Данная запись:{this.personells[i].Print()}");
                    Console.WriteLine("Какиe данные изменить(введите соотвествующую букву: \n1.Ф.И.О[ф] \n2.Возраст[в] \n3.Рост[р] \n4.Дата рождение[д],\n5.Место рождение[м]");
                    string izm = Console.ReadLine();
                    switch (izm)
                    {
                        case "ф":
                            {
                                Console.Write("Введите новое Ф.И.О: ");
                                personells[i].LastName = Console.ReadLine();
                            }
                            break;
                        case "в":
                            {
                                Console.Write("Введите новый возраст: ");
                                personells[i].Age = int.Parse(Console.ReadLine());
                            }
                            break;
                        case "p":
                            {
                                Console.Write("Введите новый рост: ");
                                personells[i].Hieght = int.Parse(Console.ReadLine());
                            }
                            break;
                        case "д":
                            {
                                Console.Write("Введите новую дату рождения: ");
                                personells[i].DateBirt = Console.ReadLine();
                            }
                            break;
                        case "м":
                            {
                                Console.WriteLine("Введите новое место рождение: ");
                                personells[i].PlaceBirth = Console.ReadLine();
                            }
                            break;

                        default: Console.Write("Вы ввели не существующую команду"); break;
                    }
                   
                        
                            pred[i] = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                    this.personells[i].ID,
                                    this.personells[i].Date,
                                    this.personells[i].LastName,
                                    this.personells[i].Age,
                                    this.personells[i].Hieght,
                                    this.personells[i].DateBirt,
                                   this.personells[i].PlaceBirth);
                    
                }

            }
    

            
            File.WriteAllLines(Path, pred);
            Console.WriteLine(" Данные изменены ");

        }
            /// <summary>
            /// Вывод в заданом диапозоне дат 
            /// </summary>            
            public void Data()
            {
                bool proverka= false;
                Console.Write("Введите дату начала выгрузки: ");
                DateTime BeginData= Convert.ToDateTime (Console.ReadLine());
                Console.Write("Введите дату конца выгрузки: ");
                DateTime EndData = Convert.ToDateTime(Console.ReadLine());

            for (int i = 0; i < personells.Length; i++)
               {
                

                if (BeginData<personells[i].Date & personells[i].Date < EndData)
                {
                    Console.WriteLine(this.personells[i].Print());
                    proverka = true;
                }

              }
              if(!proverka)
                Console.WriteLine("Введен не правильный диапозон дат");


             }
        /// <summary>
        /// Сортировка по дате по убванию и возрастанию 
        /// </summary>
            public void SortData ()
               {
                     Console.WriteLine("Сортировать по дате по убыванию или взрастанию у/в" );
                     string sort = Console.ReadLine();
                     switch (sort)
                     {
                case "у":
                    {
                        
                       
                        personells= personells.OrderByDescending(x => x.Date).ToArray();

                        for (int i = 0; i < personells.Length; i++)
                        {
                            Console.WriteLine(personells[i].Print());
                        }
                   
                    } break;
                case "в":
                    {
                        personells = personells.OrderBy(x => x.Date).ToArray();
                        for (int i = 0; i < personells.Length; i++)
                        {
                            Console.WriteLine(personells[i].Print());

                        }
                    } break;

                        default: Console.Write("Вы ввели не существующую команду"); break;
            }

        }



        }
        
    
   
}




 

