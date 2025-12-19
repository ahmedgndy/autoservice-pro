namespace AutoService.Application.Common.Model;

public class PaginatedList<T>
{

    public int PageIndex { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public IReadOnlyCollection<T>? Items { get; set; }



}