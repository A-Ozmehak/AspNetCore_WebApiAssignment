using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    #region POST

    [HttpPost]
    [UseApiKey]
    public async Task<IActionResult> Subscribe(SubscriberDto dto)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Subscribers.AnyAsync(x => x.Email == dto.Email))
            {
                _context.Subscribers.Add(dto);
                await _context.SaveChangesAsync();
                return Created("", null);
            }
            else
            {
                return Conflict();
            }
        }

        return BadRequest();
    }

    #endregion

    #region DELETE

    [HttpDelete]
    [UseApiKey]
    public async Task<IActionResult> DeleteSubscription(string email)
    {
        if (ModelState.IsValid)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
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
