using Client.Core.Contracts;
using Client.Ninject;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Ninject;
using System.IO;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new AutoRentModule());

            IEngine engine = kernel.Get<IEngine>("Engine");
            engine.Start();


            FileStream fileStream = new FileStream(@"..\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4, 36, 72, 108, 180);
            PdfWriter.GetInstance(document, fileStream);
            document.Open();
            document.Add(new Paragraph("AutoRent"));
            document.Close();
        }
    }
}