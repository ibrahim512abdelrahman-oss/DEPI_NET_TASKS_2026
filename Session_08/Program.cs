using System;

namespace Session_08
{
    // ========== Project 1: 3D Point Class ==========
    class Point3D : IComparable, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        // Constructors with chaining
        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x) : this(x, 0, 0) { }
        public Point3D(int x, int y) : this(x, y, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Override ToString
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        // IComparable implementation (sort by X then Y)
        public int CompareTo(object obj)
        {
            Point3D other = obj as Point3D;
            if (other == null) return 1;

            if (this.X != other.X)
                return this.X.CompareTo(other.X);
            else
                return this.Y.CompareTo(other.Y);
        }

        // ICloneable implementation
        public object Clone()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            Point3D other = obj as Point3D;
            if (other == null) return false;
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }

    // ========== Project 2: Maths Class (Static) ==========
    static class Maths
    {
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
        public static double Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return double.NaN;
            }
            return (double)a / b;
        }
    }

    // ========== Project 3: Duration Class ==========
    class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        // Constructors
        public Duration() { }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        // Override ToString
        public override string ToString()
        {
            if (Hours > 0)
                return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
            else if (Minutes > 0)
                return $"Minutes: {Minutes}, Seconds: {Seconds}";
            else
                return $"Seconds: {Seconds}";
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            Duration other = obj as Duration;
            if (other == null) return false;
            return this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        // Operator Overloading
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
        }
        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.Hours * 3600 + d.Minutes * 60 + d.Seconds + seconds);
        }
        public static Duration operator +(int seconds, Duration d) => d + seconds;

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.Hours, d.Minutes + 1, d.Seconds);
        }
        public static Duration operator --(Duration d)
        {
            return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
        }
        public static Duration operator -(Duration d1, Duration d2)
        {
            int total1 = d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds;
            int total2 = d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds;
            return new Duration(total1 - total2);
        }
        public static bool operator >(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) >
                   (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }
        public static bool operator <(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) <
                   (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }
        public static bool operator >=(Duration d1, Duration d2)
        {
            return !(d1 < d2);
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            return !(d1 > d2);
        }
        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
        }
    }

    // ========== Main Program ==========
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Project 1: 3D Point Class ===\n");

            // Read two points from user
            Point3D P1 = ReadPoint("P1");
            Point3D P2 = ReadPoint("P2");

            Console.WriteLine($"\nP1: {P1}");
            Console.WriteLine($"P2: {P2}");

            // Test == (compares references, not values)
            Console.WriteLine($"\nP1 == P2: {P1 == P2} (Reference comparison)");
            Console.WriteLine($"P1.Equals(P2): {P1.Equals(P2)} (Value comparison)");

            // Array of points and sorting
            Point3D[] points = new Point3D[]
            {
                new Point3D(5, 2, 1),
                new Point3D(3, 8, 4),
                new Point3D(3, 2, 7),
                new Point3D(8, 1, 9)
            };

            Console.WriteLine("\nPoints before sorting:");
            foreach (var p in points) Console.WriteLine(p);

            Array.Sort(points);
            Console.WriteLine("\nPoints after sorting by X then Y:");
            foreach (var p in points) Console.WriteLine(p);

            // Test ICloneable
            Point3D clone = (Point3D)P1.Clone();
            Console.WriteLine($"\nClone of P1: {clone}");

            Console.WriteLine("\n=== Project 2: Maths Class ===\n");
            int a = 10, b = 3;
            Console.WriteLine($"Add: {a} + {b} = {Maths.Add(a, b)}");
            Console.WriteLine($"Subtract: {a} - {b} = {Maths.Subtract(a, b)}");
            Console.WriteLine($"Multiply: {a} * {b} = {Maths.Multiply(a, b)}");
            Console.WriteLine($"Divide: {a} / {b} = {Maths.Divide(a, b):F2}");

            Console.WriteLine("\n=== Project 3: Duration Class ===\n");

            Duration D1 = new Duration(1, 10, 15);
            Duration D2 = new Duration(3600);
            Duration D3 = new Duration(7800);
            Duration D4 = new Duration(666);

            Console.WriteLine($"D1: {D1}");
            Console.WriteLine($"D2: {D2}");
            Console.WriteLine($"D3: {D3}");
            Console.WriteLine($"D4: {D4}");

            Console.WriteLine("\n=== Operator Overloading ===\n");
            D3 = D1 + D2;
            Console.WriteLine($"D1 + D2 = {D3}");

            D3 = D1 + 7800;
            Console.WriteLine($"D1 + 7800 = {D3}");

            D3 = 666 + D1;
            Console.WriteLine($"666 + D1 = {D3}");

            D3 = ++D1;
            Console.WriteLine($"++D1 = {D3}");

            D3 = --D2;
            Console.WriteLine($"--D2 = {D3}");

            D3 = D1 - D2;
            Console.WriteLine($"D1 - D2 = {D3}");

            Console.WriteLine($"D1 > D2: {D1 > D2}");
            Console.WriteLine($"D1 <= D2: {D1 <= D2}");

            DateTime dt = (DateTime)D1;
            Console.WriteLine($"D1 as DateTime: {dt:HH:mm:ss}");
        }

        // Helper function to read a point from user
        static Point3D ReadPoint(string name)
        {
            int x, y, z;
            Console.Write($"Enter coordinates for {name} (x y z): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            if (parts.Length >= 3 &&
                int.TryParse(parts[0], out x) &&
                int.TryParse(parts[1], out y) &&
                int.TryParse(parts[2], out z))
            {
                return new Point3D(x, y, z);
            }
            else
            {
                Console.WriteLine("Invalid input. Using default (0,0,0).");
                return new Point3D();
            }
        }
    }
}