using ConsoleAppProject.Tests.Interfaces;
using System.Diagnostics;

namespace ConsoleAppProject.Services
{
    public class FileService : IFileService
    {
        public string _filepath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetContentFromFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    using var sr = new StreamReader(filepath);
                    return sr.ReadToEnd();
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public string GetContentFromFile()
        {
            throw new NotImplementedException();
        }

        public bool SaveContentToFile(string filepath, string content)
        {

            try
            {
                using var sw = new StreamWriter(filepath);
                sw.WriteLine(content);
                return true;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        public bool SaveContentToFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}
