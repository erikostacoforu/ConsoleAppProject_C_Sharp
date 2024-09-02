namespace ConsoleAppProject.Tests.Interfaces;

public interface IFileService
{
    bool SaveContentToFile(string filePath, string content);

    string GetContentFromFile(string filePath);
}
