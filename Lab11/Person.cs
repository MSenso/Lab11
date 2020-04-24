using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public interface IExecutable
    {
        string Name { get; set; }
        int Age { get; set; }
        void Init();
        string ToString();
        void Show();
        object Clone();
        object ShallowCopy();
    }
    [Serializable]
    class Person : IExecutable, IComparable, ICloneable, IEquatable<Person>
    {
        public string name;
        public int age;
        public bool is_male;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            set
            {
                if (value > 0) age = value; else age = 0;
            }
            get
            {
                return age;
            }
        }
        public bool Is_male
        {
            set
            {
                char a = this.name[this.name.Length - 1];
                if (a == 'а')
                    this.is_male = false;
                else this.is_male = true;
            }
            get
            {
                return this.is_male;
            }
        }
        public Person()
        {
            name = "Иванов";
            age = 20;
            is_male = Is_male;
           // Index = Count_of_objects;
           // Count_of_objects++;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Is_male = this.is_male;
            //Index = Count_of_objects;
            //Count_of_objects++;
        }
        public virtual void Init()
        {
            string buf;
            Console.WriteLine("Введите имя");
            Name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            buf = Console.ReadLine();
            Age = Convert.ToInt32(buf);
        }
        public override string ToString()
        {
            return /*Index + ". " +*/ name + ", возраст: " + age;
        }
        public virtual void Show()
        {
            Console.WriteLine(this.ToString());
        }
        public int CompareTo(object ob1)
        {
            Person person_2 = (Person)ob1;
            int result = String.Compare(this.Name, person_2.Name);
            if (result == 0)
            {
                if (this.Age < person_2.Age) result = -1;
                else if (this.Age > person_2.Age) result = 1;
            }
            return result;
        }
        public virtual object Clone()
        {
            Person temp_person = new Person(this.Name + " (клон)", this.Age);
            return temp_person;
        }
        public virtual object ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            if (this.Name == other.Name && Age == other.Age && Is_male == other.Is_male)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Person personObj = obj as Person;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static bool operator ==(Person person1, Person person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return Object.Equals(person1, person2);

            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return !Object.Equals(person1, person2);

            return !(person1.Equals(person2));
        }
    }

    public class SortByName : IComparer<object>
    {
        public int Compare(object ob1, object ob2)
        {
            Person person_1 = (Person)ob1;
            Person person_2 = (Person)ob2;
            int result = String.Compare(person_1.Name, person_2.Name);
            if (result == 0)
            {
                if (person_1.Age < person_2.Age) result = -1;
                else if (person_1.Age > person_2.Age) result = 1;
            }
            return result;
        }
    }
}