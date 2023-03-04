using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
                // Create worker object

                Console.Write("Enter the departament's name: ");
                string departmentName = Console.ReadLine();

                Console.WriteLine("Enter worker data: ");
                Console.Write("Name: ");
                string workerName = Console.ReadLine();

                Console.Write("Level (Junior/MidLevel/Senior): ");
                WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

                Console.Write("Base Salary: ");
                double workerSalary = double.Parse(Console.ReadLine());

                Console.Write("How many contracts to this worker? ");
                int amountOfContracts = int.Parse(Console.ReadLine());

                Department Department = new Department(departmentName);
                Worker worker = new Worker(workerName, workerLevel, workerSalary, Department);

                // Loop through the number of contracts

                for (int i = 1; i <= amountOfContracts; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Enter #{i} contract data: ");

                    Console.Write("Date (MM/DD/YYYY): ");
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());

                    Console.Write("Value per hour: ");
                    double valuePerHour = double.Parse(Console.ReadLine());

                    Console.Write("Duration (hours): ");
                    int duration = int.Parse(Console.ReadLine());

                    // Add contract to the worker

                    HourContract HourContract = new HourContract(dateTime, valuePerHour, duration);
                    worker.AddContract(HourContract);
                }

                Console.WriteLine();

                // Print worker information with income

                Console.Write("Enter month and year to calculate icome (MM/YYYY): ");
                string monthAndYear = Console.ReadLine();
                int month = int.Parse(monthAndYear.Substring(0,2));
                int year = int.Parse(monthAndYear.Substring(3));

                Console.WriteLine("Name: " + worker.Name);
                Console.WriteLine("Department: " + worker.Department.Name);
                Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2")}");
        }
    }
}
