namespace ConsoleApp4;

class Program
{
    static void DownloadStart()
    {
        new FileDownload();
    }
    
    static void Main()
    {
        DownloadStart();
    }
}

class FileDownload
{
    public FileDownload()
    {
        Console.WriteLine("Download started");
    }

    ~FileDownload()
    {
        Console.WriteLine("Download completed");
    }
}