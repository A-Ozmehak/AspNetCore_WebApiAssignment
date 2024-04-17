using Infrastructure.Dtos;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

public static class CourseFactory
{

    public static CourseEntity Create(CourseDto dto)
    {
        try
        {  
            return new CourseEntity()
            {
               CourseImage = dto.Image,
               CourseBgImage = dto.BgImage,
               Title = dto.Title,
               Price = dto.Price,
               DiscountPrice = dto.DiscountPrice,
               Hours = dto.Hours,
               IsBestSeller = dto.IsBestSeller,
               LikesInNumbers = dto.LikesInNumbers,
               LikesInProcent = dto.LikesInProcent,
               Author = dto.Author,

            };
        }
        catch { }
        return null!;
    }

    public static CourseDto Create(CourseEntity entity)
    {
        try
        {
            return new CourseDto
            {
                Image = entity.CourseImage,
                BgImage = entity.CourseBgImage,
                Title = entity.Title,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                IsBestSeller = entity.IsBestSeller,
                LikesInNumbers = entity.LikesInNumbers,
                LikesInProcent = entity.LikesInProcent,
                Author = entity.Author,
            };
        }
        catch { }
        return null!;
      
    }
}
