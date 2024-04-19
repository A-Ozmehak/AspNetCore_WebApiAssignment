using Infrastructure.Dtos;

namespace Infrastructure.Models;

public class CourseResult
{
    public bool Succeeded { get; set; }
    public IEnumerable<CourseDto>? Courses { get; set; }
}
