using Services.Contracts;

namespace Presentation.Controllers
{
    public class ExcelController
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }
    }
}
