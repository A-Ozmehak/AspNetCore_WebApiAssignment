using Infrastructure.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
    public int Id { get; set; }
    public string? CourseImage { get; set; }
    public string? CourseBgImage { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Author { get; set; }
    public bool isDigital { get; set; }
    public DateTime Created {  get; set; }
    public DateTime LastUpdated { get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public static implicit operator CourseEntity(CourseDto dto)
    {
        return new CourseEntity
        {
            CourseBgImage = dto.CourseBgImage,
            CourseImage = dto.CourseImage,
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
