namespace ConsoleAppSubmission2.Interfaces;

public interface IFileService
{
    string GetContentFromFile();
    bool SaveContentToFile(string content);
}
