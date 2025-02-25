namespace BF1VMwareAPI.Base;

public class RespResult<T>(int code, string message, T data = default)
{
    public int Code { get; set; } = code;
    public string Message { get; set; } = message;
    public T Data { get; set; } = data;
    public DateTime Time { get; set; } = DateTime.Now;
}