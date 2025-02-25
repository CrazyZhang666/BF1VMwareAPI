using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class KitDB
{
    /// <summary>
    /// 兵种数据
    /// </summary>
    public readonly static List<MetaInfo> AllKitInfoDb =
    [
        new() { Id="ID_M_TANKER", Name="坦克" },
        new() { Id="ID_M_PILOT", Name="飞机" },
        new() { Id="ID_M_CAVALRY", Name="骑兵" },
        new() { Id="ID_M_SENTRY", Name="哨兵" },
        new() { Id="ID_M_FLAMETHROWER", Name="喷火兵" },
        new() { Id="ID_M_INFILTRATOR", Name="入侵者" },
        new() { Id="ID_M_TRENCHRAIDER", Name="战壕奇兵" },
        new() { Id="ID_M_ANTITANK", Name="坦克猎手" },
        new() { Id="ID_M_ASSAULT", Name="突击兵" },
        new() { Id="ID_M_MEDIC", Name="医疗兵" },
        new() { Id="ID_M_SUPPORT", Name="支援兵" },
        new() { Id="ID_M_SCOUT", Name="侦察兵" }
    ];
}