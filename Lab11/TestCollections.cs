using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab11
{
    class TestCollections
    {
        #region Массивы данных
        static string[] names = { "Иванов", "Иванова", "Петров", "Петрова", "Сидоров", "Сидорова", "Кузнецов", "Кузнецова", "Соколов", "Соколова", "Галкин", "Галкина" };
        static string[] posts = { "младший научный сотрудник", "научный сотрудник", "старший научный сотрудник", "ведущий научный сотрудник", "главный научный сотрудник" };
        static string[] professor_posts = { "ассистент", "преподаватель", "старший преподаватель", "доцент", "профессор" };
        static string[] departments = { "кафедра высшей математики", "кафедра гражданского и предпринимательнского права", "кафедра гуманитарных дисциплин", "кафедра информационных технологий в бизнесе", "кафедра физического воспитания" };
        #endregion
        List<Person> list_of_persons;
        List<string> list_of_strings;
        Dictionary<Person, Student> dict_1;
        Dictionary<string, Student> dict_2;
        public int size = 84;
        static Random rnd = new Random();
        public TestCollections()
        {
            list_of_persons = new List<Person>(size);
            list_of_strings = new List<string>(size);
            dict_1 = new Dictionary<Person, Student>(size);
            dict_2 = new Dictionary<string, Student>(size);
        }
        #region Show
        public void Show_list_of_persons()
        {
            Console.WriteLine("Вывод list_of_persons");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(list_of_persons[i]);
            }
            Console.WriteLine();
        }
        public void Show_list_of_strings()
        {
            Console.WriteLine("Вывод list_of_strings");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(list_of_strings[i]);
            }
            Console.WriteLine();
        }
        public void Show_dict_1()
        {
            Console.WriteLine("Вывод dict_1");
            foreach (KeyValuePair<Person, Student> x in dict_1)
            {
                Console.Write(x.Key + ". " + x.Value);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Show_dict_2()
        {
            Console.WriteLine("Вывод dict_2");
            foreach (KeyValuePair<string, Student> x in dict_2)
            {
                Console.Write(x.Key + ". " + x.Value);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Show()
        {
            if (size > 0)
            {
                list_of_persons = new List<Person>(size);
                list_of_strings = new List<string>(size);
                dict_1 = new Dictionary<Person, Student>(size);
                dict_2 = new Dictionary<string, Student>(size);
                for (int i = 0; i < size; i++)
                {
                    bool exists = true;
                    Student student;
                    do
                    {
                        double rating = (rnd.Next(1, 5) + rnd.NextDouble());
                        student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rating);
                        if (dict_1.ContainsKey(student.BasePerson) == false)
                        {
                            exists = false;
                        }
                    } while (exists);
                    Person person = student.BasePerson;
                    list_of_persons.Add(person);
                    list_of_strings.Add(person.ToString());
                    dict_1.Add(person, student);
                    dict_2.Add(person.ToString(), student);
                }
                Show_list_of_persons();
                Show_list_of_strings();
                Show_dict_1();
                Show_dict_2();
            }
            else Console.WriteLine("Коллекции пустые!");
        }
        #endregion
        #region TimeSpan
        long Watch_for_list_of_persons(Person elem)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            if (list_of_persons.Contains(elem)) elem.Show();
            else Console.WriteLine("Элемент не найден!");
            sw.Stop();
            return sw.ElapsedTicks;
        }
        long Watch_for_list_of_strings(Person elem)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            if (list_of_strings.Contains(elem.ToString())) elem.Show();
            else Console.WriteLine("Элемент не найден!");
            sw.Stop();
            return sw.ElapsedTicks;
        }
        long Watch_for_dict_1_by_key(Person elem)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            if (dict_1.ContainsKey(elem)) elem.Show();
            else Console.WriteLine("Элемент не найден!");
            sw.Stop();
            return sw.ElapsedTicks;
        }
        long Watch_for_dict_1_by_value(Student elem)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            if (dict_1.ContainsValue(elem)) elem.Show();
            else Console.WriteLine("Элемент не найден!");
            sw.Stop();
            return sw.ElapsedTicks;
        }
        long Watch_for_dict_2(Person elem)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            if (dict_2.ContainsKey(elem.ToString())) elem.Show();
            else Console.WriteLine("Элемент не найден!");
            sw.Stop();
            return sw.ElapsedTicks;
        }
        string Show_time(TimeSpan time)
        {
            string elapsed_Time = time.ToString("mm':'ss':'fff");
            return elapsed_Time;
        }
        #endregion
        #region Time_Research
        public void Time_Research_of_list_of_strings(Person first_elem, Person middle_elem, Person last_elem, Person out_elem)
        {
            long time = Watch_for_list_of_strings(first_elem);
            Console.WriteLine("Время, необходимое для поиска первого элемента в list_of_strings: " + time);
            time = Watch_for_list_of_strings(middle_elem);
            Console.WriteLine("Время, необходимое для поиска среднего элемента в list_of_strings: " + time);
            time = Watch_for_list_of_strings(last_elem);
            Console.WriteLine("Время, необходимое для поиска последнего элемента в list_of_strings: " + time);
            time = Watch_for_list_of_strings(out_elem);
            Console.WriteLine("Время, необходимое для поиска элемента вне list_of_strings: " + time);
            Console.WriteLine();
        }
        public void Time_Research_of_list_of_persons(Person first_elem, Person middle_elem, Person last_elem, Person out_elem)
        {
            long time = Watch_for_list_of_persons(first_elem);
            Console.WriteLine("Время, необходимое для поиска первого элемента в list_of_persons: " + time);
            time = Watch_for_list_of_persons(middle_elem);
            Console.WriteLine("Время, необходимое для поиска среднего элемента в list_of_persons: " + time);
            time = Watch_for_list_of_persons(last_elem);
            Console.WriteLine("Время, необходимое для поиска последнего элемента в list_of_persons: " + time);
            time = Watch_for_list_of_persons(out_elem);
            Console.WriteLine("Время, необходимое для поиска элемента вне list_of_persons: " + time);
            Console.WriteLine();
        }
        public void Time_Research_of_dict_1_by_key(Person first_elem, Person middle_elem, Person last_elem, Person out_elem)
        {
            long time = Watch_for_dict_1_by_key(first_elem);
            Console.WriteLine("Время, необходимое для поиска первого элемента по ключу в dict_1: " + time);
            time = Watch_for_dict_1_by_key(middle_elem);
            Console.WriteLine("Время, необходимое для поиска среднего элемента по ключу в dict_1: " + time);
            time = Watch_for_dict_1_by_key(last_elem);
            Console.WriteLine("Время, необходимое для поиска последнего элемента по ключу в dict_1: " + time);
            time = Watch_for_dict_1_by_key(out_elem);
            Console.WriteLine("Время, необходимое для поиска элемента по ключу вне dict_1: " + time);
            Console.WriteLine();
        }
        public void Time_Research_of_dict_2(Person first_elem, Person middle_elem, Person last_elem, Person out_elem)
        {
            long time = Watch_for_dict_2(first_elem);
            Console.WriteLine("Время, необходимое для поиска первого элемента по ключу в dict_2: " + time);
            time = Watch_for_dict_2(middle_elem);
            Console.WriteLine("Время, необходимое для поиска среднего элемента по ключу в dict_2: " + time);
            time = Watch_for_dict_2(last_elem);
            Console.WriteLine("Время, необходимое для поиска последнего элемента по ключу в dict_2: " + time);
            time = Watch_for_dict_2(out_elem);
            Console.WriteLine("Время, необходимое для поиска элемента по ключу вне dict_2: " + time);
            Console.WriteLine();
        }
        public void Time_Research_of_dict_1_by_value(Student first_elem, Student middle_elem, Student last_elem, Student out_elem)
        {
            long time = Watch_for_dict_1_by_value(first_elem);
            Console.WriteLine("Время, необходимое для поиска первого элемента по значению в dict_1: " + time);
            time = Watch_for_dict_1_by_value(middle_elem);
            Console.WriteLine("Время, необходимое для поиска среднего элемента по значению в dict_1: " + time);
            time = Watch_for_dict_1_by_value(last_elem);
            Console.WriteLine("Время, необходимое для поиска последнего элемента по значению в dict_1: " + time);
            time = Watch_for_dict_1_by_value(out_elem);
            Console.WriteLine("Время, необходимое для поиска элемента по значению вне dict_1: " + time);
            Console.WriteLine();
        }
        public void Time_Research()
        {
            Person first_elem = DeepCopy.DeepClone(list_of_persons[0]);
            Person middle_elem = DeepCopy.DeepClone(list_of_persons[size/2]);
            Person last_elem = DeepCopy.DeepClone(list_of_persons[size-1]);
            Person out_elem = new Person("a", 5);
            Student first_elem_1 = DeepCopy.DeepClone(dict_1[first_elem]);
            Student middle_elem_1 = DeepCopy.DeepClone(dict_1[middle_elem]);
            Student last_elem_1 = DeepCopy.DeepClone(dict_1[last_elem]);
            Student out_elem_1 = new Student("a", 5, 1, 1);
            Time_Research_of_list_of_persons(first_elem, middle_elem, last_elem, out_elem);
            Time_Research_of_list_of_strings(first_elem, middle_elem, last_elem, out_elem);
            Time_Research_of_dict_1_by_key(first_elem, middle_elem, last_elem, out_elem);
            Time_Research_of_dict_2(first_elem, middle_elem, last_elem, out_elem);
            Time_Research_of_dict_1_by_value(first_elem_1, middle_elem_1, last_elem_1, out_elem_1);
        }
        #endregion
        #region Adding
        public void Adding()
        {
            Student student;
            do
            {
                student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rnd.Next(1, 6) + rnd.NextDouble());
            } while (dict_1.ContainsKey(student.BasePerson));
            Console.WriteLine("Добавление случайного элемента в конец: " + student.ToString());
            Person person = student.BasePerson;
            size += 1;
            list_of_persons.Add(person);
            list_of_strings.Add(person.ToString());
            dict_1.Add(person, student);
            dict_2.Add(person.ToString(), student);
            Show();
        }
        #endregion
        #region Removing
        public void Removing()
        {
            Person person = list_of_persons[rnd.Next(list_of_persons.Count)];
            Console.WriteLine("Удаление случайного элемента: " + person.ToString());
            size--;
            list_of_persons.Remove(person);
            list_of_strings.Remove(person.ToString());
            dict_1.Remove(person);
            dict_2.Remove(person.ToString());
            Show();
        }
        #endregion
    }
}
