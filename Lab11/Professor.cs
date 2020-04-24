using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Professor : Researcher, IExecutable, ICloneable
    {
        protected string professor_post;
        protected string department;
        public string Professor_post
        {
            set { if (value == string.Empty) professor_post = "преподаватель"; else professor_post = value; }
            get { return professor_post; }
        }
        public string Department
        {
            set { if (value == string.Empty) department = "кафедра высшей математики"; else department = value; }
            get { return department; }
        }
        public Professor()
            : base()
        {
            professor_post = "преподаватель";
            department = "кафедра высшей математики";
        }
        public Professor(string name, int age, string post, string professor_post, string department)
            : base(name, age, post)
        {
            this.Professor_post = professor_post;
            this.Department = department;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите Профессорскую должность:");
            Professor_post = Console.ReadLine();
            Console.WriteLine("Введите кафедру:");
            Department = Console.ReadLine();
        }
        public override string ToString()
        {
            return base.ToString() + ", профессорская должность: " + professor_post + ", кафедра: " + department;
        }
        public override void Show()
        {

            Console.WriteLine(this.ToString());
        }
        public override object Clone()
        {
            Researcher temp_researcher = (Researcher)base.Clone();
           // Count_of_objects--;
            Professor temp_professor = new Professor(temp_researcher.Name, temp_researcher.Age, temp_researcher.Post, this.Professor_post, this.Department);
            return temp_professor;
        }
        public override object ShallowCopy()
        {
            return (Professor)this.MemberwiseClone();
        }

    }
}
