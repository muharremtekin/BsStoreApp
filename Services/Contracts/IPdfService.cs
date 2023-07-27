namespace Services.Contracts
{
    public interface IPdfService
    {
        Task<byte[]> ExportPdfListAsync<T>(List<T> t) where T : class;
    }
}
