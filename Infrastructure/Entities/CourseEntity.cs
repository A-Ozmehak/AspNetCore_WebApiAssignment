using Infrastructure.Dtos;

namespace Infrastructure.Entities;

public class CourseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Author { get; set; }

    public static implicit operator CourseEntity(CourseDto dto)
    {
        return new CourseEntity
        {
            Title = dto.Title,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            Hours = dto.Hours,
            IsBestSeller = dto.IsBestSeller,
            LikesInNumbers = dto.LikesInNumbers,
            Author = dto.Author,
            LikesInProcent = dto.LikesInProcent,
        };
    }
}
