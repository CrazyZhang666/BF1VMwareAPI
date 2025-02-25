using BF1VMwareAPI.Base;
using BF1VMwareAPI.Core;
using BF1VMwareAPI.Native;

namespace BF1VMwareAPI.Controllers;

/// <summary>
/// 游戏
/// </summary>
public class GameController : ApiBaseController
{
    /// <summary>
    /// 获取游戏状态信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetGameState()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var state = Game.GetGameState();
        if (state is null)
            return RespStatus(StatusCodes.Status404NotFound, "未获取到游戏状态信息");

        return RespStatus(StatusCodes.Status200OK, "操作成功", state);
    }

    /// <summary>
    /// 获取游戏渲染信息
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetDxRenderData()
    {
        if (!Memory.IsBf1InitSuccess())
            return RespStatus(StatusCodes.Status500InternalServerError, "战地1内存模块未初始化");

        var dxRender = Game.GetDxRenderData();
        if (dxRender is null)
            return RespStatus(StatusCodes.Status404NotFound, "未获取到游戏渲染信息");

        return RespStatus(StatusCodes.Status200OK, "操作成功", dxRender);
    }
}