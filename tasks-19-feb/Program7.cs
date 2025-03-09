namespace ConsoleApp4;

class Program
{
    static void Main()
    {
        WorkoutSession[] workoutSession =
        {
            new WorkoutSession("running", 10),
            new WorkoutSession("walking", 5),
            new WorkoutSession("push up", 12),
            new WorkoutSession("press", 8)
        };

        foreach (var workout in workoutSession)
        {
            workout.ShowWorkoutDetails();
        }
    }
}

class WorkoutSession
{
    private string _exerciseType;
    private int _durationInMinutes;

    public WorkoutSession(string exerciseType, int durationInMinutes)
    {
        _exerciseType = exerciseType;
        _durationInMinutes = durationInMinutes;
    }
    
    public void ShowWorkoutDetails()
    {
        Console.WriteLine(
            $"Workout session details - type: {_exerciseType}, duration in minutes: {_durationInMinutes}");
    }
}