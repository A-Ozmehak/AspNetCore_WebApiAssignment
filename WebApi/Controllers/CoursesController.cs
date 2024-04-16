using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    #region GET

    [HttpGet]
    [UseApiKey]
    public async Task<IActionResult> GetAll()
    {
        if (ModelState.IsValid)
        {
            var courses = await _context.Courses.OrderByDescending(c => c.Id).ToListAsync();
            return Ok(courses);
        }
        return BadRequest();
        
    }

    [HttpGet("{id}")]
    [UseApiKey]
    public async Task<IActionResult> GetOne(int id)
    {
        if (ModelState.IsValid)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                return Ok(course);
            }
        }
       
        return NotFound();
    }

    #endregion

    #region CREATE

    [HttpPost]
    [UseApiKey]
    public async Task<IActionResult> Create(CourseDto dto)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Courses.AnyAsync(x => x.Title == dto.Title))
            {
                var courseEntity = CourseFactory.Create(dto);
                _context.Courses.Add(courseEntity);
                await _context.SaveChangesAsync();

                return Created("", CourseFactory.Create(courseEntity));
            }
        }

        return BadRequest();
    }

    #endregion

    #region UPDATE

    [HttpPut("{id}")]
    [UseApiKey]
    public async Task<IActionResult> Update(int id, CourseDto dto)
    {
        if (ModelState.IsValid)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                course.CourseImage = dto.Image;
                course.CourseBgImage = dto.BgImage;
                course.Title = dto.Title;
                course.Price = dto.Price;
                course.DiscountPrice = dto.DiscountPrice;
                course.Hours = dto.Hours;
                course.IsBestSeller = dto.IsBestSeller;
                course.LikesInNumbers = dto.LikesInNumbers;
                course.LikesInProcent = dto.LikesInProcent;
                course.Author = dto.Author;


                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return Ok(CourseFactory.Create(course));
            }
            else
            {
                return NotFound();
            }
        }

        return BadRequest(ModelState);
    }

    #endregion

    #region DELETE

    [HttpDelete]
    [UseApiKey]
    public async Task<IActionResult> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        return BadRequest();
    }

    #endregion
}
