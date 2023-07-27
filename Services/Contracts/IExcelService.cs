namespace Services.Contracts
{
    public interface IExcelService
    {
        Task<byte[]> ExportExcelListAsync<T>(List<T> t, string? startingCell) where T : class;

    }
}
