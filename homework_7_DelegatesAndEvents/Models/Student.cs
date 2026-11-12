namespace homework_7_DelegatesAndEvents.Models;

public record class Student(string Name, int Age, int TotalGrade)
{
    public override string ToString()
    {
        return $"{Name} ({Age} y.o.) Total grade: {TotalGrade}";
    }
}