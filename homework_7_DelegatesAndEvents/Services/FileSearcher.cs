using homework_7_DelegatesAndEvents.Models;

namespace homework_7_DelegatesAndEvents.Services;

public class FileSearcher
{
    public event EventHandler<FileFoundEventArgs>? FileFound;

    /// <summary>
    /// File searcher that raises <see cref="FileFound"/> for every found file in <paramref name="directory"/>
    /// </summary>
    /// <param name="directory"><see cref="string"/> directory</param>
    /// <param name="recurseSearch"><see cref="bool"/> use recursive search, default <see langword="false"/></param>
    /// <returns>Returns <see cref="SearchCompleted"/> reason</returns>
    public SearchCompleted SearchFiles(string directory, bool recurseSearch = false)
    {
        if (FileFound is null) return SearchCompleted.NoSubscribers;
        if (!Directory.Exists(directory)) return SearchCompleted.DirectoryNotExists;

        var files = Directory.EnumerateFiles(
            directory,
            "*",
            new EnumerationOptions
            {
                RecurseSubdirectories = recurseSearch,
                IgnoreInaccessible = true
            });

        foreach (var file in files)
        {
            var fileFoundEventArgs = new FileFoundEventArgs(file);
            FileFound?.Invoke(this, fileFoundEventArgs);

            if (fileFoundEventArgs.Cancel) return SearchCompleted.SubscriberStops;
        }

        return SearchCompleted.SearchEnds;
    }
}
