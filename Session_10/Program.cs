using System;
using System.Collections;
using System.Collections.Generic;

namespace Session_10
{
    // ========== Q1: Optimized Bubble Sort ==========
    class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no swaps, array is already sorted
                if (!swapped)
                    break;
            }
        }
    }

    // ========== Q2: Generic Range<T> Class ==========
    class Range<T> where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("Min cannot be greater than Max");
            Min = min;
            Max = max;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        public double Length()
        {
            dynamic min = Min;
            dynamic max = Max;
            return (double)(max - min);
        }
    }

    // ========== Q3: Reverse ArrayList In-Place ==========
    class ArrayListReverser
    {
        public static void Reverse(ArrayList list)
        {
            int left = 0, right = list.Count - 1;
            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                left++;
                right--;
            }
        }
    }

    // ========== Q4: Get Even Numbers ==========
    class EvenNumbers
    {
        public static List<int> GetEven(List<int> numbers)
        {
            List<int> evens = new List<int>();
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                    evens.Add(num);
            }
            return evens;
        }
    }

    // ========== Q5: FixedSizeList<T> ==========
    class FixedSizeList<T>
    {
        private T[] items;
        private int count;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive");
            items = new T[capacity];
            count = 0;
        }

        public void Add(T item)
        {
            if (count >= items.Length)
                throw new InvalidOperationException("List is full. Cannot add more elements.");
            items[count++] = item;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range.");
            return items[index];
        }

        public int Count => count;
        public int Capacity => items.Length;
    }

    // ========== Q6: First Non-Repeated Character ==========
    class FirstNonRepeated
    {
        public static int FindIndex(string str)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            // Count frequency of each character
            foreach (char c in str)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            // Find first character with frequency 1
            for (int i = 0; i < str.Length; i++)
            {
                if (freq[str[i]] == 1)
                    return i;
            }

            return -1;
        }
    }

    // ========== Main Program ==========
    class Program
    {
        static void Main(string[] args)
        {
            // Q1: Optimized Bubble Sort
            Console.WriteLine("=== Q1: Optimized Bubble Sort ===");
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Original array: " + string.Join(", ", arr));
            BubbleSort.Sort(arr);
            Console.WriteLine("Sorted array: " + string.Join(", ", arr));
            Console.WriteLine();

            // Q2: Generic Range<T>
            Console.WriteLine("=== Q2: Generic Range<T> ===");
            Range<int> rangeInt = new Range<int>(10, 20);
            Console.WriteLine($"Range [10,20] contains 15: {rangeInt.IsInRange(15)}");
            Console.WriteLine($"Range [10,20] contains 25: {rangeInt.IsInRange(25)}");
            Console.WriteLine($"Length of range: {rangeInt.Length()}");

            Range<double> rangeDouble = new Range<double>(1.5, 5.5);
            Console.WriteLine($"Range [1.5,5.5] contains 3.0: {rangeDouble.IsInRange(3.0)}");
            Console.WriteLine($"Length of range: {rangeDouble.Length()}");
            Console.WriteLine();

            // Q3: Reverse ArrayList In-Place
            Console.WriteLine("=== Q3: Reverse ArrayList ===");
            ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original: " + string.Join(", ", list.ToArray()));
            ArrayListReverser.Reverse(list);
            Console.WriteLine("Reversed: " + string.Join(", ", list.ToArray()));
            Console.WriteLine();

            // Q4: Get Even Numbers
            Console.WriteLine("=== Q4: Even Numbers ===");
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original: " + string.Join(", ", numbers));
            List<int> evens = EvenNumbers.GetEven(numbers);
            Console.WriteLine("Evens: " + string.Join(", ", evens));
            Console.WriteLine();

            // Q5: FixedSizeList<T>
            Console.WriteLine("=== Q5: FixedSizeList<T> ===");
            FixedSizeList<string> fixedList = new FixedSizeList<string>(3);
            try
            {
                fixedList.Add("Ahmed");
                fixedList.Add("Ali");
                fixedList.Add("Mona");
                Console.WriteLine($"Added 3 items. Count: {fixedList.Count}");
                // This will throw exception
                // fixedList.Add("Omar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                Console.WriteLine($"Element at index 1: {fixedList.Get(1)}");
                Console.WriteLine($"Element at index 5: {fixedList.Get(5)}"); // Exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();

            // Q6: First Non-Repeated Character
            Console.WriteLine("=== Q6: First Non-Repeated Character ===");
            string test1 = "swiss";
            string test2 = "racecar";
            string test3 = "aabbcc";

            Console.WriteLine($"'{test1}' -> Index: {FirstNonRepeated.FindIndex(test1)}");
            Console.WriteLine($"'{test2}' -> Index: {FirstNonRepeated.FindIndex(test2)}");
            Console.WriteLine($"'{test3}' -> Index: {FirstNonRepeated.FindIndex(test3)}");
        }
    }
}