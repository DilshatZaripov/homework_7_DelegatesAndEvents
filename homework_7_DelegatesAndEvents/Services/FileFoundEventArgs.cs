using System.ComponentModel;

namespace homework_7_DelegatesAndEvents.Services;

public class FileFoundEventArgs(string fileName) : CancelEventArgs
{
    public string FilePath { get; } = fileName;
}
