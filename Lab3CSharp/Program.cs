using System;

namespace Lab3CSharp
{
    internal class Point
    {
        // Поля
        protected int x, y; // Координати точки
        protected int color; // Колір точки

        // Конструктори
        public Point()
        {
            x = 0;
            y = 0;
            color = 0;
        }

        public Point(int x, int y, int color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        // Методи
        public void PrintCoordinates()
        {
            Console.WriteLine($"Координати точки: ({x}, {y})");
        }

        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public void Move(int x1, int y1)
        {
            x += x1;
            y += y1;
        }

        // Властивості
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Color
        {
            get { return color; }
        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    internal class Student : Person
    {
        public string StudentID { get; set; }
        public string Major { get; set; }

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Student ID: {StudentID}, Major: {Major}");
        }
    }

    internal class Teacher : Person
    {
        public string Department { get; set; }
        public string Subject { get; set; }

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}");
        }
    }

    internal class DepartmentHead : Teacher
    {
        public int YearsOfExperience { get; set; }

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}, Years of Experience: {YearsOfExperience}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 ");

            // Задання масиву точок
            Point[] points = new Point[]
            {
                new Point(1, 1, 2),
                new Point(2, 3, 3),
                new Point(4, -1, 1)
                // Додайте інші точки за потребою
            };

            // Знаходження середньої відстані
            double averageDistance = 0;
            foreach (Point point in points)
            {
                averageDistance += point.DistanceToOrigin();
            }
            averageDistance /= points.Length;

            // Виведення інформації про кожну точку та відстань до центра координат
            Console.WriteLine("Інформація про точки:");
            foreach (Point point in points)
            {
                point.PrintCoordinates();
                Console.WriteLine($"Відстань до центра координат: {point.DistanceToOrigin()}");

                // Переміщення точки, якщо вона знаходиться далі від середньої відстані
                if (point.DistanceToOrigin() > averageDistance)
                {
                    point.Move(1, 1); // Перемістити на вказаний вектор (1, 1)
                    Console.WriteLine("Точка переміщена на вектор (1, 1)");
                }

                Console.WriteLine();
            }

            // Вправа 2
            // Створення масиву об'єктів базового класу Person
            Person[] people = new Person[]
            {
                new Student { Name = "John", Age = 20, StudentID = "S12345", Major = "Computer Science" },
                new Student { Name = "Alice", Age = 21, StudentID = "S23456", Major = "Mathematics" },
                new Teacher { Name = "Mr. Smith", Age = 35, Department = "Computer Science", Subject = "Programming" },
                new Teacher { Name = "Ms. Johnson", Age = 40, Department = "Mathematics", Subject = "Calculus" },
                new DepartmentHead { Name = "Dr. Brown", Age = 50, Department = "Computer Science", Subject = "Computer Science", YearsOfExperience = 20 },
                new DepartmentHead { Name = "Dr. White", Age = 55, Department = "Mathematics", Subject = "Mathematics", YearsOfExperience = 25 }
            };

            // Виведення масиву впорядкованого за віком
            Console.WriteLine("People sorted by age:");
            Array.Sort(people, (x, y) => x.Age.CompareTo(y.Age));
            foreach (var person in people)
            {
                person.Show();
            }
        }
    }
}
