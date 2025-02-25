using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class SquadDb
{
    /// <summary>
    /// 小队数据
    /// </summary>
    public readonly static List<MetaInfo> AllSquadInfoDb =
    [
        new() { Id="0", Name="无" },
        new() { Id="1", Name="苹果" },
        new() { Id="2", Name="奶油" },
        new() { Id="3", Name="查理" },
        new() { Id="4", Name="达夫" },
        new() { Id="5", Name="爱德华" },
        new() { Id="6", Name="弗莱迪" },
        new() { Id="7", Name="乔治" },
        new() { Id="8", Name="哈利" },
        new() { Id="9", Name="墨水" },
        new() { Id="10", Name="强尼" },
        new() { Id="11", Name="国王" },
        new() { Id="12", Name="伦敦" },
        new() { Id="13", Name="猿猴" },
        new() { Id="14", Name="疯子" },
        new() { Id="15", Name="橘子" }
    ];
}