using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Session_13_LINQ
{
    // تعريف Product و Customer و Order (عشان نشتغل معاهم)
    public class Product
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public override string ToString() => $"{ProductName} - {Category} - {UnitPrice:C} - Stock: {UnitsInStock}";
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public override string ToString() => $"Order {OrderID}: {OrderDate.ToShortDateString()} - {Total:C}";
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Order[] Orders { get; set; }
        public override string ToString() => $"{CustomerID} - {CustomerName} ({City}, {Country})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LINQ Assignment 13 ===\n");

            // تحميل البيانات من ListGenerators
            var productList = GetProductList();
            var customerList = GetCustomerList();

            // تحميل القاموس
            var dictionary = File.Exists("dictionary_english.txt")
                ? File.ReadAllLines("dictionary_english.txt")
                : new[] { "apple", "banana", "cat", "dog", "elephant" };

            // ========== Element Operators ==========
            Console.WriteLine("=== Element Operators ===");
            var firstOutOfStock = productList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"1. First out of stock: {firstOutOfStock?.ProductName ?? "None"}");

            var firstPriceOver1000 = productList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"2. First price > 1000: {firstPriceOver1000?.ProductName ?? "null"}");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondGreaterThan5 = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"3. Second number > 5: {secondGreaterThan5}");

            // ========== Aggregate Operators ==========
            Console.WriteLine("\n=== Aggregate Operators ===");
            var oddCount = numbers.Count(n => n % 2 != 0);
            Console.WriteLine($"1. Odd numbers count: {oddCount}");

            Console.WriteLine("2. Customers order count:");
            foreach (var c in customerList)
                Console.WriteLine($"   {c.CustomerName}: {c.Orders.Length} orders");

            var categoryCount = productList.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() });
            Console.WriteLine("3. Categories product count:");
            foreach (var c in categoryCount)
                Console.WriteLine($"   {c.Category}: {c.Count}");

            var totalSum = numbers.Sum();
            Console.WriteLine($"4. Total sum: {totalSum}");

            var totalChars = dictionary.Sum(w => w.Length);
            Console.WriteLine($"5. Total characters: {totalChars}");

            var shortestLength = dictionary.Min(w => w.Length);
            var longestLength = dictionary.Max(w => w.Length);
            var avgLength = dictionary.Average(w => w.Length);
            Console.WriteLine($"6. Shortest word length: {shortestLength}");
            Console.WriteLine($"7. Longest word length: {longestLength}");
            Console.WriteLine($"8. Average word length: {avgLength:F2}");

            // ========== Set Operators ==========
            Console.WriteLine("\n=== Set Operators ===");
            var uniqueCategories = productList.Select(p => p.Category).Distinct();
            Console.WriteLine("1. Unique categories:");
            foreach (var cat in uniqueCategories)
                Console.WriteLine($"   {cat}");

            var productFirstLetters = productList.Select(p => p.ProductName[0]);
            var customerFirstLetters = customerList.Select(c => c.CustomerName[0]);
            var allFirstLetters = productFirstLetters.Union(customerFirstLetters);
            Console.WriteLine("2. Unique first letters from products & customers:");
            foreach (var letter in allFirstLetters.OrderBy(l => l))
                Console.Write($"{letter} ");
            Console.WriteLine();

            var commonLetters = productFirstLetters.Intersect(customerFirstLetters);
            Console.WriteLine("3. Common first letters:");
            foreach (var letter in commonLetters.OrderBy(l => l))
                Console.Write($"{letter} ");
            Console.WriteLine();

            var productOnlyLetters = productFirstLetters.Except(customerFirstLetters);
            Console.WriteLine("4. First letters only in products:");
            foreach (var letter in productOnlyLetters.OrderBy(l => l))
                Console.Write($"{letter} ");
            Console.WriteLine();

            var lastThreeChars = productList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName)
                .Concat(customerList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName));
            Console.WriteLine("5. Last 3 characters (with duplicates):");
            foreach (var chars in lastThreeChars.Take(10))
                Console.Write($"{chars} ");
            Console.WriteLine("...");

            // ========== Partitioning Operators ==========
            Console.WriteLine("\n=== Partitioning Operators ===");
            var first3Orders = customerList.Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders).Take(3);
            Console.WriteLine("1. First 3 orders from Washington:");
            foreach (var o in first3Orders)
                Console.WriteLine($"   {o}");

            var allButFirst2 = customerList.Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders).Skip(2);
            Console.WriteLine("2. All but first 2 orders from Washington:");
            foreach (var o in allButFirst2.Take(5))
                Console.WriteLine($"   {o}");
            Console.WriteLine("   ...");

            var numbersArray = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var untilLessThanPosition = numbersArray.TakeWhile((n, i) => n >= i);
            Console.WriteLine("3. Elements until number < its position:");
            foreach (var n in untilLessThanPosition)
                Console.Write($"{n} ");
            Console.WriteLine();

            var startFromDivisibleBy3 = numbersArray.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("4. Elements from first divisible by 3:");
            foreach (var n in startFromDivisibleBy3)
                Console.Write($"{n} ");
            Console.WriteLine();

            var startFromLessThanPosition = numbersArray.SkipWhile((n, i) => n >= i);
            Console.WriteLine("5. Elements from first less than its position:");
            foreach (var n in startFromLessThanPosition)
                Console.Write($"{n} ");
            Console.WriteLine();

            // ========== Quantifiers ==========
            Console.WriteLine("\n=== Quantifiers ===");
            var containsEI = dictionary.Any(w => w.Contains("ei"));
            Console.WriteLine($"1. Any word contains 'ei': {containsEI}");

            var categoriesWithOutOfStock = productList.GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => g.Key);
            Console.WriteLine("2. Categories with at least one out of stock:");
            foreach (var cat in categoriesWithOutOfStock)
                Console.WriteLine($"   {cat}");

            var categoriesAllInStock = productList.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => g.Key);
            Console.WriteLine("3. Categories with all products in stock:");
            foreach (var cat in categoriesAllInStock)
                Console.WriteLine($"   {cat}");

            // ========== Grouping Operators ==========
            Console.WriteLine("\n=== Grouping Operators ===");
            var numbersList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var groupedByRemainder = numbersList.GroupBy(n => n % 5);
            Console.WriteLine("1. Numbers grouped by remainder when divided by 5:");
            foreach (var group in groupedByRemainder)
                Console.WriteLine($"   Remainder {group.Key}: {string.Join(", ", group)}");

            var wordsByFirstLetter = dictionary.GroupBy(w => w[0]).OrderBy(g => g.Key);
            Console.WriteLine("2. Words grouped by first letter:");
            foreach (var group in wordsByFirstLetter.Take(5))
                Console.WriteLine($"   {group.Key}: {group.Count()} words");

            string[] arr = { "from", "salt", "earn", "last", "near", "form" };
            var groupedByAnagram = arr.GroupBy(w => new string(w.OrderBy(c => c).ToArray()));
            Console.WriteLine("3. Words grouped by same characters (anagrams):");
            foreach (var group in groupedByAnagram)
                Console.WriteLine($"   {string.Join(", ", group)}");

            Console.WriteLine("\n✅ All LINQ operations completed!");
        }

        // ========== Product List (زي ListGenerators) ==========
        static List<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00M, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00M, UnitsInStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35M, UnitsInStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00M, UnitsInStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00M, UnitsInStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00M, UnitsInStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00M, UnitsInStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00M, UnitsInStock = 31 },
                new Product { ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", UnitPrice = 263.50M, UnitsInStock = 17 }
            };
        }

        // ========== Customer List من XML ==========
        static List<Customer> GetCustomerList()
        {
            try
            {
                var doc = XDocument.Load("customers.xml");
                return doc.Root.Elements("customer").Select(c => new Customer
                {
                    CustomerID = (string)c.Element("id"),
                    CustomerName = (string)c.Element("name"),
                    Address = (string)c.Element("address"),
                    City = (string)c.Element("city"),
                    Region = (string)c.Element("region"),
                    PostalCode = (string)c.Element("postalcode"),
                    Country = (string)c.Element("country"),
                    Phone = (string)c.Element("phone"),
                    Fax = (string)c.Element("fax"),
                    Orders = c.Element("orders").Elements("order").Select(o => new Order
                    {
                        OrderID = (int)o.Element("id"),
                        OrderDate = (DateTime)o.Element("orderdate"),
                        Total = (decimal)o.Element("total")
                    }).ToArray()
                }).ToList();
            }
            catch
            {
                Console.WriteLine("Warning: customers.xml not found, using sample data.");
                return new List<Customer>();
            }
        }
    }
}