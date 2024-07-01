namespace Bases.Models
{
    public class PagedResponseModel<T>
    {
        public IList<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
    }
}
