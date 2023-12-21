using Microsoft.AspNetCore.Mvc;

namespace Urfu23.Backoffice;

public class BackofficeController: Controller
{
    [HttpGet("/backoffice/first")]
    public async Task<IActionResult> FirstBackofficeController(CancellationToken cancellationToken)
    {
        return Ok("Work done from backoffice controller");
    } 
}