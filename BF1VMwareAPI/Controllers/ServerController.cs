using BF1VMwareAPI.Base;
using BF1VMwareAPI.Core;
using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;
using BF1VMwareAPI.Utils;

namespace BF1VMwareAPI.Controllers;

/// <summary>
/// 服务器
/// </summary>
public class ServerController : ApiBaseController
{
    /// <summary>
    /// 获取当前服务器数据
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetServerData()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var serverData = new ServerData
        {
            // 服务器名称
            Name = Server.GetServerName(),
            // 服务器游戏Id
            GameId = Server.GetServerGameId(),
            // 服务器地图名称
            MapName = Server.GetMapName(),
            // 服务器游戏模式
            GameMode = Server.GetGameMode(),
            // 服务器游戏时间
            GameTime = Server.GetGameTime()
        };

        // 服务器地图中文名称
        serverData.MapName2 = ClientUtil.GetMapName(serverData.MapName);
        // 服务器游戏模式中文名称
        serverData.GameMode2 = ClientUtil.GetGameMode(serverData.GameMode);

        return RespStatus(StatusCodes.Status200OK, "操作成功", serverData);
    }
}