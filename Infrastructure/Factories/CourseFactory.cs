using Infrastructure.Dtos;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseDto Create(CourseEntity entity)
    {
        try
        {
            return new CourseDto
            {
                Id = entity.Id,
                CourseImage = entity.CourseImage,
                CourseBgImage = entity.CourseBgImage,
                Title = entity.Title,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                IsBestSeller = entity.IsBestSeller,
                LikesInNumbers = entity.LikesInNumbers,
                LikesInProcent = entity.LikesInProcent,
                Author = entity.Author,
                isDigital = entity.isDigital,
                Category = entity.Category!.CategoryName
            };
        }
        catch { }
        return null!;

    }

    public static IEnumerable<CourseDto> Create(List<CourseEntity> entities)
    {
        List<CourseDto> courses = [];

        try
        {
            foreach (var entity in entities)
            {
                courses.Add(Create(entity));
            }
        }
        catch { }
        return courses;
    }

    //public static CourseEntity Create(CourseDto dto)
    //{
    //    try
    //    {  
    //        return new CourseEntity()
    //        {
    //           CourseImage = dto.CourseImage,
    //           CourseBgImage = dto.CourseBgImage,
    //           Title = dto.Title,
    //           Price = dto.Price,
    //           DiscountPrice = dto.DiscountPrice,
    //           Hours = dto.Hours,
    //           IsBestSeller = dto.IsBestSeller,
    //           LikesInNumbers = dto.LikesInNumbers,
    //           LikesInProcent = dto.LikesInProcent,
    //           Author = dto.Author,

    //        };
    //    }
    //    catch { }
    //    return null!;
    //}


}
