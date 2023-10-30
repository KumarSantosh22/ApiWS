namespace Pagination.Models.Filters
{
    public class TicketFilter: PageRequest
    {
        public string? Status { get; set; }
        public string? Category { get; set; }

        public string? SortParam { get; set; }
        public string? SortOrder { get; set; } = "asc";
    }
}
