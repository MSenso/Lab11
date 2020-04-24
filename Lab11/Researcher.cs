using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Researcher : Person, IExecutable, ICloneable
    {
        protected string post;
        public string Post
        {
            set { if (value == string.Empty) post = "научный сотрудник"; else post = value; }
            get { return post; }
        }
        public Researcher()
            : base()
        {
            post = "научный сотрудник";
        }
        public Researcher(string name, int age, string post)
            : base(name, age)
        {
            this.Post = post;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите научную должность:");
            Post = Console.ReadLine();
        }
        public override string ToString()
        {
            return base.ToString() + ", научная должность: " + post;
        }
        public override void Show()
        {

            Console.WriteLine(this.ToString());
        }
        public override object Clone()
        {
            Person temp_person = (Person)base.Clone();
            //Count_of_objects--;
            Researcher temp_researcher = new Researcher(temp_person.Name, temp_person.Age, this.Post);
            return temp_researcher;
        }

    }

}
