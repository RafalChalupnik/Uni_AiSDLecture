namespace AiSDLecture;

internal class Student
{
    public int Index { get; set; }
    
    public string Name { get; set; }
    
    public string EmailAddress { get; set; }
}

internal static class StudentReport
{
    public static void Run()
    {
        var students = GetStudents();

        var studentsWithNameAlice = students
            .Count(student => student.Name.Equals("Alice", StringComparison.InvariantCultureIgnoreCase));
        
        Console.WriteLine($"Number of Alices: {studentsWithNameAlice}");
    }

    private static List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student
            {
                Index = 1001,
                Name = "Alice",
                EmailAddress = "alice@wonderland.com"
            },
            new Student
            {
                Index = 1002,
                Name = "Bob",
                EmailAddress = "bob@gmail.com"
            },
            new Student
            {
                Index = 1003,
                Name = "ALICE",
                EmailAddress = "charles@example.eu"
            }
        };
    }
}