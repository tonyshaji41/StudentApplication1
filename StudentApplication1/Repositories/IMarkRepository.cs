using StudentApplication1.Models;

namespace StudentApplication1.Repositories
{
    public interface IMarkRepository
    {

        Task<List<Mark>> GetAllAsync();

        Task<Mark?> GetByIdAsync(Guid id);

        Task<Mark> CreateAsync(Mark mark);

        Task<Mark?> UpdateAsync(Guid id, Mark mark);

        Task<Mark?> DeleteAsync(Guid id);
    }
}
