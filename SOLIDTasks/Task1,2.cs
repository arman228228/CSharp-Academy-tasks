namespace SOLIDPractise;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

// Single responsibility principle, open/closed principle, dependency inversion principle violations fix

public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
}

interface IReportSaver
{
    void Save(Report report, string path);
}
interface IReportPrinter
{
    void Print(Report report);
}

public class ReportSaver : IReportSaver
{
    public void Save(Report report, string path)
    {
        System.IO.File.WriteAllText(path, report.Content);
    }
}

public class ReportPrinter : IReportPrinter
{
    public void Print(Report report)
    {
        Console.WriteLine($"--- {report.Title} ---\n{report.Content}");
    }
} 