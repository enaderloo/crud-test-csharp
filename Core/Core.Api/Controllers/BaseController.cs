using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class BaseController: ControllerBase
{
    public BaseController()
    {
    }
}
