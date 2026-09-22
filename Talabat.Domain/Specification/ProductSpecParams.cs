namespace Talabat.Domain.Specification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 9;


        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value < MaxPageSize ? MaxPageSize : value; }
        }
        public int PageIndex { get; set; }

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToUpper(); }
        }

        public string? Sorting { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

    }
}
