﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LinqExamples
{


    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }

    }

    public enum Gender
    {
        Female,
        Male
    }

    public class StudentWithTopics
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<string> Topics { get; set; }
        public StudentWithTopics(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<string> topics)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.Topics = topics;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }
    }
    //topiczek

    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }

        public Topic(int id, string topicName)
        {
            Id = id;
            TopicName = topicName;
        }
    }

    //student z listą topiców jako intów
    public class Student
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<int> Topics { get; set; }
        public Student(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<int> topics)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.Topics = topics;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }
    }
    //klasa do zad4
    public class MyClass
    {
        public int mulNums(int a, int b)
        {
            return a * b;
        }
    }

    public static class Generator
    {
        public static int[] GenerateIntsEasy()
        {
            return [4, 7, 1, 3, 2, 9, 5, 6, 8];
        }

        public static int[] GenerateIntsMany()
        {
            var result = new int[10000];
            Random random = new Random();
            for (int i = 0; i < result.Length; i++)
                result[i] = random.Next(1000);
            return result;
        }

        public static List<string> GenerateNamesEasy()
        {
            return new List<string>() {
                "Kajza",
                "Schreiber",
                "Mercury",
                "Skarżyński",
                "Nostramus",
                "Wysocki"
            };
        }
        public static List<StudentWithTopics> StudentsReady()
        {
            return new List<StudentWithTopics>() {
            new StudentWithTopics(1,19345,"Skarżyńska", Gender.Female,true,1,
                    new List<string>{"C#","SQL","TEP", "HTML"}),
            new StudentWithTopics(2, 73235, "Zicio", Gender.Male, true,1,
                    new List<string>{"PSiO","RPiS", "HTML"}),
            new StudentWithTopics(3, 47977, "Krysia", Gender.Male, false,2,
                    new List<string>{"Analiza", "HTML"}),
            new StudentWithTopics(4, 67900, "Klimek", Gender.Female, false,3,
                    new List<string>{"AiSD","AI"}),
            new StudentWithTopics(5, 14019, "Hryba", Gender.Male, true,3,
                    new List<string>{"Servers","OCaml"}),
            new StudentWithTopics(6, 14070, "Karsiszek", Gender.Male, true,2,
                    new List<string>{"GameDev","Spring"}),
            new StudentWithTopics(11,10000,"Nowak", Gender.Female,true,2,
                    new List<string>{"Scala","C++","algorithms", "HTML"}),
            new StudentWithTopics(12, 10001, "Nowak", Gender.Male, true,1,
                    new List<string>{"C#","Humanities","Problem Solving"}),
            new StudentWithTopics(13, 23444, "Mbappe", Gender.Male, false,1,
                    new List<string>{"Scoring Goals","Staying Onside"}),
            new StudentWithTopics(14, 32900, "Jurek", Gender.Female, false,1,
                    new List<string>{"React","HTML"}),
            new StudentWithTopics(15, 44000, "Lewandowski", Gender.Male, true,3,
                    new List<string>{"Neural Networks","First Touch"}),
            new StudentWithTopics(16, 32000, "Krawiec", Gender.Male, true,2,
                    new List<string>{"algorithms","Web programming"}),
            };
        }

        public static List<Topic> GenerateTopicsEasy()
        {
            return new List<Topic>()
            {
                new Topic(1, "C#"),
                new Topic(2, "Java"),
                new Topic(3, "JS"),
                new Topic(4, "C++"),
                new Topic(5, "Scala"),
                new Topic(6, "Web programming"),
                new Topic(7, "SQL"),
                new Topic(8, "AI"),
                new Topic(9, "Web programming"),
                new Topic(10, "AiSD"),

            };
        }

        public static List<Department> GenerateDepartmentsEasy()
        {
            return new List<Department>() {
            new Department(1,"Computer Science"),
            new Department(2,"Construction"),
            new Department(3,"Mathematics"),
            new Department(4,"Management"),
            };
        }

    }
    class Program
    {

        public static void ShowAllCollections()
        {
            Generator.GenerateIntsEasy().ToList().ForEach(Console.WriteLine);
            Generator.GenerateDepartmentsEasy().ForEach(Console.WriteLine);
            Generator.StudentsReady().ForEach(Console.WriteLine);
        }

        public static void MethodWhereSimple()
        {
            var resInt = Generator.GenerateIntsEasy().Where(x => x % 2 == 0);
            resInt.ToList().ForEach(Console.WriteLine);
            var resStr = Generator.GenerateNamesEasy().Where(s => s.Length > 6);
            resStr.ToList().ForEach(Console.WriteLine);
            var resStud = Generator.StudentsReady().Where(s => s.Active && s.DepartmentId == 1);
            resStud.ToList().ForEach(Console.WriteLine);
        }
        public static void ClauseWhereSimple()
        {
            var resInt = from v in Generator.GenerateIntsEasy()
                         where v % 2 == 0
                         select v;
            resInt.ToList().ForEach(Console.WriteLine);
            var resStr = from s in Generator.GenerateNamesEasy()
                         where s.Length > 6
                         select s;
            resStr.ToList().ForEach(Console.WriteLine);
            var resStud = from s in Generator.StudentsReady()
                          where s.Active && s.DepartmentId == 1
                          select s;
            resStud.ToList().ForEach(Console.WriteLine);
        }

        public static void SimpleAggregiates()
        {
            var ints = Generator.GenerateIntsEasy();
            var resMin = ints.Where(x => x % 2 == 0).Min();
            Console.WriteLine(resMin);
            var resMax = ints.Where(x => x % 2 == 0).Max();
            Console.WriteLine(resMin);
            var strs = Generator.GenerateNamesEasy();
            var resStrMin1 = strs.Min();
            Console.WriteLine(resStrMin1);
            var resStrMin2 = strs.Min(s => s.Length);
            Console.WriteLine(resStrMin2);
        }

        public static void ComplexAggregiates()
        {
            var strs = Generator.GenerateNamesEasy();
            var strs0 = new string[] { };
            var strs1 = new string[] { "one" };
            Console.WriteLine("----- first form, one argument: lambda >>>>>>>>");
            Console.WriteLine(strs.Aggregate((a, b) => a + "," + b));
            try { Console.WriteLine(strs0.Aggregate((a, b) => a + "," + b)); }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }
            Console.WriteLine(strs1.Aggregate((a, b) => a + "," + b));
            Console.WriteLine("----- second form, two arguments: accumulator, lambda");
            Console.WriteLine(strs.Aggregate("", (a, b) => a + "," + b));
            Console.WriteLine(strs0.Aggregate("", (a, b) => a + "," + b));
            Console.WriteLine(strs1.Aggregate("", (a, b) => a + "," + b));
            Console.WriteLine("----- third form, three arguments: accumulator, lambda, finish lambda");
            Console.WriteLine(strs.Aggregate("", (a, b) => a + "," + b, res => res.Length));
            Console.WriteLine(strs0.Aggregate("", (a, b) => a + "," + b, res => res.Length));
            Console.WriteLine(strs1.Aggregate("", (a, b) => a + "," + b, res => res.Length));
            Console.WriteLine("----- finding average lenght in a complex way");
            var resStr = strs.Aggregate((0, ""),
                (tuple, str) => (tuple.Item1 + 1, tuple.Item2 + str), res => ((double)res.Item2.Length) / res.Item1);
            Console.WriteLine(resStr);
            //var avrLen= strs.Average(s => s.Length);
            //Console.WriteLine(avrLen);
        }

        public static void WhereWithPos()
        {
            var resStr = Generator.GenerateNamesEasy()
                .Where((s, pos) => pos % 2 == 0);
            resStr.ToList().ForEach(Console.WriteLine);
            var resStud = Generator.StudentsReady()
                .Where((s, pos) => s.Active && pos % 3 == 0);
            resStud.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("--------");
            var resStud2 = Generator.StudentsReady()
                .Where(s => s.Active)
                .Where((s, pos) => pos % 3 == 0);
            resStud2.ToList().ForEach(Console.WriteLine);
        }

        public static void TestSelect()
        {
            var resStud = Generator.StudentsReady()
                .Where(s => s.Index < 20000)
                .Select(s => new { Header = s.Id + ") " + s.Index, s.Name });
            foreach (var x in resStud)
            {
                Console.WriteLine($" {x.Header} =====> {x.Name}");
            }
            Console.WriteLine("-------------");
            var resStud2 = from s in Generator.StudentsReady()
                           where s.Index < 20000
                           select new { Header = s.Id + ") " + s.Index, s.Name };
            foreach (var x in resStud2)
            {
                Console.WriteLine($" {x.Header} =====> {x.Name}");
            }
            Console.WriteLine("-------------");
            var resStud3 = from s in Generator.StudentsReady()
                           where s.Index < 20000
                           select (Header: s.Id + ") " + s.Index, s.Name);
            foreach (var x in resStud3)
            {
                Console.WriteLine($" {x.Header} =====> {x.Name}");
            }
        }

        public static void TestSelectMany()
        {
            var resStud = Generator.StudentsReady()
                .Where(s => s.Index < 20000)
                .SelectMany(s => s.Topics);
            resStud.ToList().ForEach(x => Console.Write(x + ";"));
            Console.WriteLine();
            Console.WriteLine(resStud.Count());
            var resChars = resStud
                .SelectMany(s => s);
            resChars.ToList().ForEach(x => Console.Write(x + ";"));
            Console.WriteLine();
            Console.WriteLine(resChars.Count());
        }

        public static void TestSelectManyQuery()
        {
            var resStud = from s in Generator.StudentsReady()
                          where s.Index < 20000
                          from topic in s.Topics
                          select topic;
            resStud.ToList().ForEach(x => Console.Write(x + ";"));
            Console.WriteLine();
            Console.WriteLine(resStud.Count());
            var resChars = from s in resStud
                           from c in s
                           select c;
            resChars.ToList().ForEach(x => Console.Write(x + ";"));
            Console.WriteLine();
            Console.WriteLine(resChars.Count());
        }

        public static void TestSelectManyWith2Lambdas()
        {
            var resStud = Generator.StudentsReady()
                .Where(s => s.Index < 20000 && s.Name.Length <= 6)
                .SelectMany(s => s.Topics, (stud, topic) => new { stud.Name, topic });
            resStud.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------------");
            var resStud2 = from s in Generator.StudentsReady()
                           where s.Index < 20000 && s.Name.Length <= 6
                           from topic in s.Topics
                           select new { s.Name, topic };
            resStud2.ToList().ForEach(Console.WriteLine);
        }
        public static void TestOrderBy()
        {

            var resStud = Generator.StudentsReady()
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Index);
            resStud.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------------");
            var resStud2 = from s in Generator.StudentsReady()
                           orderby s.Name, s.Index descending
                           select s;
            resStud2.ToList().ForEach(Console.WriteLine);
        }

        class MyComparer : IComparer<string>
        {
#pragma warning disable
            int IComparer<string>.Compare(string x, string y)
            {
                return x.Length - y.Length;
            }
        }
        public static void TestOrderByWithComparer()
        {
            var resStud = Generator.StudentsReady()
                .OrderBy(s => s.Name, new MyComparer());
            resStud.ToList().ForEach(Console.WriteLine);
            //no version for Query expression
        }

        public static void TestTakeAndSkip()
        {
            var resStud = Generator.StudentsReady()
               .Skip(4).Take(5);
            resStud.ToList().ForEach(Console.WriteLine);
        }

        public static void TestTakeWhileAndSkipWhile()
        {
            Generator.StudentsReady().ToList().ForEach(Console.WriteLine);
            Console.WriteLine("------------");
            var resStud = Generator.StudentsReady()
               .SkipWhile(s => s.Active)
               .SkipWhile(s => !s.Active)
               .TakeWhile(s => s.Active);
            resStud.ToList().ForEach(Console.WriteLine);
        }

        public static void TestLazyExecution()
        {
            var studs = Generator.StudentsReady();
            var resStud = from s in studs
                          where s.Index < 20000 && s.Name.Length <= 6
                          select s;

            studs.Add(new StudentWithTopics(30, 15000, "Wuc", Gender.Male, true, 1,
                    new List<string> { "C#", "Java", "algorithms" }));

            resStud.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("---------------");
            var resStud2 = (from s in studs
                            where s.Index < 20000 && s.Name.Length <= 6
                            select s).Count();

            studs.Add(new StudentWithTopics(31, 15001, "Wow", Gender.Female, true, 1,
                    new List<string> { "C#" }));

            Console.WriteLine(resStud2);
        }

        public static void TestToDictionaryAndToLookup()
        {
            var resStud = Generator.StudentsReady().ToDictionary(s => s.Index, s => s.Name);
            resStud.ToList().ForEach(s => Console.WriteLine(s.Key + "-->" + s.Value));

            Console.WriteLine("---------------");
            var resStud2 = Generator.StudentsReady().ToLookup(s => s.Name);
            foreach (var dept in resStud2)
            {
                Console.WriteLine(dept.Key);
                resStud2[dept.Key].ToList().ForEach(s => Console.WriteLine("  " + s));
            }
        }

        public static void TestGroupBy()
        {
            var resStud = from s in Generator.StudentsReady()
                          group s by s.DepartmentId;

            foreach (var dept in resStud)
            {
                Console.WriteLine(dept.Key);
                dept.ToList().ForEach(s => Console.WriteLine("  " + s));
            }
        }


        public static void TestGroupByComplex()
        {
            var resStud = from s in Generator.StudentsReady()
                          group s by new { s.Active, s.Gender } into sGroup
                          orderby sGroup.Key.Active, sGroup.Key.Gender
                          select new
                          {
                              Active = sGroup.Key.Active,
                              sGroup.Key.Gender, // simpler
                              Students = sGroup.OrderBy(s => s.Name)
                          };

            foreach (var group in resStud)
            {
                Console.WriteLine((group.Active ? "active" : "no active") + "      " + group.Gender);
                group.Students.ToList().ForEach(s => Console.WriteLine("  " + s));
            }
        }

        public static void TestGroupJoin()
        {
            var resStud = Generator.GenerateDepartmentsEasy()
                .GroupJoin(Generator.StudentsReady(),
                        dept => dept.Id,
                        stud => stud.DepartmentId,
                        (department, students) => new
                        {
                            Department = department,
                            Students = students
                        }
                        );

            foreach (var group in resStud)
            {
                Console.WriteLine(group.Department.Name);
                group.Students.ToList().ForEach(s => Console.WriteLine("  " + s));
            }
            Console.WriteLine("------------");
            var resStud2 = from d in Generator.GenerateDepartmentsEasy()
                           join s in Generator.StudentsReady()
                           on d.Id equals s.DepartmentId into dGroup
                           select new
                           {
                               Department = d,
                               Students = dGroup
                           };


            foreach (var group in resStud2)
            {
                Console.WriteLine(group.Department.Name);
                group.Students.ToList().ForEach(s => Console.WriteLine("  " + s));
            }


        }
        public static void TestJoinSpecial()
        {
            var resStud = Generator.GenerateDepartmentsEasy()
                        .Join(Generator.StudentsReady(),
                        dept => dept.Id,
                        stud => stud.DepartmentId,
                        (department, student) => new
                        {
                            DepartmentName = department.Name,
                            StudentName = student.Name
                        }
                        );

            foreach (var elem in resStud)
            {
                Console.WriteLine($"{elem.DepartmentName} -> {elem.StudentName}");
            }
            //Console.WriteLine("------------");
            //var resStud2 = from d in Generator.GenerateDepartmentsEasy()
            //               join s in Generator.GenerateStudentsEasy()
            //               on d.Id equals s.DepartmentId into dGroup
            //               select new
            //               {
            //                   Department = d,
            //                   Students = dGroup
            //               };


            //foreach (var group in resStud2)
            //{
            //    Console.WriteLine(group.Department.Name);
            //    group.Students.ToList().ForEach(s => Console.WriteLine("  " + s));
            //}


        }


        public static void TestJoin()
        {
            var studs = Generator.StudentsReady();
            // there are no 6 department
            studs.Add(new StudentWithTopics(30, 15000, "Wuc", Gender.Male, true, 6,
                            new List<string> { "C#", "Java", "algorithms" }));
            var resStud = studs
                         .Join(Generator.GenerateDepartmentsEasy(),
                        stud => stud.DepartmentId,
                        dept => dept.Id,
                        (student, department) => new
                        {
                            DepartmentName = department.Name,
                            StudentName = student.Name
                        }
                        );

            foreach (var elem in resStud)
            {
                Console.WriteLine($"{elem.DepartmentName} -> {elem.StudentName}");
            }
            Console.WriteLine("------------");
            var resStud2 = from s in Generator.StudentsReady()
                           join d in Generator.GenerateDepartmentsEasy()
                           on s.DepartmentId equals d.Id
                           select new
                           {
                               DepartmentName = d.Name,
                               StudentName = s.Name
                           };
            foreach (var elem in resStud2)
            {
                Console.WriteLine($"{elem.DepartmentName} -> {elem.StudentName}");
            }
        }

        public static void CartesianProduct()
        {
            var resCart = from num in Generator.GenerateIntsEasy()
                          where num % 2 == 0
                          from d in Generator.GenerateNamesEasy()
                          where d.Length < 7
                          select new
                          {
                              Number = num,
                              Word = d
                          };
            foreach (var elem in resCart)
            {
                Console.WriteLine($"{elem.Number} -> {elem.Word}");
            }
            Console.WriteLine("--------");
            var resCart2 = Generator.GenerateIntsEasy()
                           .Where(num => num % 2 == 0)
                           .SelectMany(
                                s => Generator.GenerateNamesEasy().Where(s => s.Length < 7),
                                (n, s) => new
                                {
                                    Number = n,
                                    Word = s
                                });
            foreach (var elem in resCart2)
            {
                //                Console.WriteLine($"{elem.Number} -> {elem.Word}");
                Console.WriteLine($"{elem}");
            }
        }

        class Comp : IEqualityComparer<StudentWithTopics>
        {
#pragma warning disable
            public bool Equals(StudentWithTopics x, StudentWithTopics y)
            {
                return x.Id == x.Id;
            }

            public int GetHashCode(StudentWithTopics obj)
            {
                return obj.Id.GetHashCode();
            }
        }
        public static void TestDistinc()
        {
            var set1 = Generator.StudentsReady()
                       .Where(s => s.Id >= 0 && s.Id <= 2)
                       .ToList();
            set1.Add(new StudentWithTopics(1, 12345, "Nowak", Gender.Female, true, 1,
                    new List<string> { "C#", "PHP", "algorithms" })); // copy od first student

            set1.Distinct().ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------------");
            set1.Distinct(new Comp()).ToList().ForEach(Console.WriteLine);
        }

        public static void TestUnion()
        {
            var set1 = Generator.StudentsReady()
                       .Where(s => s.Id >= 1 && s.Id <= 4);
            var set2 = Generator.StudentsReady()
                       .Where(s => s.Id >= 3 && s.Id <= 6);
            set1.Union(set2).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------------");
            set1.Union(set2, new Comp()).ToList().ForEach(Console.WriteLine);
        }

        public static void TestUnionAnnonymous()
        {
            var set1 = Generator.StudentsReady()
                       .Where(s => s.Id >= 1 && s.Id <= 4)
                       .Select(s => new
                       {
                           s.Id,
                           s.Index,
                           s.Name
                       }
                       );
            var set2 = Generator.StudentsReady()
                       .Where(s => s.Id >= 3 && s.Id <= 6)
                       .Select(s => new
                       {
                           s.Id,
                           s.Index,
                           s.Name
                       }
                       );
            set1.Union(set2).ToList().ForEach(Console.WriteLine);
        }

        static void TestClauseWithoutLet()
        {
            ClauseWithoutLet(".", "*");
        }
        static void ClauseWithoutLet(string rootDirectory, string searchPattern)
        {
            IEnumerable<string> filenames = Directory.GetFiles(rootDirectory, searchPattern);
            var fileResults =
              from fileName in filenames
              orderby new FileInfo(fileName).Length, fileName
              select new FileInfo(fileName);
            foreach (var fileResult in fileResults)
            {
                Console.WriteLine($"{fileResult.Name} ({fileResult.Length})");
            }
        }


        static void Main()
        {
            //ShowAllCollections();
            //Console.WriteLine("--------------");
            //ClauseWhereSimple();
            //SimpleAggregiates();
            //ComplexAggregiates();
            //WhereWithPos();
            //TestSelect();
            //TestSelectMany();
            //TestSelectManyQuery();
            //TestSelectManyWith2Lambdas();
            //TestOrderBy();
            //TestOrderByWithComparer();
            //TestTakeAndSkip();
            //TestTakeWhileAndSkipWhile();
            //TestLazyExecution();
            //TestToDictionaryAndToLookup(); 
            //TestGroupBy();
            //TestGroupByComplex();
            //TestGroupJoin(); 
            //TestJoinSpecial();  
            //TestJoin();
            //CartesianProduct();
            //TestDistinc();
            //TestUnion();
            //TestUnionAnnonymous();
            //TestClauseWithoutLet();



            groupStudents(4);
            sortTopicsByFreq();
            sortTopicsByFreqAndGender();
            sortTopicsByFreqAndLastLetterOfName();
            transformStudents();
            ReflectionMechanism();
        }

        //zad1
        static void groupStudents(int n)
        {
            var students = Generator.StudentsReady();

            var sortedStudents = students
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Index).ToList();

            var groupedStudents = from student in sortedStudents
                                  let index = sortedStudents.IndexOf(student)
                                  group student by index / n;

            var groupedStudents2 = Generator.StudentsReady()
                        .OrderBy(s => s.Name)
                        .ThenBy(s => s.Index)
                        .Select((student, index) => (Student: student, Group: index / n))
                        .GroupBy(studentGroup => studentGroup.Group);

            // var len=groupedStudents2.Length;

            foreach (var group in groupedStudents2)
            {
                Console.WriteLine($"Grupa: {group.Key}");

                foreach (var studentGroup in group)
                {
                    var student = studentGroup.Student;
                    Console.WriteLine($"  {student.Name}, {student.Index}");
                }
            }
        }


        //zad2a
        static void sortTopicsByFreq()
        {
            var topicsFrequency = Generator.StudentsReady()
                .SelectMany(student => student.Topics)
                .GroupBy(topic => topic)
                .OrderByDescending(group => group.Count())
                .Select(group => new { Topic = group.Key, Frequency = group.Count() })
                .ToList();

            Console.WriteLine("Posorotowane przez Frekwencję:");
            foreach (var topic in topicsFrequency)
            {
                Console.WriteLine($"Topic: {topic.Topic}, Frequency: {topic.Frequency}");
            }
        }
        //zad2b
        static void sortTopicsByFreqAndGender()
        {
            var topicsFrequencyByGender = Generator.StudentsReady()
        .GroupBy(student => student.Gender)
        .SelectMany(group => group
        .SelectMany(student => student.Topics)
        .GroupBy(topic => topic)
        .OrderByDescending(subgroup => subgroup.Count())
        .Select(subgroup => new { Gender = group.Key, Topic = subgroup.Key, Frequency = subgroup.Count() })
            )
            .ToList();


            Console.WriteLine("Posortowane topici przez freq i Gender:");
            foreach (var topic in topicsFrequencyByGender)
            {
                Console.WriteLine($"Gender: {topic.Gender}, Topic: {topic.Topic}, Frequency: {topic.Frequency}");
            }
        }
        static void sortTopicsByFreqAndLastLetterOfName()
        {
            var topicsFrequencyByLastLetter = Generator.StudentsReady()
                .GroupBy(student => student.Name[0])
                .SelectMany(group => group
                    .SelectMany(student => student.Topics)
                    .GroupBy(topic => topic)
                    .OrderByDescending(subgroup => subgroup.Count())
                    .Select(subgroup => new { LastLetter = group.Key, Topic = subgroup.Key, Frequency = subgroup.Count() })
                )
                .ToList();

            Console.WriteLine("Posortowane topici przez freq i ostatnią literę imienia:");
            foreach (var topic in topicsFrequencyByLastLetter)
            {
                Console.WriteLine($"Last Letter: {topic.LastLetter}, Topic: {topic.Topic}, Frequency: {topic.Frequency}");
            }
        }

        //zad3
        static void transformStudents()
        {
            var students = Generator.StudentsReady();

            var studentsNew = new List<Student>();

            var topics = Generator.GenerateTopicsEasy();

            foreach (StudentWithTopics stud in students)
            {
                var transformedTopics = new List<int>();
                foreach (var topic in stud.Topics)
                {
                    foreach (Topic top in topics)
                    {
                        if (top.TopicName == topic)
                        {
                            transformedTopics.Add(top.Id);
                            break;
                        }
                    }
                }
                studentsNew.Add(new Student(stud.Id, stud.Index, stud.Name, stud.Gender, stud.Active, stud.DepartmentId, transformedTopics));
            }

            Console.WriteLine("Po transoformacji:\n");
            foreach (Student student in studentsNew)
            {
                //magia to_string
                Console.WriteLine("Student: " + student);
            }

        }
        //zad4

        static void ReflectionMechanism()
        {
            MyClass newObject = new MyClass();

            object? obj = newObject;

            MethodInfo? methodInfo = obj.GetType().GetMethod("mulNums");

            object[] parameters = { 100, 200 };
// #pragma warning disable

            object? result = methodInfo.Invoke(obj, parameters);
            Console.WriteLine($"Wynik invoka: {result}");

            object? objResult = result;

            Console.WriteLine($"Wynik w obiekcie: {objResult}");

        }
    }
}
