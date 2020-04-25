using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        const int size = 2;
        static Random rnd = new Random();
        static int InputNumber(string ForUser, int left, int right)
        {
            bool ok;
            int number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number <= right) ok = true;
                    else
                    {
                        Console.WriteLine("Неверный ввод числа!");
                        ok = false;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Неверный ввод числа!");
                    ok = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод числа!");
                    ok = false;
                }
            }
            while (!ok);
            return number;
        }
        #region Массивы данных
        static string[] names = { "Иванов", "Иванова", "Петров", "Петрова", "Сидоров", "Сидорова", "Кузнецов", "Кузнецова", "Соколов", "Соколова", "Галкин", "Галкина" };
        static string[] posts = { "младший научный сотрудник", "научный сотрудник", "старший научный сотрудник", "ведущий научный сотрудник", "главный научный сотрудник" };
        static string[] professor_posts = { "ассистент", "преподаватель", "старший преподаватель", "доцент", "профессор" };
        static string[] departments = { "кафедра высшей математики", "кафедра гражданского и предпринимательнского права", "кафедра гуманитарных дисциплин", "кафедра информационных технологий в бизнесе", "кафедра физического воспитания" };
        #endregion
        #region Queue
        static void Show_objects(ref Queue queue)
        {
            queue = new Queue();
            Console.WriteLine("Объекты класса Person:");
            for (int i = 0; i < size; i++)
            {

                Person person = new Person(names[rnd.Next(0, 12)], rnd.Next(18, 60));
                ShowEnq(ref queue, person);
            }
            Console.WriteLine("Объекты класса Student:");
            for (int i = 0; i < size; i++)
            {

                Student student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rnd.Next(1, 5) + rnd.NextDouble());
                ShowEnq(ref queue, student);
            }
            Console.WriteLine("Объекты класса Researcher:");
            for (int i = 0; i < size; i++)
            {

                Researcher researcher = new Researcher(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)]);
                ShowEnq(ref queue, researcher);
            }
            Console.WriteLine("Объекты класса Professor:");
            for (int i = 0; i < size; i++)
            {

                Professor professor = new Professor(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)], professor_posts[rnd.Next(0, 5)], departments[rnd.Next(0, 5)]);
                ShowEnq(ref queue, professor);
            }
        }
        static void Adding_in_queue(ref Queue queue)
        {
            Console.WriteLine("Добавление случайного элемента");
            int choice = rnd.Next(4);
            switch (choice)
            {
                case 0:
                    {
                        Person person = new Person(names[rnd.Next(0, 12)], rnd.Next(18, 60));
                        ShowEnq(ref queue, person);
                        break;
                    }
                case 1:
                    {
                        Student student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rnd.Next(1, 6) + rnd.NextDouble());
                        ShowEnq(ref queue, student);
                        break;
                    }
                case 2:
                    {
                        Researcher researcher = new Researcher(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)]);
                        ShowEnq(ref queue, researcher);
                        break;
                    }
                case 3:
                    {
                        Professor professor = new Professor(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)], professor_posts[rnd.Next(0, 5)], departments[rnd.Next(0, 5)]);
                        ShowEnq(ref queue, professor);
                        break;
                    }
            }
        }
        static void Removing_from_queue(ref Queue queue)
        {
            Console.WriteLine("Удаление первого элемента очереди");
            ShowDeq(ref queue);
        }
        static void ShowEnq(ref Queue queue, Person elem)
        {
            queue.Enqueue(elem);
            Console.WriteLine("Помещаем элемент {0} в очередь", elem);
            Show(queue);
        }
        static void ShowDeq(ref Queue queue)
        {
            if (queue.Count == 0) Console.WriteLine("Очередь пустая");
            else
            {
                Person elem = (Person)queue.Dequeue();
                Console.WriteLine("Удаляем элемент {0} из очереди", elem);
                Show(queue);
            }
        }
        static void Show(Queue queue)
        {
            Console.WriteLine("Очередь:");
            foreach (Person x in queue)
            {
                Console.Write(x + " ");
                Console.WriteLine();
            }
        }
        #region Запросы
        #region Список людей определенного пола
        static void List_of_persons_of_specific_gender(Queue queue, bool is_male_list)
        {
            if (is_male_list)
            {
                int count = 0;
                foreach (Person person in queue)
                {
                    if (person.Is_male)
                    {
                        person.Show();
                        count++;
                    }
                }
                if (count == 0) Console.WriteLine("В списке нет лиц указанного пола!");
            }
            else
            {
                int count = 0;
                foreach (Person person in queue)
                {
                    if (!person.Is_male)
                    {
                        person.Show();
                        count++;
                    }
                }
                if (count == 0) Console.WriteLine("В списке нет лиц указанного пола!");
            }
        }
        static void Choice_of_gender(Queue queue)
        {
            bool is_male_list = true;
            bool is_correct_input = true;
            Console.WriteLine(@"Лиц какого пола нужно вывести? Введите ""Мужской"" или ""Женский""");
            do
            {
                string answer = Console.ReadLine();
                if (answer == "Мужской") is_male_list = true;
                else if (answer == "Женский") is_male_list = false;
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            List_of_persons_of_specific_gender(queue, is_male_list);
        }
        #endregion Список людей определенного пола
        #region Список студентов определенного курса
        static void List_of_students_of_specific_course(Queue queue, int course)
        {
            int count = 0;
            foreach (Person person in queue)
            {
                Student current_person = person as Student;
                if (current_person != null && current_person.Course == course)
                {
                    current_person.Show();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("В списке нет студентов указанного курса!");
        }
        static void Choice_of_course(Queue queue)
        {
            int course = InputNumber("Студентов какого курса нужно вывести? Введите число от 1 до 4 включительно", 1, 4);
            List_of_students_of_specific_course(queue, course);
        }
        #endregion
        #region Список научных сотрудников определенной должности
        static void List_of_researchers_of_specific_post(Queue queue, string post)
        {
            int count = 0;
            foreach (Person person in queue)
            {
                if (person is Researcher current_researcher && current_researcher.Post == post)
                {
                    current_researcher.Show();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("В списке нет преподавателей указанной профессорской должности!");
        }
        static void Choice_of_post(Queue queue)
        {
            string post = string.Empty;
            bool is_correct_input = true;
            Console.WriteLine("Введите научную должность: младший научный сотрудник, научный сотрудник, старший научный сотрудник, ведущий научный сотрудник, главный научный сотрудник");
            do
            {
                post = Console.ReadLine();
                if (post != "младший научный сотрудник" && post != "научный сотрудник" && post != "старший научный сотрудник" && post != "ведущий научный сотрудник" && post != "главный научный сотрудник")
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            List_of_researchers_of_specific_post(queue, post);
        }
        #endregion
        #endregion Запросы
        static void Search(Queue queue)
        {
            bool is_correct_input = true;
            string name_for_search = string.Empty;
            Console.WriteLine("Введите фамилию искомого человека: ");
            do
            {
                name_for_search = Console.ReadLine();
                if (name_for_search == string.Empty || name_for_search.Any(char.IsDigit))
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            int age_for_search = InputNumber("Введите возраст искомого человека от 18 до 60 включительно: ", 18, 60);
            bool is_found = false;
            foreach (Person person in queue)
            {
                if (person.Name == name_for_search && person.Age == age_for_search)
                {
                    person.Show();
                    is_found = true;
                    break;
                }
            }
            if (!is_found) Console.WriteLine("Такой человек не найден!");
        }
        #endregion Queue
        #region Dictionary<K,T>
        #region Show
        static void Show_objects(ref Dictionary<int,Person> dict, ref int Count_of_objects)
        {
            dict = new Dictionary<int, Person>();
            Count_of_objects = 1;
            Console.WriteLine("Объекты класса Person:");
            for (int i = 0; i < size; i++)
            {
                Person person;
                bool exists = true;
                do
                {
                    person = new Person(names[rnd.Next(0, 12)], rnd.Next(18, 60));
                    if (!dict.ContainsValue(person)) exists = false;
                } while (exists);
                ShowAdd(ref dict, person, Count_of_objects);
                Count_of_objects++;
            }
            Console.WriteLine("Объекты класса Student:");
            for (int i = 0; i < size; i++)
            {
                Student student;
                bool exists = true;
                do
                {
                    
                    student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rnd.Next(1, 5) + rnd.NextDouble());
                    if (!dict.ContainsValue(student)) exists = false;
                } while (exists);
                ShowAdd(ref dict, student, Count_of_objects);
                Count_of_objects++;
            }
            Console.WriteLine("Объекты класса Researcher:");
            for (int i = 0; i < size; i++)
            {
                Researcher researcher;
                bool exists = true;
                do
                {
                    researcher = new Researcher(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)]);
                    if (!dict.ContainsValue(researcher)) exists = false;
                } while (exists);
                ShowAdd(ref dict, researcher, Count_of_objects);
                Count_of_objects++;
            }
            Console.WriteLine("Объекты класса Professor:");
            for (int i = 0; i < size; i++)
            {
                Professor professor;
                bool exists = true;
                do
                {
                    professor = new Professor(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)], professor_posts[rnd.Next(0, 5)], departments[rnd.Next(0, 5)]);
                    if (!dict.ContainsValue(professor)) exists = false;
                } while (exists);
                ShowAdd(ref dict, professor, Count_of_objects);
                Count_of_objects++;
            }
        }
        static void ShowAdd(ref Dictionary<int, Person> dict, Person elem, int Count_of_objects)
        {
            dict.Add(Count_of_objects, elem);
            Console.WriteLine("Помещаем элемент {0} в конец словаря", elem);
            Show(dict);
        }
        static void ShowDel(ref Dictionary<int, Person> dict, int Count_of_objects)
        {
            if (dict.Count == 0) Console.WriteLine("Словарь пустой");
            else
            {
                int index = InputNumber("Введите индекс удаляемого элемента", 1, Count_of_objects);
                if (dict.ContainsKey(index))
                {
                    Console.WriteLine("Удаляем элемент {0} из словаря", dict[index]);
                    dict.Remove(index);
                }
                else Console.WriteLine("Элемент с таким индексом не найден!");
                Show(dict);
            }
        }
        static void Show(Dictionary<int, Person> dict)
        {
            Console.WriteLine("Словарь:");
            foreach (KeyValuePair<int, Person> x in dict)
            {
                Console.Write(x.Key + ". " + x.Value);
                Console.WriteLine();
            }
        }
        #endregion
        static void Adding_in_dict(ref Dictionary<int, Person> dict, ref int Count_of_objects)
        {
            Console.WriteLine("Добавление случайного элемента");
            int choice = rnd.Next(4);
            switch (choice)
            {
                case 0:
                    {
                        Person person = new Person(names[rnd.Next(0, 12)], rnd.Next(18, 60));
                        ShowAdd(ref dict, person, Count_of_objects);
                        //Count_of_objects++;
                        break;
                    }
                case 1:
                    {
                        Student student = new Student(names[rnd.Next(0, 12)], rnd.Next(18, 25), rnd.Next(1, 5), rnd.Next(1, 6) + rnd.NextDouble());
                        ShowAdd(ref dict, student, Count_of_objects);
                        //Count_of_objects++;
                        break;
                    }
                case 2:
                    {
                        Researcher researcher = new Researcher(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)]);
                        ShowAdd(ref dict, researcher, Count_of_objects);
                        //Count_of_objects++;
                        break;
                    }
                case 3:
                    {
                        Professor professor = new Professor(names[rnd.Next(0, 12)], rnd.Next(25, 60), posts[rnd.Next(0, 5)], professor_posts[rnd.Next(0, 5)], departments[rnd.Next(0, 5)]);
                        ShowAdd(ref dict, professor, Count_of_objects);
                        //Count_of_objects++;
                        break;
                    }
            }
        }     
        #region Запросы
        #region Список людей определенного пола
        static void List_of_persons_of_specific_gender(Dictionary<int, Person> dict, bool is_male_list)
        {
            if (is_male_list)
            {
                int count = 0;
                foreach (KeyValuePair<int, Person> person in dict)
                {
                    if (person.Value.Is_male)
                    {
                        person.Value.Show();
                        count++;
                    }
                }
                if (count == 0) Console.WriteLine("В списке нет лиц указанного пола!");
            }
            else
            {
                int count = 0;
                foreach (KeyValuePair<int, Person> person in dict)
                {
                    if (!person.Value.Is_male)
                    {
                        person.Value.Show();
                        count++;
                    }
                }
                if (count == 0) Console.WriteLine("В списке нет лиц указанного пола!");
            }
        }
        static void Choice_of_gender(Dictionary<int, Person> dict)
        {
            bool is_male_list = true;
            bool is_correct_input = true;
            Console.WriteLine(@"Лиц какого пола нужно вывести? Введите ""Мужской"" или ""Женский""");
            do
            {
                string answer = Console.ReadLine();
                if (answer == "Мужской") is_male_list = true;
                else if (answer == "Женский") is_male_list = false;
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            List_of_persons_of_specific_gender(dict, is_male_list);
        }
        #endregion Список людей определенного пола
        #region Список студентов определенного курса
        static void List_of_students_of_specific_course(Dictionary<int, Person> dict, int course)
        {
            int count = 0;
            foreach (KeyValuePair<int, Person> person in dict)
            {
                Student current_person = person.Value as Student;
                if (current_person != null && current_person.Course == course)
                {
                    current_person.Show();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("В списке нет студентов указанного курса!");
        }
        static void Choice_of_course(Dictionary<int, Person> dict)
        {
            int course = InputNumber("Студентов какого курса нужно вывести? Введите число от 1 до 4 включительно", 1, 4);
            List_of_students_of_specific_course(dict, course);
        }
        #endregion
        #region Список научных сотрудников определенной должности
        static void List_of_researchers_of_specific_post(Dictionary<int, Person> dict, string post)
        {
            int count = 0;
            foreach (KeyValuePair<int, Person> person in dict)
            {
                if (person.Value is Researcher current_researcher && current_researcher.Post == post)
                {
                    current_researcher.Show();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("В списке нет преподавателей указанной профессорской должности!");
        }
        static void Choice_of_post(Dictionary<int, Person> dict)
        {
            string post = string.Empty;
            bool is_correct_input = true;
            Console.WriteLine("Введите научную должность: младший научный сотрудник, научный сотрудник, старший научный сотрудник, ведущий научный сотрудник, главный научный сотрудник");
            do
            {
                post = Console.ReadLine();
                if (post != "младший научный сотрудник" && post != "научный сотрудник" && post != "старший научный сотрудник" && post != "ведущий научный сотрудник" && post != "главный научный сотрудник")
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            List_of_researchers_of_specific_post(dict, post);
        }
        static void Clone(Dictionary<int, Person> dict)
        {
            Dictionary<int, Person> new_dict = new Dictionary<int, Person>();
            int new_count_of_objects = 1;
            foreach (KeyValuePair<int, Person> elem in dict)
            {
                Professor clone_professor;
                Researcher clone_researcher;
                Student clone_student;
                Person clone_person;
                object checking_class = elem.Value as Professor;
                if (checking_class != null)
                {
                    Professor clone = (Professor)elem.Value;
                    clone_professor = (Professor)clone.Clone();
                    new_dict.Add(new_count_of_objects, clone_professor);
                    new_count_of_objects++;
                }
                else
                {
                    checking_class = elem.Value as Researcher;
                    if (checking_class != null)
                    {
                        Researcher clone = (Researcher)elem.Value;
                        clone_researcher = (Researcher)clone.Clone();
                        new_dict.Add(new_count_of_objects, clone_researcher);
                        new_count_of_objects++;
                    }
                    else
                    {
                        checking_class = elem.Value as Student;
                        if (checking_class != null)
                        {
                            Student clone = (Student)elem.Value;
                            clone_student = (Student)clone.Clone();
                            new_dict.Add(new_count_of_objects, clone_student);
                            new_count_of_objects++;
                        }
                        else
                        {
                            Person clone = (Person)elem.Value;
                            clone_person = (Person)clone.Clone();
                            new_dict.Add(new_count_of_objects, clone_person);
                            new_count_of_objects++;
                        }
                    }
                }
            }
            Show(new_dict);
        }
        #endregion
        #endregion Запросы
        static void Searching_and_sorting(ref Dictionary<int, Person> dict)
        {
            Dictionary<int, Person> new_dict = new Dictionary<int, Person>();
            foreach (var item in dict.OrderBy(i => i.Value))
            {
                new_dict.Add(item.Key,item.Value);
            }
            dict = new_dict;
            Show(dict);
            bool is_correct_input = true;
            string name_for_search = string.Empty;
            Console.WriteLine("Введите фамилию искомого человека: ");
            do
            {
                name_for_search = Console.ReadLine();
                if (name_for_search == string.Empty || name_for_search.Any(char.IsDigit))
                {
                    Console.WriteLine("Некорректный ввод!");
                    is_correct_input = false;
                }
            } while (!is_correct_input);
            int age_for_search = InputNumber("Введите возраст искомого человека от 18 до 60 включительно: ", 18, 60);
            bool is_found = false;
            foreach (KeyValuePair<int, Person> person in dict)
            {
                if (person.Value.Name == name_for_search && person.Value.Age == age_for_search)
                {
                    Console.WriteLine(person.Key + ". " + person.Value);
                    is_found = true;
                    break;
                }
            }
            
            if (!is_found) Console.WriteLine("Такой человек не найден!");
        }
        #endregion Dictionary<K,T>
        #region Menu
        static void Menu()
        {
            int user_answer;
            do
            {
                Console.WriteLine(@"1. Работа с коллекцией Queue
2. Работа коллекцией Dictionary<K,T>
3. Работа с коллекцией MyList<T>
4. Выход");
                user_answer = InputNumber("", 1, 4);
                switch (user_answer)
                {
                    case 1:
                        Queue_Menu();
                        break;
                    case 2:
                        Dict_Menu();
                        break;
                    case 3:
                        TestCollections_Menu();
                        break;
                    default: break;
                }
            } while (user_answer != 4);
        }
        static void Queue_Menu()
        {
            Queue queue = new Queue();
            int user_answer;
            do
            {
                Console.WriteLine(@"1. Сформировать и вывести список лиц
2. Вывести список лиц выбранного пола
3. Вывести список студентов выбранного курса
4. Вывести список научных сотрудников выбранной научной должности
5. Добавить случайный элемент
6. Удалить элемент из начала очереди
7. Найти человека по фамилии и возрасту
8. Выход");
                user_answer = InputNumber("", 1, 8);
                switch (user_answer)
                {
                    case 1:
                        Show_objects(ref queue);
                        break;
                    case 2:
                        Choice_of_gender(queue);
                        break;
                    case 3:
                        Choice_of_course(queue);
                        break;
                    case 4:
                        Choice_of_post(queue);
                        break;
                    case 5:
                        Adding_in_queue(ref queue);
                        break;
                    case 6:
                        Removing_from_queue(ref queue);
                        break;
                    case 7:
                        Search(queue);
                        break;
                    default: break;
                }
            } while (user_answer != 8);
        }
        static void Dict_Menu()
        {
            Dictionary<int, Person> dict = new Dictionary<int, Person>();
            int Count_of_objects = 1;
            int user_answer;
            do
            {
                Console.WriteLine(@"1. Сформировать и вывести список лиц
2. Вывести список лиц выбранного пола
3. Вывести список студентов выбранного курса
4. Вывести список научных сотрудников выбранной научной должности
5. Добавить случайный элемент
6. Удалить элемент из начала очереди
7. Сортировка словаря и поиск человека по фамилии и возрасту
8. Выход");
                user_answer = InputNumber("", 1, 8);
                switch (user_answer)
                {
                    case 1:
                        Show_objects(ref dict, ref Count_of_objects);
                        break;
                    case 2:
                        if (dict.Keys.Count != 0)
                            Choice_of_gender(dict);
                        else Console.WriteLine("Словарь пустой!");
                        break;
                    case 3:
                        if (dict.Keys.Count != 0)
                            Choice_of_course(dict);
                        else Console.WriteLine("Словарь пустой!");
                        break;
                    case 4:
                        if (dict.Keys.Count != 0)
                            Choice_of_post(dict);
                        else Console.WriteLine("Словарь пустой!");
                        break;
                    case 5:
                        Adding_in_dict(ref dict, ref Count_of_objects);
                        break;
                    case 6:
                        if (dict.Keys.Count != 0)
                            ShowDel(ref dict, Count_of_objects);
                        else Console.WriteLine("Словарь пустой!");
                        break;
                    case 7:
                        if (dict.Keys.Count != 0)
                            Searching_and_sorting(ref dict);
                        else Console.WriteLine("Словарь пустой!");
                        break;
                    default: break;
                }
            } while (user_answer != 8);
        }
        static void TestCollections_Menu()
        {
            TestCollections testCollections = new TestCollections();
            int user_answer;
            do
            {
                Console.WriteLine(@"1. Сгенерировать элементы коллекций
2. Определить, сколько времени требуется для поиска элементов в каждой коллекции
3. Добавить случайный элемент в конец каждой коллекции
4. Удалить случайный элемент из каждой коллекции
5. Выход");
                user_answer = InputNumber("", 1, 5);
                switch (user_answer)
                {
                    case 1:
                        testCollections.Show();
                        break;
                    case 2:
                        if (testCollections.size > 0)
                            testCollections.Time_Research();
                        else Console.WriteLine("Коллекции пустые!");
                        break;
                    case 3:
                        testCollections.Adding();
                        break;
                    case 4:
                        if (testCollections.size > 0)
                            testCollections.Removing();
                        else Console.WriteLine("Коллекции пустые!");
                        break;
                    default: break;
                }
            } while (user_answer != 5);
        }
        #endregion Menu
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
