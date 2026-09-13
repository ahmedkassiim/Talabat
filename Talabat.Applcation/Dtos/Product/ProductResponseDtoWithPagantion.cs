namespace Talabat.Applcation.Dtos.Product
{
    public class ProductResponseDtoWithPagantion
    {
        public ProductResponseDtoWithPagantion(int pageSize, int pageIndex, int count, IReadOnlyList<ProductResponseDto> products)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Products = products;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<ProductResponseDto>? Products { get; set; }

    }
}
