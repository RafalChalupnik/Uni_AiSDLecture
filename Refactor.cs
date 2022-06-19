namespace AiSDLecture;

// SOLID:
// S - single responsibility principle
// O - open-closed principle
// L - Liskov substitution principle
// I - interface segregation principle
// D - dependency inversion principle

internal class Salary
{
    public string EmployeeName { get; set; }
    
    public double Amount { get; set; }
    
    public int Department { get; set; }
}

/// <summary>
/// Get the salaries of the management, group them by department and print the summary to PDF
///   0 - HR
///   1 - IT
///   2 - Sales
/// </summary>
internal static class SomeProcessInTheCompany
{
    private static double hrAmount = 0.0;
    private static double itAmount = 0.0;
    private static double salesAmount = 0.0;
    
    public static void Run()
    {
        // Get the salaries
        var salaries = Database.GetSalaries();
        
        // Group salaries for each department
        for (var i = 0; i < salaries.Count; i++)
        {
            if (salaries[i].Department == 0)
            {
                hrAmount += salaries[i].Amount;
            }
            else if (salaries[i].Department == 1)
            {
                itAmount += salaries[i].Amount;
            }
            else if (salaries[i].Department == 2)
            {
                salesAmount += salaries[i].Amount;
            }
        }
        
        // Create PDF file content
        var pdfLines = new string[4];
        
        // Populate PDF lines
        pdfLines[0] = ($"Department: HR; Amount: {hrAmount}");
        pdfLines[1] = ($"Department: IT; Amount: {itAmount}");
        pdfLines[2] = ($"Department: Sales; Amount: {salesAmount}");
        pdfLines[3] = ($"Total: {hrAmount + itAmount + salesAmount}");

        // Write PDF to file
        PdfPrinter.Print(pdfLines);
    }
}

internal static class Database
{
    public static List<Salary> GetSalaries()
    {
        return new List<Salary>
        {
            new Salary
            {
                EmployeeName = "Alice",
                Amount = 5000,
                Department = 0
            },
            new Salary
            {
                EmployeeName = "Bob",
                Amount = 7890.12,
                Department = 1
            },
            new Salary
            {
                EmployeeName = "Chris",
                Amount = 12345.67,
                Department = 0
            }
        };
    }
}

internal static class PdfPrinter
{
    // We fake the PDF here; just print to the console...
    public static void Print(string[] lines)
    {
        // Print the lines to the PDF
        for (var i = 0; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }
        
        // Notify the accounting
        Console.WriteLine("To accounting: the report is complete!");
    }
}