using System;

namespace Session_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing All Questions ===\n");
            
            // Question 1
            Console.WriteLine("Question 1: Enter a number");
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            Console.WriteLine("You entered: " + number);
            Console.WriteLine("\n-------------------\n");
            
            // Question 2
            Console.WriteLine("Question 2: String to int conversion");
            string str = "123abc";
            try
            {
                int numberFromString = Convert.ToInt32(str);
                Console.WriteLine(numberFromString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Cannot convert string containing non-numeric characters to integer.");
            }
            Console.WriteLine("\n-------------------\n");
            
            // Question 3
            Console.WriteLine("Question 3: Floating-point arithmetic");
            float a = 5.5f;
            float b = 2.2f;
            Console.WriteLine($"Sum: {a + b}");
            Console.WriteLine($"Difference: {a - b}");
            Console.WriteLine($"Product: {a * b}");
            Console.WriteLine($"Quotient: {a / b}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 4
            Console.WriteLine("Question 4: Substring");
            string text = "Hello, World!";
            string substring = text.Substring(7, 5);
            Console.WriteLine($"Original: {text}");
            Console.WriteLine($"Substring: {substring}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 5
            Console.WriteLine("Question 5: Value type");
            int x = 10;
            int y = x;
            y = 20;
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 6
            Console.WriteLine("Question 6: Reference type");
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = arr1;
            arr2[0] = 99;
            Console.WriteLine($"arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 7
            Console.WriteLine("Question 7: String concatenation");
            string firstName = "Ahmed";
            string lastName = "Mohamed";
            Console.WriteLine($"Full name: {firstName} {lastName}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 8
            Console.WriteLine("Question 8: Convert.ToInt32(!(30<20))");
            int d = Convert.ToInt32(!(30 < 20));
            Console.WriteLine($"d = {d}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 9
            Console.WriteLine("Question 9: 13/2 + \" \" + 13%2");
            Console.WriteLine($"Result: {13 / 2 + " " + 13 % 2}");
            Console.WriteLine("\n-------------------\n");
            
            // Question 10
            Console.WriteLine("Question 10: if (!(num <= 0))");
            int num = 1, z = 5;
            if (!(num <= 0))
                Console.WriteLine(++num + z++ + " " + ++z);
            else
                Console.WriteLine(--num + z-- + " " + --z);
        }
    }
}