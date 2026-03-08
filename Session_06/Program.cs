using System;

namespace Session_06
{
    // ========== Enums ==========
    enum Gender { M, F }
    enum SecurityLevel { Guest, Developer, Secretary, DBA }

    // ========== HiringDate Struct ==========
    struct HiringDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }

    // ========== Employee Class ==========
    class Employee
    {
        // Properties (instead of getters/setters)
        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityLevel Security { get; set; }
        public double Salary { get; set; }
        public HiringDate HireDate { get; set; }
        private Gender _gender;

        public Gender Gender
        {
            get { return _gender; }
            set
            {
                if (value == Gender.M || value == Gender.F)
                    _gender = value;
                else
                    throw new ArgumentException("Gender must be M or F");
            }
        }

        // Constructors
        public Employee()
        {
            ID = 0;
            Name = "Unknown";
            Security = SecurityLevel.Guest;
            Salary = 0.0;
            HireDate = new HiringDate(1, 1, 2000);
            Gender = Gender.M;
        }

        public Employee(int id, string name, SecurityLevel sec, double salary, HiringDate hireDate, Gender gender)
        {
            ID = id;
            Name = name;
            Security = sec;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender; // will use the property setter
        }

        // Override ToString()
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Gender: {Gender}, Security: {Security}, " +
                   $"Salary: {Salary:C}, Hire Date: {HireDate}";
        }
    }

    // ========== Main Program ==========
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Management System ===\n");

            // Create an array of 3 employees
            Employee[] EmpArr = new Employee[3];

            // 1. DBA
            EmpArr[0] = new Employee(
                id: 101,
                name: "Ahmed DBA",
                sec: SecurityLevel.DBA,
                salary: 8000.50,
                hireDate: new HiringDate(15, 6, 2020),
                gender: Gender.M
            );

            // 2. Guest
            EmpArr[1] = new Employee(
                id: 102,
                name: "Mona Guest",
                sec: SecurityLevel.Guest,
                salary: 3000.0,
                hireDate: new HiringDate(10, 3, 2024),
                gender: Gender.F
            );

            // 3. Security Officer (with all permissions)
            // In this design, SecurityLevel is not Flags, so we'll pick one that represents "full"
            // For demonstration, we'll give Developer (can be changed as per logic)
            EmpArr[2] = new Employee(
                id: 103,
                name: "Omar Security",
                sec: SecurityLevel.Developer, // or you can extend enum to Flags if needed
                salary: 9500.75,
                hireDate: new HiringDate(1, 1, 2019),
                gender: Gender.M
            );

            // Display all employees
            Console.WriteLine("Employee Details:\n");
            foreach (Employee emp in EmpArr)
            {
                Console.WriteLine(emp);
            }

            // Extra: Try to set invalid gender (will throw exception)
            // Uncomment to test error handling
            // EmpArr[0].Gender = (Gender)10; // Will throw exception
        }
    }
}