using Microsoft.EntityFrameworkCore;
using StudentApplication1.Data;
using StudentApplication1.Models;

namespace StudentApplication1.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly StudentDbContext studentDbContext;

        public MarkRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public async Task<Mark> CreateAsync(Mark mark)
        {
            await studentDbContext.Mark.AddAsync(mark);
            await studentDbContext.SaveChangesAsync();
            return mark;
        }

        public async Task<Mark?> DeleteAsync(Guid id)
        {
            var existingMark = await studentDbContext.Mark.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMark == null)
            {
                return null;
            }
            studentDbContext.Mark.Remove(existingMark);
            await studentDbContext.SaveChangesAsync();
            return existingMark;
        }

        public async Task<List<Mark>> GetAllAsync()
        {
            return await studentDbContext.Mark.Include("Student").ToListAsync();
        }

        public async Task<Mark?> GetByIdAsync(Guid id)
        {
            var existingMark = await studentDbContext.Mark.Include("Student").FirstOrDefaultAsync(x => x.Id == id);
            if(existingMark == null)
            {
                return null;
            }
            return existingMark;
        }

        public async Task<Mark?> UpdateAsync(Guid id, Mark mark)
        {
            var existingMark = await studentDbContext.Mark.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMark == null)
            {
                return null;
            }
            existingMark.StudentId = mark.StudentId;
            existingMark.Mark1 = mark.Mark1;
            existingMark.Mark2 = mark.Mark2;
            existingMark.Mark3 = mark.Mark3;
            existingMark.Mark4 = mark.Mark4;
            existingMark.Mark5 = mark.Mark5;
            existingMark.Mark6 = mark.Mark6;
            await studentDbContext.SaveChangesAsync();
            return mark;

        }
    }
}
