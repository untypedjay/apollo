using Apollo.Core.Interface.Services;
using Aspose.Pdf;

namespace Apollo.Core.Services
{
    public class PrintService : IPrintService
    {
        public void PrintDocument(string[] paragraphs, string fileName)
        {
            Document document = new Document();
            Page page = document.Pages.Add();

            for (int i = 0; i < paragraphs.Length; i++)
            {
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(paragraphs[i]));
            }

            document.Save(fileName + ".pdf");
        }
    }
}
