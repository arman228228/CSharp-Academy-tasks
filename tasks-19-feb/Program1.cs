namespace ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student("Bob", 1,  90 ),
            new Student("John", 2,  80 ),
            new Student("Alice", 3,  85 )
        };

        foreach (Student student in students)
        {
            Console.WriteLine("");
            student.ShowStudentInfo();
        }
    }
}

class Student
{
    private string _name;
    private int _studentID;
    private int _gradeLevel;

    public Student(string name, int studentID, int gradeLevel)
    {
        _name = name;
        _studentID = studentID;
        _gradeLevel = gradeLevel;
    }
    public void ShowStudentInfo()
    {
        Console.WriteLine($"Student details:\nName: {_name}\nStudent ID: {_studentID}\nGrade level: {_gradeLevel}");
    }
}