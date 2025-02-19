namespace ConsoleApp4;

class ProgramPartialFirst
{
    static void Main()
    {
        Course[] courses =
        {
            new Course("Science", "John", 30),
            new Course("Math", "Bob", 40),
            new Course("History", "Anna", 15),
        };

        foreach (var course in courses)
        {
            course.ShowCourseDetails();
        }
    }
}

class Course
{
    private string? courseName;
    private string? instructor;
    private int maxStudents;

    public Course(string courseName, string instructor, int maxStudents)
    {
        this.courseName = courseName;
        this.instructor = instructor;
        this.maxStudents = maxStudents;
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"Course name: {courseName}, instructor: {instructor}, max students: {maxStudents}");
    }
}