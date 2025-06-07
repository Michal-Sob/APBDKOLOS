using APBDKOLOS.Dtos;
using APBDKOLOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKOLOS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubController : ControllerBase
{
    private readonly ISubService _subService;

    public SubController(ISubService subService)
    {
        _subService = subService;
    }

    [HttpGet("client/{id}")]
    public  IActionResult GetClientAndSubscription(int id)
    {
        try 
        {
            var clientAndSub = _subService.GetClientAndSubscription(id);

            if (clientAndSub == null)
            {
                return NotFound($"Client with ID {id} not found or has no subscription.");
            }

            return Ok(clientAndSub);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost]
    public ActionResult ProcessPayment([FromBody] PaymentRequestDto paymentRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = _subService.PostPayment(paymentRequest);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Wystąpił błąd serwera: {ex.Message}");
        }
    }
}