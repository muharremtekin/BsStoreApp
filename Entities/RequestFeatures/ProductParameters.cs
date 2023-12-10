namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint MaxPrice { get; set; } = 99999;
        public uint MinPrice { get; set; } = 0;
        public bool ValidPriceRage => MaxPrice > MinPrice;
        public String? SerachTerm { get; set; }

        public ProductParameters()
        {
            OrderBy = "id";
        }
    }
}
