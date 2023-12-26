namespace ConsoleAppSubmission2.Interfaces;

//Interface för file service
public interface IFileService
{
    string GetContentFromFile();
    bool SaveContentToFile(string content);
}
