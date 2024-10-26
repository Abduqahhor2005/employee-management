using EMS.Filter;

namespace EMS.Response;

public record PaginationResponse<T> : BaseFilter
{
    public int TotalPages { get; init; }
    public int TotalRecords { get; init; }
    public T? Data { get; set; }

    private PaginationResponse(int pageSize, int pageNumber, int totalRecords, T? data) : base(pageSize, pageNumber)
    {
        Data = data;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
    }

    public static PaginationResponse<T> Create(int pageSize, int pageNumber, int totalRecords, T? data)
        => new PaginationResponse<T>(pageSize, pageNumber, totalRecords, data);
}