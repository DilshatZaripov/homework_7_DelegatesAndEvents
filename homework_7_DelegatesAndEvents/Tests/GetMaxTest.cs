using homework_7_DelegatesAndEvents.Extensions;
using homework_7_DelegatesAndEvents.Models;

namespace homework_7_DelegatesAndEvents.Tests;

public static class GetMaxTest
{
    public static void Run()
    {
        var students = GenerateStudents();

        Console.WriteLine("Students:\n  " + string.Join("\n  ", students));
        Console.WriteLine($"Student with most total grade: {students.GetMax<Student>(GradeConverter)}");
        Console.WriteLine($"Most old student: {students.GetMax<Student>(AgeConverter)}");
    }

    private static List<Student> GenerateStudents()
    {
        return
        [
            new("Mark", 21, 5),
            new("Mario", 20, 4),
            new("Andrew", 28, 4),
            new("Elena", 22, 7),
            new("Lu Chan", 20, 9),
            new("Harry", 19, 8),
            new("Ron", 18, 6)
        ];
    }

    private static float GradeConverter(Student student)
    {
        return student.TotalGrade;
    }

    private static float AgeConverter(Student student)
    {
        return student.Age;
    }
}
