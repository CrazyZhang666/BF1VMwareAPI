using BF1VMwareAPI.Native;

namespace BF1VMwareAPI.Core;

public static class Server
{
    /// <summary>
    /// 获取服务器地图名称 Levels/MP/MP_Amiens/MP_Amiens
    /// </summary>
    public static string GetMapName()
    {
        var pClientGameContext = Memory.Read<long>(Offsets.CLIENT_GAME_CONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return string.Empty;

        var pLevel = Memory.Read<long>(pClientGameContext + 0x30);
        if (!Memory.IsValid(pLevel))
            return string.Empty;

        var pLevelName = Memory.Read<long>(pLevel + 0x28);
        if (!Memory.IsValid(pLevelName))
            return string.Empty;

        return Memory.ReadString(pLevelName, 64);
    }

    /// <summary>
    /// 获取服务器游戏模式 Conquest0
    /// </summary>
    public static string GetGameMode()
    {
        var pClientGameContext = Memory.Read<long>(Offsets.CLIENT_GAME_CONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return string.Empty;

        var pLevel = Memory.Read<long>(pClientGameContext + 0x30);
        if (!Memory.IsValid(pLevel))
            return string.Empty;

        var pGameMode = Memory.Read<long>(pLevel + 0x30);
        if (!Memory.IsValid(pGameMode))
            return string.Empty;

        var pGameModeName = Memory.Read<long>(pGameMode + 0x08);
        if (!Memory.IsValid(pGameModeName))
            return string.Empty;

        return Memory.ReadString(pGameModeName, 64);
    }

    /// <summary>
    /// 获取服务器游戏时间
    /// </summary>
    public static float GetGameTime()
    {
        var pClientGameContext = Memory.Read<long>(Offsets.CLIENT_GAME_CONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return 0.0f;

        var pGameTime = Memory.Read<long>(pClientGameContext + 0x88);
        if (!Memory.IsValid(pGameTime))
            return 0.0f;

        return Memory.Read<float>(pGameTime + 0xF8);
    }

    /// <summary>
    /// 获取服务器名称
    /// </summary>
    public static string GetServerName()
    {
        var pServerInfo = Memory.Read<long>(Offsets.SERVER_DATA);
        if (!Memory.IsValid(pServerInfo))
            return string.Empty;

        var pName = Memory.Read<long>(pServerInfo + 0x30);
        if (!Memory.IsValid(pName))
            return string.Empty;

        return Memory.ReadString(pName, 64);
    }

    /// <summary>
    /// 获取服务器游戏Id
    /// </summary>
    public static long GetServerGameId()
    {
        var pServerInfo = Memory.Read<long>(Offsets.SERVER_DATA);
        if (!Memory.IsValid(pServerInfo))
            return 0;

        return Memory.Read<long>(pServerInfo + 0x100);
    }
}
