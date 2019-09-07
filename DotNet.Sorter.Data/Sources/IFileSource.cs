
namespace DotNet.Sorter.Data.Sources
{
    public interface IFileSource
    {
        string[] Read(string path);
        bool Write(string path, string[] stringArr);
    }
}
