namespace WebAPI.Filters
{
    public class PaginationFilter
    {
        private const int MaxPageSize = 10;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }
    }
}
