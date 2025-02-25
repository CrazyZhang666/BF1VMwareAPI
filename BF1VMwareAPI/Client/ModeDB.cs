using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class ModeDB
{
    /// <summary>
    /// 地图模式数据
    /// </summary>
    public readonly static List<MetaInfo> AllModeInfoDb =
    [
        new() { Id="AirAssault0", Name="空中突袭" },
        new() { Id="Breakthrough0", Name="闪击行动" },
        new() { Id="BreakthroughLarge0", Name="行动模式" },
        new() { Id="Conquest0", Name="征服" },
        new() { Id="Domination0", Name="抢攻" },
        new() { Id="Possession0", Name="战争信鸽" },
        new() { Id="Rush0", Name="突袭" },
        new() { Id="TeamDeathMatch0", Name="团队死斗" },
        new() { Id="TugOfWar0", Name="前线" },
        new() { Id="ZoneControl0", Name="空降补给" }
    ];
}