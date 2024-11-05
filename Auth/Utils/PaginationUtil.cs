using Auth.DTO;
using Auth.Interfaces;

namespace Auth.Utils;

public class PaginationUtil : IPaginationUtil
{
    private static List<T> Paginate<T>(List<T> data, int page, int recordsPerPage)
    {
        return data.Skip((page - 1) * recordsPerPage).Take(recordsPerPage).ToList();
    }

    public PaginationDTO<T> GetPagination<T>(IEnumerable<T> data, int page, int recordsPerPage)
    {
        return new PaginationDTO<T>
        {
            Data = Paginate(data.ToList(), page, recordsPerPage),
            Page = page,
            RecordsPerPage = recordsPerPage,
            TotalRecords = data.ToList().Count,
        };
    }
}