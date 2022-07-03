namespace AiSDLecture;

// SOLID:
// S - single responsibility principle
// O - open-closed principle
// L - Liskov substitution principle
// I - interface segregation principle
// D - dependency inversion principle

internal enum Department
{
    HR,
    IT,
    Sales,
    Accounting
}

internal class Salary
{
    public string EmployeeName { get; set; }
    
    public double Amount { get; set; }
    
    public Department Department { get; set; }
}

/// <summary>
/// Get the salaries of the management, group them by department and print the summary to PDF
///   0 - HR
///   1 - IT
///   2 - Sales
/// </summary>
internal class SomeProcessInTheCompany
{
    private readonly ISalaryProvider _salaryProvider;
    private readonly IPrinter _printer;

    public SomeProcessInTheCompany(ISalaryProvider salaryProvider, IPrinter printer)
    {
        _salaryProvider = salaryProvider;
        _printer = printer;
    }
    
    public void Run()
    {
        var salaries = _salaryProvider.GetSalaries();

        var summary = CreateDictionary();
        
        foreach (var salary in salaries)
        {
            summary[salary.Department] += salary.Amount;
        }
        
        var pdfLines = new LinkedList<string>();

        foreach (var summaryEntry in summary)
        {
            pdfLines.AddLast($"Department: {summaryEntry.Key}; Amount: {summaryEntry.Value}");
        }

        var total = summary.Values.Sum();
        pdfLines.AddLast($"Total: {total}");
        
        _printer.Print(pdfLines);
        
        // Send notification to sales
        // ...
    }

    private static Dictionary<Department, double> CreateDictionary()
    {
        return Enum.GetValues<Department>()
            .ToDictionary(department => department, department => 0.0);
    }
}

internal interface ISalaryProvider
{
    List<Salary> GetSalaries();
}

internal class Database : ISalaryProvider
{
    public List<Salary> GetSalaries()
    {
        return new List<Salary>
        {
            new Salary
            {
                EmployeeName = "Alice",
                Amount = 5000,
                Department = Department.HR
            },
            new Salary
            {
                EmployeeName = "Bob",
                Amount = 7890.12,
                Department = Department.IT
            },
            new Salary
            {
                EmployeeName = "Chris",
                Amount = 12345.67,
                Department = Department.Accounting
            }
        };
    }
}

internal interface IPrinter
{
    void Print(IEnumerable<string> lines);
}

internal class PdfPrinter : IPrinter
{
    // We fake the PDF here; just print to the console...
    public void Print(IEnumerable<string> lines)
    {
        // Print the lines to the PDF
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
        
        // Notify the accounting
        Console.WriteLine("To accounting: the report is complete!");
    }
}