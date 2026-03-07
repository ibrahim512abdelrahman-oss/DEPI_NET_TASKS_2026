using System;

namespace Session_05
{
    class Program
    {
        // ========== Enums & Structs ==========
        enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        enum Season { Spring, Summer, Autumn, Winter }
        [Flags] enum Permissions { None = 0, Read = 1, Write = 2, Delete = 4, Execute = 8 }
        enum Colors { Red, Green, Blue }

        struct Person { public string Name; public int Age; }
        struct Point { public double X; public double Y; }

        static void Main(string[] args)
        {
            // ========== Q1: WeekDays Enum ==========
            Console.WriteLine("=== Q1: Week Days Enum ===");
            Console.WriteLine("All days of the week:");
            foreach (string day in Enum.GetNames(typeof(WeekDays)))
                Console.WriteLine(day);
            Console.WriteLine();

            // ========== Q2: Array of Persons ==========
            Console.WriteLine("=== Q2: Array of Persons ===");
            Person[] persons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                persons[i].Name = Console.ReadLine();
                Console.Write($"Enter age of person {i + 1}: ");
                persons[i].Age = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nPersons Details:");
            foreach (var p in persons)
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            Console.WriteLine();

            // ========== Q3: Season Months ==========
            Console.WriteLine("=== Q3: Season Months ===");
            Console.Write("Enter season name (Spring, Summer, Autumn, Winter): ");
            string seasonInput = Console.ReadLine();
            if (Enum.TryParse(seasonInput, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring: Console.WriteLine("Spring: March to May"); break;
                    case Season.Summer: Console.WriteLine("Summer: June to August"); break;
                    case Season.Autumn: Console.WriteLine("Autumn: September to November"); break;
                    case Season.Winter: Console.WriteLine("Winter: December to February"); break;
                }
            }
            else Console.WriteLine("Invalid season name.");
            Console.WriteLine();

            // ========== Q4: Permissions Enum ==========
            Console.WriteLine("=== Q4: Permissions (Add/Remove/Check) ===");
            Permissions userPerm = Permissions.None;
            userPerm |= Permissions.Read;
            userPerm |= Permissions.Write;
            Console.WriteLine($"After adding Read and Write: {userPerm}");
            userPerm &= ~Permissions.Write;
            Console.WriteLine($"After removing Write: {userPerm}");
            Console.WriteLine($"Has Read: {(userPerm.HasFlag(Permissions.Read) ? "Yes" : "No")}");
            Console.WriteLine($"Has Execute: {(userPerm.HasFlag(Permissions.Execute) ? "Yes" : "No")}");
            Console.WriteLine();

            // ========== Q5: Colors Primary ==========
            Console.WriteLine("=== Q5: Primary Colors ===");
            Console.Write("Enter a color name: ");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out Colors color))
                Console.WriteLine($"{colorInput} is a primary color.");
            else
                Console.WriteLine($"{colorInput} is NOT a primary color.");
            Console.WriteLine();

            // ========== Q6: Distance Between Points ==========
            Console.WriteLine("=== Q6: Distance Between Two Points ===");
            Point p1, p2;
            Console.Write("Enter X and Y of first point (space separated): ");
            string[] p1Input = Console.ReadLine().Split();
            p1.X = double.Parse(p1Input[0]);
            p1.Y = double.Parse(p1Input[1]);

            Console.Write("Enter X and Y of second point (space separated): ");
            string[] p2Input = Console.ReadLine().Split();
            p2.X = double.Parse(p2Input[0]);
            p2.Y = double.Parse(p2Input[1]);

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"Distance: {distance:F2}");
            Console.WriteLine();

            // ========== Q7: Oldest Person ==========
            Console.WriteLine("=== Q7: Oldest Person ===");
            Person[] people = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                people[i].Name = Console.ReadLine();
                Console.Write($"Enter age of person {i + 1}: ");
                people[i].Age = int.Parse(Console.ReadLine());
            }

            Person oldest = people[0];
            foreach (var p in people)
                if (p.Age > oldest.Age) oldest = p;

            Console.WriteLine($"Oldest: {oldest.Name}, Age: {oldest.Age}\n");
        }
    }
}