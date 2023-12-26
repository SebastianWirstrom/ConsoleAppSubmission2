using ConsoleAppSubmission2.Interfaces;
using System.Diagnostics;

namespace ConsoleAppSubmission2.Services
{
    //File service - funktionaliteten i att spara och hämta en jsonfil med tidigare sparade kontakter
    public class FileService(string filePath) : IFileService
    {
        private readonly string _filePath = filePath;

        //Spara
        public bool SaveContentToFile(string content)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(content);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        //Hämta
        public string GetContentFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }  
            }
            catch (Exception ex){ Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
