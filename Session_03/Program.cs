using System;

namespace Session_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Session 03 - Assignments ===\n");
            
            // Question 1
            Console.WriteLine("Q1: Divisible by 3 and 4");
            Console.Write("Enter a number: ");
            int q1 = int.Parse(Console.ReadLine());
            if (q1 % 3 == 0 && q1 % 4 == 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            Console.WriteLine("-------------------\n");
            
            // Question 2
            Console.WriteLine("Q2: Positive or Negative");
            Console.Write("Enter an integer: ");
            int q2 = int.Parse(Console.ReadLine());
            if (q2 < 0)
                Console.WriteLine("negative");
            else
                Console.WriteLine("positive");
            Console.WriteLine("-------------------\n");
            
            // Question 3
            Console.WriteLine("Q3: Max and Min of 3 numbers");
            Console.Write("Enter three numbers (space separated): ");
            string[] q3 = Console.ReadLine().Split(' ');
            int a = int.Parse(q3[0]);
            int b = int.Parse(q3[1]);
            int c = int.Parse(q3[2]);
            
            int max = Math.Max(a, Math.Max(b, c));
            int min = Math.Min(a, Math.Min(b, c));
            Console.WriteLine($"max element = {max}");
            Console.WriteLine($"min element = {min}");
            Console.WriteLine("-------------------\n");
            
            // Question 4
            Console.WriteLine("Q4: Even or Odd");
            Console.Write("Enter a number: ");
            int q4 = int.Parse(Console.ReadLine());
            if (q4 % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");
            Console.WriteLine("-------------------\n");
            
            // Question 5
            Console.WriteLine("Q5: Vowel or Consonant");
            Console.Write("Enter a character: ");
            char ch = char.ToLower(Console.ReadLine()[0]);
            
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                Console.WriteLine("vowel");
            else
                Console.WriteLine("consonant");
            Console.WriteLine("-------------------\n");
            
            // Question 6
            Console.WriteLine("Q6: Print 1 to N");
            Console.Write("Enter a number: ");
            int q6 = int.Parse(Console.ReadLine());
            for (int i = 1; i <= q6; i++)
            {
                Console.Write(i + (i < q6 ? ", " : ""));
            }
            Console.WriteLine("\n-------------------\n");
            
            // Question 7
            Console.WriteLine("Q7: Multiplication Table up to 12");
            Console.Write("Enter a number: ");
            int q7 = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.Write((q7 * i) + " ");
            }
            Console.WriteLine("\n-------------------\n");
            
            // Question 8
            Console.WriteLine("Q8: Even numbers between 1 and N");
            Console.Write("Enter a number: ");
            int q8 = int.Parse(Console.ReadLine());
            for (int i = 2; i <= q8; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n-------------------\n");
            
            // Question 9
            Console.WriteLine("Q9: Power Calculation");
            Console.Write("Enter base and exponent (space separated): ");
            string[] q9 = Console.ReadLine().Split(' ');
            int baseNum = int.Parse(q9[0]);
            int exp = int.Parse(q9[1]);
            
            long result = 1;
            for (int i = 0; i < exp; i++)
            {
                result *= baseNum;
            }
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("-------------------\n");
            
            // Question 10
            Console.WriteLine("Q10: Marks, Total, Average, Percentage");
            Console.Write("Enter marks of five subjects (space separated): ");
            string[] marks = Console.ReadLine().Split(' ');
            int total = 0;
            
            for (int i = 0; i < marks.Length; i++)
            {
                total += int.Parse(marks[i]);
            }
            
            double average = total / 5.0;
            double percentage = (total / 500.0) * 100;
            
            Console.WriteLine($"Total marks = {total}");
            Console.WriteLine($"Average Marks = {average:F2}");
            Console.WriteLine($"Percentage = {percentage:F2}");
            Console.WriteLine("-------------------\n");

                        // Question 11
            Console.WriteLine("Q11: Number of days in month");
            Console.Write("Enter month number (1-12): ");
            int month = int.Parse(Console.ReadLine());
            
            int days;
            if (month == 2)
                days = 28;
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                days = 30;
            else
                days = 31;
            
            Console.WriteLine($"Days in Month: {days}");
            Console.WriteLine("-------------------\n");
            
            // Question 12
            Console.WriteLine("Q12: Simple Calculator");
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter operator (+, -, *, /): ");
            char op = Console.ReadLine()[0];
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            
            double calcResult = 0;
            switch (op)
            {
                case '+': calcResult = num1 + num2; break;
                case '-': calcResult = num1 - num2; break;
                case '*': calcResult = num1 * num2; break;
                case '/': calcResult = num2 != 0 ? num1 / num2 : 0; break;
                default: Console.WriteLine("Invalid operator"); break;
            }
            
            if (op == '+' || op == '-' || op == '*' || op == '/')
                Console.WriteLine($"Result: {calcResult}");
            Console.WriteLine("-------------------\n");
            
            // Question 13
            Console.WriteLine("Q13: Reverse a string");
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine($"Reversed: {new string(charArray)}");
            Console.WriteLine("-------------------\n");
            
            // Question 14
            Console.WriteLine("Q14: Reverse an integer");
            Console.Write("Enter an integer: ");
            int numToReverse = int.Parse(Console.ReadLine());
            int reversed = 0;
            int temp = numToReverse;
            
            while (temp > 0)
            {
                reversed = reversed * 10 + temp % 10;
                temp /= 10;
            }
            Console.WriteLine($"Reversed: {reversed}");
            Console.WriteLine("-------------------\n");
            
            // Question 15
            Console.WriteLine("Q15: Prime numbers in a range");
            Console.Write("Enter starting number: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter ending number: ");
            int end = int.Parse(Console.ReadLine());
            
            Console.Write($"Prime numbers between {start} and {end}: ");
            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;
                if (i < 2) isPrime = false;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    Console.Write(i + " ");
            }
            Console.WriteLine("\n-------------------\n");
            
            // Question 16
            Console.WriteLine("Q16: Decimal to Binary");
            Console.Write("Enter a decimal number: ");
            int decimalNum = int.Parse(Console.ReadLine());
            string binary = "";
            int tempDecimal = decimalNum;
            
            if (tempDecimal == 0)
                binary = "0";
            else
            {
                while (tempDecimal > 0)
                {
                    binary = (tempDecimal % 2) + binary;
                    tempDecimal /= 2;
                }
            }
            Console.WriteLine($"Binary of {decimalNum} is {binary}");
            Console.WriteLine("-------------------\n");
            
            // Question 17
            Console.WriteLine("Q17: Check if points lie on a straight line");
            Console.Write("Enter x1 y1: ");
            string[] p1 = Console.ReadLine().Split(' ');
            Console.Write("Enter x2 y2: ");
            string[] p2 = Console.ReadLine().Split(' ');
            Console.Write("Enter x3 y3: ");
            string[] p3 = Console.ReadLine().Split(' ');
            
            double x1 = double.Parse(p1[0]), y1 = double.Parse(p1[1]);
            double x2 = double.Parse(p2[0]), y2 = double.Parse(p2[1]);
            double x3 = double.Parse(p3[0]), y3 = double.Parse(p3[1]);
            
            // Check if slopes are equal
            double slope12 = (y2 - y1) / (x2 - x1);
            double slope13 = (y3 - y1) / (x3 - x1);
            
            if (Math.Abs(slope12 - slope13) < 0.000001)
                Console.WriteLine("Points lie on a straight line");
            else
                Console.WriteLine("Points do NOT lie on a straight line");
            Console.WriteLine("-------------------\n");
            
            // Question 18
            Console.WriteLine("Q18: Worker Efficiency");
            Console.Write("Enter time taken (in hours): ");
            double time = double.Parse(Console.ReadLine());
            
            if (time >= 2 && time < 3)
                Console.WriteLine("Highly efficient");
            else if (time >= 3 && time < 4)
                Console.WriteLine("Increase your speed");
            else if (time >= 4 && time < 5)
                Console.WriteLine("Training required");
            else if (time >= 5)
                Console.WriteLine("Leave the company");
            else
                Console.WriteLine("Invalid time (must be >= 2 hours)");
            Console.WriteLine("-------------------\n");

                        // Question 19
            Console.WriteLine("Q19: Identity Matrix");
            Console.Write("Enter size n: ");
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Identity Matrix of size {n}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write((i == j ? "1 " : "0 "));
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------\n");
            
            // Question 20
            Console.WriteLine("Q20: Sum of array elements");
            Console.Write("Enter array size: ");
            int size20 = int.Parse(Console.ReadLine());
            int[] arr20 = new int[size20];
            
            Console.WriteLine($"Enter {size20} numbers:");
            for (int i = 0; i < size20; i++)
            {
                arr20[i] = int.Parse(Console.ReadLine());
            }
            
            int sum = 0;
            foreach (int num in arr20)
                sum += num;
            
            Console.WriteLine($"Sum of array elements = {sum}");
            Console.WriteLine("-------------------\n");
            
            // Question 21
            Console.WriteLine("Q21: Merge two sorted arrays");
            Console.Write("Enter size of arrays: ");
            int size21 = int.Parse(Console.ReadLine());
            int[] arr21a = new int[size21];
            int[] arr21b = new int[size21];
            
            Console.WriteLine($"Enter {size21} numbers for first array:");
            for (int i = 0; i < size21; i++)
                arr21a[i] = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Enter {size21} numbers for second array:");
            for (int i = 0; i < size21; i++)
                arr21b[i] = int.Parse(Console.ReadLine());
            
            Array.Sort(arr21a);
            Array.Sort(arr21b);
            
            int[] merged = new int[size21 * 2];
            arr21a.CopyTo(merged, 0);
            arr21b.CopyTo(merged, size21);
            Array.Sort(merged);
            
            Console.WriteLine("Merged sorted array:");
            foreach (int num in merged)
                Console.Write(num + " ");
            Console.WriteLine("\n-------------------\n");
            
            // Question 22
            Console.WriteLine("Q22: Count frequency of each element");
            Console.Write("Enter array size: ");
            int size22 = int.Parse(Console.ReadLine());
            int[] arr22 = new int[size22];
            
            Console.WriteLine($"Enter {size22} numbers:");
            for (int i = 0; i < size22; i++)
                arr22[i] = int.Parse(Console.ReadLine());
            
            bool[] counted = new bool[size22];
            Console.WriteLine("Element : Frequency");
            for (int i = 0; i < size22; i++)
            {
                if (!counted[i])
                {
                    int count = 1;
                    for (int j = i + 1; j < size22; j++)
                    {
                        if (arr22[i] == arr22[j])
                        {
                            count++;
                            counted[j] = true;
                        }
                    }
                    Console.WriteLine($"{arr22[i]} : {count}");
                }
            }
            Console.WriteLine("-------------------\n");
            
            // Question 23
            Console.WriteLine("Q23: Max and Min in array");
            Console.Write("Enter array size: ");
            int size23 = int.Parse(Console.ReadLine());
            int[] arr23 = new int[size23];
            
            Console.WriteLine($"Enter {size23} numbers:");
            for (int i = 0; i < size23; i++)
                arr23[i] = int.Parse(Console.ReadLine());
            
            int max23 = arr23[0];
            int min23 = arr23[0];
            foreach (int num in arr23)
            {
                if (num > max23) max23 = num;
                if (num < min23) min23 = num;
            }
            
            Console.WriteLine($"Maximum element = {max23}");
            Console.WriteLine($"Minimum element = {min23}");
            Console.WriteLine("-------------------\n");
            
            // Question 24
            Console.WriteLine("Q24: Second largest element");
            Console.Write("Enter array size: ");
            int size24 = int.Parse(Console.ReadLine());
            int[] arr24 = new int[size24];
            
            Console.WriteLine($"Enter {size24} numbers:");
            for (int i = 0; i < size24; i++)
                arr24[i] = int.Parse(Console.ReadLine());
            
            Array.Sort(arr24);
            int secondLargest = arr24[size24 - 2];
            Console.WriteLine($"Second largest element = {secondLargest}");
            Console.WriteLine("-------------------\n");
            
            // Question 25
            Console.WriteLine("Q25: Longest distance between equal cells");
            Console.Write("Enter array size: ");
            int size25 = int.Parse(Console.ReadLine());
            int[] arr25 = new int[size25];
            
            Console.WriteLine($"Enter {size25} numbers:");
            for (int i = 0; i < size25; i++)
                arr25[i] = int.Parse(Console.ReadLine());
            
            int maxDistance = 0;
            for (int i = 0; i < size25; i++)
            {
                for (int j = i + 1; j < size25; j++)
                {
                    if (arr25[i] == arr25[j])
                    {
                        int distance = j - i - 1;
                        if (distance > maxDistance)
                            maxDistance = distance;
                    }
                }
            }
            
            Console.WriteLine($"Longest distance = {maxDistance}");
            Console.WriteLine("-------------------\n");
            
            // Question 26
            Console.WriteLine("Q26: Reverse words");
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            Console.WriteLine($"Reversed: {string.Join(" ", words)}");
            Console.WriteLine("-------------------\n");
            
            // Question 27
            Console.WriteLine("Q27: Copy 2D array");
            Console.Write("Enter number of rows and columns: ");
            string[] dims = Console.ReadLine().Split(' ');
            int rows = int.Parse(dims[0]);
            int cols = int.Parse(dims[1]);
            
            int[,] firstArray = new int[rows, cols];
            int[,] secondArray = new int[rows, cols];
            
            Console.WriteLine("Enter elements of first array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"[{i},{j}]: ");
                    firstArray[i, j] = int.Parse(Console.ReadLine());
                    secondArray[i, j] = firstArray[i, j];
                }
            }
            
            Console.WriteLine("\nSecond array (copied):");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(secondArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------\n");
            
            // Question 28
            Console.WriteLine("Q28: Print array in reverse order");
            Console.Write("Enter array size: ");
            int size28 = int.Parse(Console.ReadLine());
            int[] arr28 = new int[size28];
            
            Console.WriteLine($"Enter {size28} numbers:");
            for (int i = 0; i < size28; i++)
                arr28[i] = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Array in reverse order:");
            for (int i = size28 - 1; i >= 0; i--)
            {
                Console.Write(arr28[i] + " ");
            }
            Console.WriteLine("\n-------------------\n");
        }
    }
}