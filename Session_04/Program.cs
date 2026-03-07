using System;

namespace Session_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q1
            Console.WriteLine("=== Q1: Value Type - By Value vs By Reference ===");
            int a = 10, b = 10;
            ByVal(a);
            Console.WriteLine($"After ByVal, original a: {a}");
            ByRef(ref b);
            Console.WriteLine($"After ByRef, original b: {b}");
            Console.WriteLine("Explanation: ByVal sends a copy, original unchanged. ByRef sends the reference, original can change.\n");

            // Q2
            Console.WriteLine("=== Q2: Reference Type - By Value vs By Reference ===");
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { 1, 2, 3 };
            ByVal(arr1);
            Console.WriteLine($"After ByVal, arr1[0]: {arr1[0]}");
            ByRef(ref arr2);
            Console.WriteLine($"After ByRef, arr2[0]: {arr2[0]}");
            Console.WriteLine("Explanation: ByVal can modify object but not reassign. ByRef can reassign and modify.\n");

            // Q3
            Console.WriteLine("=== Q3: Sum and Subtract ===");
            Console.Write("Enter 4 numbers (space separated): ");
            string[] input3 = Console.ReadLine().Split();
            int x1 = int.Parse(input3[0]), x2 = int.Parse(input3[1]), x3 = int.Parse(input3[2]), x4 = int.Parse(input3[3]);
            var (sum, sub) = SumAndSubtract(x1, x2, x3, x4);
            Console.WriteLine($"Sum of first two: {sum}");
            Console.WriteLine($"Subtraction of last two: {sub}\n");

            // Q4
            Console.WriteLine("=== Q4: Sum of Digits ===");
            Console.Write("Enter a number: ");
            int num4 = int.Parse(Console.ReadLine());
            Console.WriteLine($"The sum of digits of {num4} is: {SumDigits(num4)}\n");

            // Q5
            Console.WriteLine("=== Q5: IsPrime ===");
            Console.Write("Enter a number: ");
            int num5 = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(num5) ? "Prime\n" : "Not Prime\n");

            // Q6
            Console.WriteLine("=== Q6: Min and Max in Array ===");
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine($"Enter {size} numbers:");
            for (int i = 0; i < size; i++) arr[i] = int.Parse(Console.ReadLine());
            int min = 0, max = 0;
            MinMaxArray(arr, ref min, ref max);
            Console.WriteLine($"Min = {min}, Max = {max}\n");

            // Q7
            Console.WriteLine("=== Q7: Factorial ===");
            Console.Write("Enter a number: ");
            int n7 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Factorial of {n7} = {Factorial(n7)}\n");

            // Q8
            Console.WriteLine("=== Q8: Change Character in String ===");
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            Console.Write("Enter position (0-based): ");
            int pos = int.Parse(Console.ReadLine());
            Console.Write("Enter new character: ");
            char newChar = Console.ReadLine()[0];
            Console.WriteLine($"Modified string: {ChangeChar(str, pos, newChar)}\n");
        }

        // Q1 functions
        static void ByVal(int x) => x = 100;
        static void ByRef(ref int x) => x = 100;

        // Q2 functions
        static void ByVal(int[] x) => x[0] = 99;
        static void ByRef(ref int[] x) => x = new int[] { 99, 99, 99 };

        // Q3 function
        static (int, int) SumAndSubtract(int w, int x, int y, int z) => (w + x, y - z);

        // Q4 function
        static int SumDigits(int n)
        {
            int sum = 0;
            while (n != 0) { sum += n % 10; n /= 10; }
            return sum;
        }

        // Q5 function
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
            return true;
        }

        // Q6 function
        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = max = arr[0];
            foreach (int num in arr) { if (num < min) min = num; if (num > max) max = num; }
        }

        // Q7 function
        static long Factorial(int n)
        {
            long fact = 1;
            for (int i = 2; i <= n; i++) fact *= i;
            return fact;
        }

        // Q8 function
        static string ChangeChar(string s, int index, char c)
        {
            char[] chars = s.ToCharArray();
            if (index >= 0 && index < chars.Length) chars[index] = c;
            return new string(chars);
        }
    }
}

