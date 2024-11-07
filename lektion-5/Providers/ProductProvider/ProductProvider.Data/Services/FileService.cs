using ProductProvider.Data.Interfaces;

namespace ProductProvider.Data.Services;

public class FileService : IFileService
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }

            return null!;
        }
        catch
        {
            return null!;
        }
    }

    public bool SaveToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
