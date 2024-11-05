using Auth.DTO;

namespace Auth.Interfaces;

public interface IPaginationUtil
{
    PaginationDTO<T> GetPagination<T>(IEnumerable<T> data, int page, int recordsPerPage);
}