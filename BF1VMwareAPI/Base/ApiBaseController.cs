namespace BF1VMwareAPI.Base;

[ApiController]
[Route("[controller]/[action]")]
public class ApiBaseController : ControllerBase
{
    protected ObjectResult RespStatus(int code, string message)
    {
        return StatusCode(code, new RespResult<string>(code, message));
    }

    protected ObjectResult RespStatus<T>(int code, string message, T data = default)
    {
        return StatusCode(code, new RespResult<T>(code, message, data));
    }
}