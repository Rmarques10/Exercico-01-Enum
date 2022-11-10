using Exercico_Enum_01.Entities;
using Exercico_Enum_01.Entities.Enums;
using System.Globalization;

Console.Write("Enter department's name: ");
string depName = Console.ReadLine();
Console.WriteLine("Enter worker data:");
Console.Write("Name: ");
string name = Console.ReadLine();
Console.Write("Junior/MidLevel/Senior: ");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
Console.Write("Base salary: ");
double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Department dept = new Department(depName);
Worker worker = new Worker(name, level, salary,dept);

Console.Write("How many contracts to this worker? ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.Write("Value per hour: ");
    double valuePerhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());
    HourContract contract = new HourContract(date, valuePerhour, hours);
    worker.AddContract(contract);
}

Console.WriteLine();
Console.Write("Enter mont and year to calculate income (mm/yyyy): ");
string monthAndYear = Console.ReadLine();
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));

Console.WriteLine("Name: " + worker.Name);
Console.WriteLine("Department: " + worker.Department.Name);
Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));