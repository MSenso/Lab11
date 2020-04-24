using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    [Serializable]
    class Student : Person, IExecutable, ICloneable
    {
        protected int course;
        protected double rating;
        public int Course
        {
            set { if (value <= 5 && value >= 1) course = value; else course = 1; }
            get { return course; }
        }
        public double Rating
        {
            set { if (value <= 5 && value >= 0) rating = value; else rating = 0; }
            get { return rating; }
        }
        public Student()
            : base()
        {
            rating = 0.0;
            course = 1;
            Person BasePerson = this.BasePerson;
        }
        public Student(string name, int age, int course, double rating)
            : base(name, age)
        {
            this.Rating = rating;
            this.Course = course;
            Person BasePerson = this.BasePerson;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите курс");
            Course = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите рейтинг");
            Rating = Convert.ToDouble(Console.ReadLine());
        }
        public override string ToString()
        {
            return base.ToString() + ", курс: " + course + ", рейтинг: " + String.Format("{0:F2}", rating);
        }
        public override void Show()
        {

            Console.WriteLine(this.ToString());
        }
        public override object Clone()
        {
            Person temp_person = (Person)base.Clone();
            //Count_of_objects--;
            Student temp_student = new Student(temp_person.Name, temp_person.Age, this.Course, this.Rating);
            return temp_student;
        }
        public Person BasePerson
        {
            get
            {
            return new Person(name, age);
            }

        }
        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            if (this.Name == other.Name && Age == other.Age && Is_male == other.Is_male && Course == other.Course && Rating == other.Rating)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Student personObj = obj as Student;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static bool operator ==(Student person1, Student person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return Object.Equals(person1, person2);

            return person1.Equals(person2);
        }

        public static bool operator !=(Student person1, Student person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return !Object.Equals(person1, person2);

            return !(person1.Equals(person2));
        }

    }

}
