using BF1VMwareAPI.Base;
using BF1VMwareAPI.Core;
using BF1VMwareAPI.Enums;
using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;

namespace BF1VMwareAPI.Controllers;

/// <summary>
/// 玩家
/// </summary>
public class PlayerController : ApiBaseController
{
    /// <summary>
    /// 获取自己信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetLocalPlayer()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var localPlayer = Player.GetLocalPlayer();
        if (localPlayer is null)
            return RespStatus(StatusCodes.Status404NotFound, "未获取到本机玩家信息");

        return RespStatus(StatusCodes.Status200OK, "操作成功", localPlayer);
    }

    /// <summary>
    /// 获取游戏内玩家列表信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetAllPlayerList()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var clientPlayers = Player.GetAllPlayerList();
        if (clientPlayers.Count == 0)
            return RespStatus(StatusCodes.Status404NotFound, "服务器全部玩家列表为空");

        for (var i = 0; i < clientPlayers.Count; i++)
            clientPlayers[i].Index = i + 1;

        return RespStatus(StatusCodes.Status200OK, "操作成功", clientPlayers);
    }

    /// <summary>
    /// 获取游戏内队伍1玩家列表信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult<List<PlayerInfo>> GetTeam1PlayerList()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var teamList = Player.GetTeamPlayerList(TeamId.Team1);
        if (teamList.Count == 0)
            return RespStatus(StatusCodes.Status404NotFound, "服务器队伍1玩家列表为空");

        return RespStatus(StatusCodes.Status200OK, "操作成功", teamList);
    }

    /// <summary>
    /// 获取游戏内队伍2玩家列表信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult<List<PlayerInfo>> GetTeam2PlayerList()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var teamList = Player.GetTeamPlayerList(TeamId.Team2);
        if (teamList.Count == 0)
            return RespStatus(StatusCodes.Status404NotFound, "服务器队伍2玩家列表为空");

        return RespStatus(StatusCodes.Status200OK, "操作成功", teamList);
    }
}