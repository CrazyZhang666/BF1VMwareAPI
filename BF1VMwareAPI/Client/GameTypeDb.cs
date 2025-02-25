using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public class GameTypeDb
{
    /// <summary>
    /// 游戏类型数据
    /// </summary>
    public readonly static List<MetaInfo> AllGameTypeInfoDb =
    [
        new() { Id="0", Name="Single Player" },
        new() { Id="1", Name="Hosted" },
        new() { Id="2", Name="Mp Tutorial" },
        new() { Id="3", Name="Joined" }
    ];
}