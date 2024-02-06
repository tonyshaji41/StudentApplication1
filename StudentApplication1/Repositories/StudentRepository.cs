using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApplication1.Data;
using StudentApplication1.Models;

namespace StudentApplication1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await studentDbContext.Students.AddAsync(student);
            await studentDbContext.SaveChangesAsync();

            return student;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
            var existingStudent = await studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            studentDbContext.Students.Remove(existingStudent);
            return existingStudent;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await studentDbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var existingStudent = await studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.FullName = student.FullName;
            existingStudent.Class = student.Class;
            existingStudent.Division = student.Division;
            existingStudent.ParentName = student.ParentName;
            existingStudent.Address = student.Address;

            await studentDbContext.SaveChangesAsync();
            return existingStudent;
        }
    }
}
