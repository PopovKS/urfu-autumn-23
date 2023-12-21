using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    [HttpGet("/product/api")]
    public async Task<IActionResult> ApiMethod(CancellationToken cancellationToken)
    {
        return Json("Done work from API");
    }
}