using System.Net.Mail;

namespace AiSDLecture;

internal class Student
{
    private string _name;
    
    public int Index { get; }

    public string Name
    {
        get => _name;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Name cannot be null");
            }

            _name = value;
        }
    }
    
    public MailAddress EmailAddress { get; }

    public Student(int index, string name, MailAddress emailAddress)
    {
        if (index <= 0)
        {
            throw new ArgumentException("Index must be positive.");
        }

        Index = index;
        Name = name;
        EmailAddress = emailAddress;
    }
}

internal static class StudentReport
{
    public static void Run()
    {
        var students = GetStudents();
        
        // Preprocessing...

        var studentsWithNameAlice = students
            .Count(student => student.Name.Equals("Alice", StringComparison.InvariantCultureIgnoreCase));

        try
        {
            const int index = 123;
            UpdateStudentPhoneNumber(index, phoneNumber: "123456789");
        }
        catch (Exception e)
        {
            // Display error to user
        }
        
        Console.WriteLine($"Number of Alices: {studentsWithNameAlice}");
    }

    private static bool UpdateStudentPhoneNumber(int studentIndex, string phoneNumber)
    {
        // ...
        var rowsUpdated = DoSomethingOnDatabase();

        return rowsUpdated > 0;
    }

    private static List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student(1001, "Alice", "a@b.com"),
            new Student(1002, "Bob", "a@b.com"),
            new Student(1003, "ALICE", "a@b.com")
        };
    }
}