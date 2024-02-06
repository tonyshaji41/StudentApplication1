using AutoMapper;
using StudentApplication1.Models;

namespace StudentApplication1.Mapping
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentRequestDto>().ReverseMap();

            CreateMap<Mark, MarkDto>().ReverseMap();
            CreateMap<Mark, MarkRequestDto>().ReverseMap();

        }
    }
}
