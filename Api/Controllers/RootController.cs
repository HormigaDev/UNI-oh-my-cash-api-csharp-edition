namespace App.Api.Controllers;

using App.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet]
    public IActionResult GetInfo()
    {
        var response = new ApiInfo()
        {
            Name = "Oh My Cash API - C# Edition",
            Version = "1.0.0",
            Author = "Isai Medina <HormigaDev hormigadev7@gmail.com>"
        };
        return Ok(response);
    }
}