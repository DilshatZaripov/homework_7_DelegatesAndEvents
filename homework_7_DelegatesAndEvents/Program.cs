using homework_7_DelegatesAndEvents.Tests;

var separatorWidth = 30;

Console.WriteLine(new string('-', separatorWidth));
Console.WriteLine("GetMax Test");
Console.WriteLine(new string('-', separatorWidth));
GetMaxTest.Run();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine(new string('-', separatorWidth));
Console.WriteLine("FileSearch Sequence Test");
Console.WriteLine(new string('-', separatorWidth));
FileSearchTest.GenerateFiles();
FileSearchTest.RunSequenceListener();
Console.WriteLine();

Console.WriteLine(new string('-', separatorWidth));
Console.WriteLine("FileSearch Required File Test");
Console.WriteLine(new string('-', separatorWidth));
FileSearchTest.RunRequiredFileSearcher();