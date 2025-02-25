using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class ClientStateDb
{
    /// <summary>
    /// 客户端状态数据
    /// </summary>
    public readonly static List<MetaInfo> AllClientStateInfoDb =
    [
        new() { Id="0", Name="Waiting For Static Bundle Load" },
        new() { Id="1", Name="Load Profile Options" },
        new() { Id="2", Name="Lost Connection" },
        new() { Id="3", Name="Waiting ForUnload" },
        new() { Id="4", Name="Startup" },
        new() { Id="5", Name="Start Server" },
        new() { Id="6", Name="Waiting For Level" },
        new() { Id="7", Name="Start Loading Level" },
        new() { Id="8", Name="Waiting For Level Loaded" },
        new() { Id="9", Name="Waiting For Level Link" },
        new() { Id="10", Name="Level Linked" },
        new() { Id="11", Name="Waiting For Ghosts" },
        new() { Id="12", Name="Ingame" },
        new() { Id="13", Name="Leave Ingame" },
        new() { Id="14", Name="Connect To Server" },
        new() { Id="15", Name="Shutting Down" },
        new() { Id="16", Name="Shutdown" },
        new() { Id="17", Name="None" }
    ];
}