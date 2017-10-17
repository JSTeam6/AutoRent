using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream(@"..\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4, 36, 72, 108, 180);
            PdfWriter.GetInstance(document, fileStream);
            document.Open();
            document.Add(new Paragraph("AutoRent"));
            document.Close();
        }
    }
}