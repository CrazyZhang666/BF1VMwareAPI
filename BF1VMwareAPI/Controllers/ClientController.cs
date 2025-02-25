using BF1VMwareAPI.Base;
using BF1VMwareAPI.Client;

namespace BF1VMwareAPI.Controllers;

/// <summary>
/// 客户端
/// </summary>
public class ClientController : ApiBaseController
{
    /// <summary>
    /// 获取兵种数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetKitDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", KitDB.AllKitInfoDb);
    }

    /// <summary>
    /// 获取地图数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetMapDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", MapDB.AllMapInfoDb);
    }

    /// <summary>
    /// 获取模式数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetModeDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", ModeDB.AllModeInfoDb);
    }

    /// <summary>
    /// 获取载具数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetVehicleDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", VehicleDB.AllVehicleInfoDb);
    }

    /// <summary>
    /// 获取武器数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetWeaponDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", WeaponDB.AllWeaponInfoDb);
    }

    /// <summary>
    /// 获取小队数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetSquadDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", SquadDb.AllSquadInfoDb);
    }

    /// <summary>
    /// 获取姿态类型数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetPoseTypeDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", PoseTypeDb.AllPoseTypeInfoDb);
    }

    /// <summary>
    /// 获取客户端状态数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetClientStateDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", ClientStateDb.AllClientStateInfoDb);
    }

    /// <summary>
    /// 获取游戏类型数据库
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult GetGameTypeDb()
    {
        return RespStatus(StatusCodes.Status200OK, "操作成功", GameTypeDb.AllGameTypeInfoDb);
    }
}