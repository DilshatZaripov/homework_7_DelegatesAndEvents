using homework_7_DelegatesAndEvents.Services;
using System.Reflection;

namespace homework_7_DelegatesAndEvents.Tests;

public static class FileSearchTest
{
    private static int _iterations;
    private readonly static string _testDirectory = Path.Combine(AppContext.BaseDirectory, "Test");

    public static void GenerateFiles(int count = 10)
    {
        if (!Directory.Exists(_testDirectory))
            Directory.CreateDirectory(_testDirectory);

        for (int i = 0; i < count; i++)
        {
            var fileName = Path.Combine(_testDirectory, $"test_file_{i}.txt");
            File.WriteAllText(fileName, $"file for testing #{i}");
        }
    }

    public static void RunSequenceListener()
    {
        Console.WriteLine($"Directory:\n{_testDirectory}");

        _iterations = 0;

        var searcher = new FileSearcher();
        searcher.FileFound += SequenseListener;

        var searchCompleted = searcher.SearchFiles(_testDirectory);

        searcher.FileFound -= SequenseListener;

        switch (searchCompleted)
        {
            case Models.SearchCompleted.DirectoryNotExists:
                Console.WriteLine($"Couldn't find directory {_testDirectory}");
                break;
            case Models.SearchCompleted.SearchEnds:
                Console.WriteLine($"Total found files: {_iterations}");
                break;
        }
    }

    public static void RunRequiredFileSearcher()
    {
        Console.WriteLine($"Directory:\n{_testDirectory}");

        var files = Directory.GetFiles(_testDirectory);
        var requiredFileName = Path.GetFileName(files[Random.Shared.Next(files.Count())]);
        Console.WriteLine($"File for search:\n{requiredFileName}");

        _iterations = 0;

        var searcher = new FileSearcher();

        EventHandler<FileFoundEventArgs> handler = (s, e) => RequiredFileListener(s, e, requiredFileName);
        searcher.FileFound += handler;

        var searchCompleted = searcher.SearchFiles(_testDirectory);

        searcher.FileFound -= handler;

        switch (searchCompleted)
        {
            case Models.SearchCompleted.SearchEnds:
                Console.WriteLine($"File Not Found. Total _iterations: {_iterations}");
                break;
            case Models.SearchCompleted.SubscriberStops:
                Console.WriteLine($"File found. Task completed manualy. Iterations required: {_iterations}");
                break;
        }
    }

    private static void SequenseListener(object? sender, FileFoundEventArgs e)
    {
        _iterations++;
        Console.WriteLine($"  {_iterations}. Found file: {Path.GetFileName(e.FilePath)}");
    }

    private static void RequiredFileListener(object? sender, FileFoundEventArgs e, string requiredFileName)
    {
        _iterations++;
        if (e.FilePath.Contains(requiredFileName))
        {
            e.Cancel = true;
        }
    }
}
