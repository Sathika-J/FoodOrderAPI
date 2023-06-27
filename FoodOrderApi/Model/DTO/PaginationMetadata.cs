namespace FoodOrderApi.Model.DTO
{
    public class PaginationMetadata
    {
        public int TotalItem { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalItem, int pageSize, int currentPage)
        {
            TotalItem = totalItem;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPage = (int)Math.Ceiling(totalItem / (double)pageSize);
        }
    }
}