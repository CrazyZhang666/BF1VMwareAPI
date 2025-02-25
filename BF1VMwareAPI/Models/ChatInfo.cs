namespace BF1VMwareAPI.Models;

public class ChatInfo
{
    public string Sender { get; set; }
    public long SenderPtr { get; set; }
    public string Content { get; set; }
    public long ContentPtr { get; set; }
}