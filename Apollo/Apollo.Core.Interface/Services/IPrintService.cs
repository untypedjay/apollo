namespace Apollo.Core.Interface.Services
{
    public interface IPrintService
    {
        void PrintDocument(string[] paragraphs, string fileName);
    }
}
