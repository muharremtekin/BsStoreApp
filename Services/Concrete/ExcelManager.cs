using OfficeOpenXml;
using Services.Contracts;

namespace Services.Concrete
{
    public class ExcelManager : IExcelService
    {
        /// <summary>
        ///  Gelen herhangi bir List<T> tipindeki veriyi excel olarak döndürür.
        ///  Listeleme B2 hücresinden başlar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<byte[]> ExportExcelListAsync<T>(List<T> t, string startingCell) where T : class
        {
            using (var excelPackage = new ExcelPackage())
            {
                string name = typeof(T).Name;
                string pageName = $"{name}_Report_{DateTime.Now}";

                var properties = typeof(T).GetProperties();
                var worksheet = excelPackage.Workbook.Worksheets.Add(pageName);


                worksheet.Cells[startingCell]
                .LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.None);

                return await excelPackage.GetAsByteArrayAsync();
            }
        }
    }
}
