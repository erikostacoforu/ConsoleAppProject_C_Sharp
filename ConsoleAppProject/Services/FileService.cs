using System.Diagnostics;

namespace ConsoleAppProject.Services;

public interface IFileService
{
    string _filepath { get; set; }
    bool SaveContentToFile(string content); // Metod för att spara ned information

    string GetContentFromFile();    // Metod för att hämta information 
}


    public class FileService(string filepath) : IFileService
{
    private readonly string _filepath = filepath;

    string IFileService._filepath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Metod för att spara information till en fil
    public bool SaveContentToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filepath))
            {
                sw.WriteLine(content);
            }

            return true;    // Returnerar true om det lyckades att spara
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }   // skriver ut errors i Debug
        return false;   // returnerar falsk om det  inte gick att spara
    }
    public string GetContentFromFile()  // Metod för att läsa informationen från filen
    {
        try
        {
            if (File.Exists(_filepath))
            {   
                // Läser informationen från filen
                using (var sr = new StreamReader(_filepath))
                {
                    return sr.ReadToEnd();  // Returnerar informationen från filen till en string
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;   // Returnerar null om filen inte finns eller något annat blev knasigt
    } 
}

