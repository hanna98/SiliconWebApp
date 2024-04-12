using Infrastructure.Models.Courses;

namespace Silicon.Models;

public class CoursesViewModel
{
    public IEnumerable<Category>? Categories { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
    public Pagination? Pagination { get; set; }
}
