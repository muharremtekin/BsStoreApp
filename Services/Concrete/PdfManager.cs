using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Services.Contracts;

namespace Services.Concrete
{
    public class PdfManager : IPdfService
    {


        public async Task<byte[]> ExportPdfListAsync<T>(List<T> t) where T : class
        {
            if (t is null || t.Count == 0)
                throw new ArgumentNullException(nameof(t));

            using (var document = new Document(PageSize.A4, 25, 25, 30, 30))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    var pdfWriter = PdfWriter.GetInstance(document, stream);
                    pdfWriter.CloseStream = false;
                    document.Open();
                    var tName = typeof(T).Name;
                    Title title = new Title($"{tName} Report");
                    var table = new PdfPTable(1);
                    var tProperties = typeof(T).GetProperties();
                    tProperties.ToList().ForEach(p =>
                    {
                        var cell = new PdfPCell(new Phrase(p.Name));
                        cell.BackgroundColor = new BaseColor(0, 150, 0);
                        table.AddCell(cell);
                    });
                    document.Add(table);
                    document.Close();
                    return stream.ToArray();
                }
            }
        }
    }
}
