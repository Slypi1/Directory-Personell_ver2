using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lesson7_Directory_Personell_ver2
{
    struct Personell
    {

        #region Данные
        
        private int id;
        private DateTime date;
        private string lastname;
        private int age;
        private int hieght;
        private string datebirt;
        private string placebirth;
        #endregion
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Date"></param>
        /// <param name="LastName"></param>
        /// <param name="Age"></param>
        /// <param name="Hieght"></param>
        /// <param name="DateBirt"></param>
        /// <param name="PlaceBirth"></param>
        public Personell(int ID, DateTime Date, string LastName, int Age, int Hieght, string DateBirt, string PlaceBirth)
        {
            this.id = ID;
            this.date = Date;
            this.lastname = LastName;
            this.age = Age;
            this.hieght = Hieght;
            this.datebirt = DateBirt;
            this.placebirth = PlaceBirth;

        }


            public string Print()
        {
            return $"{this.id} {this.date} {this.lastname} {this.age} {this.hieght} {this.datebirt} {this.placebirth}";

    }

        public int ID { get { return this.id; } set { this.id = value; } }
        public DateTime Date { get { return this.date; } set { this.date = value; } }
        public string LastName { get { return this.lastname; } set { this.lastname = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public int Hieght { get { return this.hieght; } set { this.hieght = value; }}
        public string DateBirt { get { return this.datebirt; } set { this.datebirt = value; } }
        public string PlaceBirth { get { return this.placebirth; } set { this.placebirth = value; } }


    }
}