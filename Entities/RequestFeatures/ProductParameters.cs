namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint MaxPrice { get; set; } = 1000;
        public uint MinPrice { get; set; }
        public bool ValidPrice => MaxPrice > MinPrice;
    }
}
