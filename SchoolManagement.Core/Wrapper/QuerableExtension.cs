using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Core.Wrapper
{
    public static class QuerableExtension
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (source == null)
            {
                return new PaginatedList<T>([], 0, pageIndex, pageSize);
            }
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
