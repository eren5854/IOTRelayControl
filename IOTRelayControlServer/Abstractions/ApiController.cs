using Microsoft.AspNetCore.Mvc;

namespace IOTRelayControlServer.Abstractions;
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
}
