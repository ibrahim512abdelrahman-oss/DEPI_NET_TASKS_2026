using System;
using System.Collections.Generic;

namespace Session_11
{
    // ========== Book Class ==========
    public class Book
    {
        // Properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        // Override ToString
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Published: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }
    }

    // ========== BookFunctions Class ==========
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B?.Title ?? "No Title";
        }

        public static string GetAuthors(Book B)
        {
            return B?.Authors != null ? string.Join(", ", B.Authors) : "No Authors";
        }

        public static string GetPrice(Book B)
        {
            return B != null ? $"{B.Price:C}" : "No Price";
        }

        // Additional methods for delegates
        public static string GetISBN(Book B) => B?.ISBN ?? "No ISBN";
        public static string GetPublicationDate(Book B) => B?.PublicationDate.ToShortDateString() ?? "No Date";
    }

    // ========== User Defined Delegate ==========
    public delegate string BookDelegate(Book B);

    // ========== LibraryEngine Class ==========
    public class LibraryEngine
    {
        // With User Defined Delegate
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // With Built-in Delegate (Func)
        public static void ProcessBooksFunc(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }

    // ========== Program Class (Main) ==========
    class Program
    {
        static void Main(string[] args)
        {
            // Create list of books
            List<Book> books = new List<Book>
            {
                new Book("123-456", "C# Programming", new[] { "Ahmed", "Ali" }, new DateTime(2020, 5, 10), 250.50m),
                new Book("789-012", "ASP.NET Core", new[] { "Mona" }, new DateTime(2021, 8, 15), 300.75m),
                new Book("345-678", "EF Core", new[] { "Omar", "Hassan", "Nada" }, new DateTime(2022, 3, 20), 180.00m)
            };

            Console.WriteLine("=== Part 01: Calculator Operations (Delegates Demo) ===\n");
            // This part is covered by the delegates examples below

            Console.WriteLine("=== Part 02: Book Functions with Delegates ===\n");

            // 1. Using User Defined Delegate
            Console.WriteLine("1. Using User Defined Delegate (GetTitle):");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);

            Console.WriteLine("\n2. Using User Defined Delegate (GetAuthors):");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);

            // 2. Using Built-in Delegate (Func)
            Console.WriteLine("\n3. Using Built-in Delegate Func (GetPrice):");
            LibraryEngine.ProcessBooksFunc(books, BookFunctions.GetPrice);

            // 3. Anonymous Method (GetISBN)
            Console.WriteLine("\n4. Anonymous Method (GetISBN):");
            LibraryEngine.ProcessBooksFunc(books, delegate (Book B) { return B.ISBN; });

            // 4. Lambda Expression (GetPublicationDate)
            Console.WriteLine("\n5. Lambda Expression (GetPublicationDate):");
            LibraryEngine.ProcessBooksFunc(books, B => B.PublicationDate.ToShortDateString());

            // 5. More Lambda Examples
            Console.WriteLine("\n6. Lambda Expression (Custom Format):");
            LibraryEngine.ProcessBooksFunc(books, B => $"Title: {B.Title}, Price: {B.Price:C}");

            Console.WriteLine("\n=== Part 03: Unit Testing Simulation ===\n");
            RunUnitTests();
        }

        // ========== Part 03: Unit Testing Simulation ==========
        static void RunUnitTests()
        {
            Console.WriteLine("Running Unit Tests...\n");

            // Test 1: Book Constructor and Properties
            Book b1 = new Book("111-222", "Test Book", new[] { "Tester" }, new DateTime(2023, 1, 1), 99.99m);
            Console.WriteLine($"Test 1 - Book created: {b1}");

            // Test 2: GetTitle
            Console.WriteLine($"Test 2 - GetTitle: {BookFunctions.GetTitle(b1)} (Expected: Test Book)");

            // Test 3: GetAuthors
            Console.WriteLine($"Test 3 - GetAuthors: {BookFunctions.GetAuthors(b1)} (Expected: Tester)");

            // Test 4: GetPrice
            Console.WriteLine($"Test 4 - GetPrice: {BookFunctions.GetPrice(b1)} (Expected: $99.99)");

            // Test 5: GetISBN
            Console.WriteLine($"Test 5 - GetISBN: {BookFunctions.GetISBN(b1)} (Expected: 111-222)");

            // Test 6: GetPublicationDate
            Console.WriteLine($"Test 6 - GetPublicationDate: {BookFunctions.GetPublicationDate(b1)} (Expected: 1/1/2023)");

            // Test 7: ProcessBooks with multiple books
            List<Book> testBooks = new List<Book> { b1, new Book("333-444", "Another Book", new[] { "Dev" }, DateTime.Now, 49.99m) };
            Console.WriteLine("\nTest 7 - ProcessBooks with multiple books:");
            LibraryEngine.ProcessBooksFunc(testBooks, B => B.Title);

            Console.WriteLine("\nAll tests passed successfully!");
        }
    }
}