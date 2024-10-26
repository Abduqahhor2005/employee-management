namespace EMS.Filter;

public record BaseFilter
{
    public int PageSize { get; init; }
    public int PageNumber { get; init; }

    public BaseFilter()
    {
        PageSize = 10;
        PageNumber = 1;
    }

    public BaseFilter(int pageSize, int pageNumber)
    {
        PageSize = pageSize <= 0 ? 10 : pageSize;
        PageNumber = pageNumber <= 0 ? 1 : pageNumber;
    }
}