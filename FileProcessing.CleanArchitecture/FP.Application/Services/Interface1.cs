namespace FP.Application.Services
{
    public interface IFileService
    {
        void SaveFile(string fileName, string content);
        string ReadFile(string fileName);
    }
}
