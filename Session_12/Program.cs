using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Session_12
{
    // ==== ListGenerator.cs (Simplified for demo) ====
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }

    public static class ListGenerator
    {
        public static List<Product> ProductList { get; set; }
        public static List<Customer> CustomerList { get; set; }

        static ListGenerator()
        {
            ProductList = new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Product A", Category = "Category 1", UnitPrice = 10.5m, UnitsInStock = 0 },
                new Product { ProductID = 2, ProductName = "Product B", Category = "Category 1", UnitPrice = 5.75m, UnitsInStock = 10 },
                new Product { ProductID = 3, ProductName = "Product C", Category = "Category 2", UnitPrice = 20.0m, UnitsInStock = 5 },
                new Product { ProductID = 4, ProductName = "Product D", Category = "Category 2", UnitPrice = 1500.0m, UnitsInStock = 2 },
                new Product { ProductID = 5, ProductName = "Product E", Category = "Category 3", UnitPrice = 7.5m, UnitsInStock = 0 }
            };

            CustomerList = new List<Customer>
            {
                new Customer { CustomerID = "C1", CustomerName = "Customer 1", Orders = new List<Order> {
                    new Order { OrderID = 101, OrderDate = new DateTime(2022, 5, 10), Total = 450.50m },
                    new Order { OrderID = 102, OrderDate = new DateTime(2023, 6, 15), Total = 600.75m }
                }},
                new Customer { CustomerID = "C2", CustomerName = "Customer 2", Orders = new List<Order> {
                    new Order { OrderID = 201, OrderDate = new DateTime(2021, 8, 20), Total = 300.00m },
                    new Order { OrderID = 202, OrderDate = new DateTime(2023, 9, 25), Total = 1200.00m }
                }}
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Load products and customers
            var products = ListGenerator.ProductList;
            var customers = ListGenerator.CustomerList;

            // ========== LINQ - Restriction Operators ==========
            Console.WriteLine("=== Restriction Operators ===\n");

            // 1. Find all products that are out of stock
            var outOfStock = products.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("1. Out of stock products:");
            foreach (var p in outOfStock) Console.WriteLine($"   {p.ProductName}");

            // 2. Find all products that are in stock and cost more than 3.00 per unit
            var inStockExpensive = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
            Console.WriteLine("\n2. In stock and price > 3.00:");
            foreach (var p in inStockExpensive) Console.WriteLine($"   {p.ProductName} - {p.UnitPrice:C}");

            // 3. Returns digits whose name is shorter than their value
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where((name, index) => name.Length < index);
            Console.WriteLine("\n3. Digits with name shorter than value:");
            foreach (var d in shortDigits) Console.WriteLine($"   {d}");

            // ========== LINQ - Element Operators ==========
            Console.WriteLine("\n=== Element Operators ===\n");

            // 1. Get first product out of stock
            var firstOutOfStock = products.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"1. First out of stock: {firstOutOfStock?.ProductName}");

            // 2. First product with Price > 1000, else null
            var expensiveProduct = products.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"2. First product > 1000: {expensiveProduct?.ProductName ?? "null"}");

            // 3. Retrieve the second number greater than 5
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondGreaterThanFive = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"3. Second number > 5: {secondGreaterThanFive}");

            // ========== LINQ - Aggregate Operators ==========
            Console.WriteLine("\n=== Aggregate Operators ===\n");

            // 1. Count odd numbers
            int oddCount = numbers.Count(n => n % 2 != 0);
            Console.WriteLine($"1. Odd numbers count: {oddCount}");

            // 2. Customers and how many orders each has
            Console.WriteLine("\n2. Customers order count:");
            foreach (var c in customers)
                Console.WriteLine($"   {c.CustomerName}: {c.Orders.Count} orders");

            // 3. Return a list of categories and how many products each has (from products)
            var categoryCount = products.GroupBy(p => p.Category)
                                        .Select(g => new { Category = g.Key, Count = g.Count() });
            Console.WriteLine("\n3. Categories product count:");
            foreach (var c in categoryCount)
                Console.WriteLine($"   {c.Category}: {c.Count} products");

            // 4. Get total of numbers in array
            int totalSum = numbers.Sum();
            Console.WriteLine($"\n4. Total sum of numbers: {totalSum}");

            // 5-8. Dictionary operations (requires dictionary_english.txt)
            // For demo, using a sample array
            string[] dictionary = File.Exists("dictionary_english.txt") 
                ? File.ReadAllLines("dictionary_english.txt") 
                : new[] { "apple", "banana", "cat", "dog", "elephant", "fish" };

            int totalChars = dictionary.Sum(w => w.Length);
            int shortestLength = dictionary.Min(w => w.Length);
            int longestLength = dictionary.Max(w => w.Length);
            double avgLength = dictionary.Average(w => w.Length);

            Console.WriteLine($"\n5. Total characters: {totalChars}");
            Console.WriteLine($"6. Shortest word length: {shortestLength}");
            Console.WriteLine($"7. Longest word length: {longestLength}");
            Console.WriteLine($"8. Average word length: {avgLength:F2}");

            // ========== LINQ - Ordering Operators ==========
            Console.WriteLine("\n=== Ordering Operators ===\n");

            // 1. Sort products by name
            var sortedByName = products.OrderBy(p => p.ProductName);
            Console.WriteLine("1. Products sorted by name:");
            foreach (var p in sortedByName) Console.WriteLine($"   {p.ProductName}");

            // 2. Case-insensitive sort (custom comparer)
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var caseInsensitiveSort = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n2. Case-insensitive sort:");
            foreach (var w in caseInsensitiveSort) Console.WriteLine($"   {w}");

            // 3. Sort products by units in stock from highest to lowest
            var sortedByStock = products.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("\n3. Products by stock (highest first):");
            foreach (var p in sortedByStock) Console.WriteLine($"   {p.ProductName}: {p.UnitsInStock} units");

            // 4. Sort digits by length, then alphabetically
            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("\n4. Digits sorted by length then name:");
            foreach (var d in sortedDigits) Console.WriteLine($"   {d}");

            // 5. Sort first by length, then case-insensitive
            var sortedWords = words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n5. Words by length, then case-insensitive:");
            foreach (var w in sortedWords) Console.WriteLine($"   {w}");

            // 6. Sort products by category, then by price descending
            var sortedProducts = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("\n6. Products by category, then price (desc):");
            foreach (var p in sortedProducts) Console.WriteLine($"   {p.Category} - {p.ProductName}: {p.UnitPrice:C}");

            // 7. Sort by length, then case-insensitive descending
            var sortedWordsDesc = words.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n7. By length, then case-insensitive descending:");
            foreach (var w in sortedWordsDesc) Console.WriteLine($"   {w}");

            // 8. Digits whose second letter is 'i', reversed order
            var secondLetterI = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            Console.WriteLine("\n8. Digits with second letter 'i', reversed:");
            foreach (var d in secondLetterI) Console.WriteLine($"   {d}");

            // ========== LINQ - Transformation Operators ==========
            Console.WriteLine("\n=== Transformation Operators ===\n");

            // 1. Just the names of products
            var productNames = products.Select(p => p.ProductName);
            Console.WriteLine("1. Product names:");
            foreach (var n in productNames) Console.WriteLine($"   {n}");

            // 2. Uppercase and lowercase versions (Anonymous Types)
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var versions = words2.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("\n2. Uppercase/Lowercase versions:");
            foreach (var v in versions) Console.WriteLine($"   Upper: {v.Upper}, Lower: {v.Lower}");

            // 3. Some properties with UnitPrice renamed to Price
            var productInfo = products.Select(p => new { p.ProductName, Price = p.UnitPrice, p.Category });
            Console.WriteLine("\n3. Product info (Price renamed):");
            foreach (var p in productInfo) Console.WriteLine($"   {p.ProductName}: {p.Price:C} ({p.Category})");

            // 4. Values match their position in array
            var matches = numbers.Select((val, index) => new { Value = val, Index = index, Match = val == index });
            Console.WriteLine("\n4. Numbers matching their index:");
            foreach (var m in matches) Console.WriteLine($"   {m.Value} at {m.Index}: {m.Match}");

            // 5. Pairs where numbersA < numbersB
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { A = a, B = b };
            Console.WriteLine("\n5. Pairs where a < b:");
            foreach (var p in pairs) Console.WriteLine($"   {p.A} is less than {p.B}");

            // 6. Orders with total < 500
            var smallOrders = customers.SelectMany(c => c.Orders).Where(o => o.Total < 500);
            Console.WriteLine("\n6. Orders with total < 500:");
            foreach (var o in smallOrders) Console.WriteLine($"   Order {o.OrderID}: {o.Total:C}");

            // 7. Orders made in 1998 or later
            var recentOrders = customers.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            Console.WriteLine("\n7. Orders made in 1998 or later:");
            foreach (var o in recentOrders) Console.WriteLine($"   Order {o.OrderID}: {o.OrderDate:yyyy-MM-dd}");
        }
    }
}