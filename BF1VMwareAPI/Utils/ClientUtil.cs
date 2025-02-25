using BF1VMwareAPI.Client;
using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Utils;

public static class ClientUtil
{
    /// <summary>
    /// 获取载具信息
    /// </summary>
    public static WeaponInfo GetVehicleInfo(string vehicle)
    {
        var result = VehicleDB.AllVehicleInfoDb.Find(var => var.Id == vehicle);
        if (result is not null)
            return result;

        return null;
    }

    /// <summary>
    /// 获取武器信息
    /// </summary>
    public static WeaponInfo GetWeaponInfo(string weapon)
    {
        var result = WeaponDB.AllWeaponInfoDb.Find(item => item.Id.Equals(weapon));
        if (result is not null)
            return result;

        return null;
    }

    ///////////////////////////////////////////////

    /// <summary>
    /// 获取当前地图对应中文名称
    /// </summary>
    public static string GetMapName(string map)
    {
        var result = MapDB.AllMapInfoDb.Find(var => var.Id == map);
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取游戏模式对应中文名称
    /// </summary>
    public static string GetGameMode(string mode)
    {
        var result = ModeDB.AllModeInfoDb.Find(var => var.Id == mode);
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取小队的中文名称
    /// </summary>
    public static string GetSquadName(int squadId)
    {
        var result = SquadDb.AllSquadInfoDb.Find(var => var.Id == squadId.ToString());
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取玩家当前兵种名称
    /// </summary>
    public static string GetPlayerKitName(string kit)
    {
        var result = KitDB.AllKitInfoDb.Find(var => var.Id == kit);
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取战地1客户端状态名称
    /// </summary>
    public static string GetClientStateName(int stateId)
    {
        var result = ClientStateDb.AllClientStateInfoDb.Find(var => var.Id == stateId.ToString());
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取战地1游戏类型名称
    /// </summary>
    public static string GetGameTypeName(int typeId)
    {
        var result = GameTypeDb.AllGameTypeInfoDb.Find(var => var.Id == typeId.ToString());
        if (result is not null)
            return result.Name;

        return string.Empty;
    }

    /// <summary>
    /// 获取战地1玩家姿态
    /// </summary>
    public static string GetPlayerPoseTypeName(byte poseType)
    {
        var result = PoseTypeDb.AllPoseTypeInfoDb.Find(var => var.Id == poseType.ToString());
        if (result is not null)
            return result.Name;

        return string.Empty;
    }
}