namespace Sdu.Data.Repositories
{
    public interface IFileProvider
    {
        string[] LoadFileContents();
        void AppendLineToFile(string line);
    }
}