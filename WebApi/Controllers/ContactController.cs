using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    #region CREATE

    [HttpPost]
    [UseApiKey]
    public async Task<IActionResult> Create(ContactDto dto)
    {
        if (ModelState.IsValid)
        {
            var contactMessage = new ContactEntity
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Service = dto.Service,
                Message = dto.Message,
            };

            _context.Contacts.Add(contactMessage);
            await _context.SaveChangesAsync();

            return Ok(contactMessage);
        }

        return BadRequest(ModelState);
    }

    #endregion
}
