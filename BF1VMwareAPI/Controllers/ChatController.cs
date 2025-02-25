using BF1VMwareAPI.Base;
using BF1VMwareAPI.Core;
using BF1VMwareAPI.Native;

namespace BF1VMwareAPI.Controllers;

/// <summary>
/// 聊天
/// </summary>
public class ChatController : ApiBaseController
{
    /// <summary>
    /// 获取服务器最新聊天信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetLatestChatInfo()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var chatInfo = Chat.GetLatestChatInfo();
        if (chatInfo is null)
            return RespStatus(StatusCodes.Status404NotFound, "未获取到服务器最新聊天信息");

        return RespStatus(StatusCodes.Status200OK, "操作成功", chatInfo);
    }
}