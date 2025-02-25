using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;
using BF1VMwareAPI.Utils;

namespace BF1VMwareAPI.Core;

public static class Game
{
    /// <summary>
    /// 获取游戏状态
    /// </summary>
    public static GameState GetGameState()
    {
        var state = new GameState();

        var pClientGameContext = Memory.Read<long>(Offsets.CLIENT_GAME_CONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return null;

        var pLevel = Memory.Read<long>(pClientGameContext + 0x30);
        if (!Memory.IsValid(pLevel))
            return null;

        var pLevelData = Memory.Read<long>(pLevel + 0x18);
        if (!Memory.IsValid(pLevelData))
            return null;

        state.IsMultiplayer = Memory.Read<byte>(pLevelData + 0xC8) == 0x01;
        state.IsCoop = Memory.Read<byte>(pLevelData + 0xC9) == 0x01;
        state.IsMenu = Memory.Read<byte>(pLevelData + 0xCA) == 0x01;
        state.IsEpilogue = Memory.Read<byte>(pLevelData + 0xCB) == 0x01;

        var pMain = Memory.Read<long>(Offsets.MAIN);
        if (!Memory.IsValid(pMain))
            return state;

        var pClient = Memory.Read<long>(pMain + 0x50);
        if (!Memory.IsValid(pClient))
            return state;

        state.ClientStateId = Memory.Read<int>(pClient + 0x390);
        state.ClientState = ClientUtil.GetClientStateName(state.ClientStateId);

        state.GameTypeId = Memory.Read<int>(pClient + 0x45C);
        state.GameType = ClientUtil.GetGameTypeName(state.GameTypeId);

        return state;
    }

    /// <summary>
    /// 获取游戏渲染信息
    /// </summary>
    public static RenderData GetDxRenderData()
    {
        var render = new RenderData();

        var pDxRenderer = Memory.Read<long>(Offsets.DX_RENDERER);
        if (!Memory.IsValid(pDxRenderer))
            return null;

        render.FrameCounter = Memory.Read<int>(pDxRenderer + 0x810);
        render.FramesInProgress = Memory.Read<int>(pDxRenderer + 0x814);
        render.FramesInProgress2 = Memory.Read<int>(pDxRenderer + 0x818);

        render.IsActive = Memory.Read<byte>(pDxRenderer + 0x81C) == 0x01;
        render.AdapterName = Memory.ReadString(Memory.Read<long>(pDxRenderer + 0x918), 64);

        var pScreen = Memory.Read<long>(pDxRenderer + 0x820);
        if (!Memory.IsValid(pScreen))
            return null;

        render.IsTopWindow = Memory.Read<byte>(pScreen + 0x5F) == 0x01;
        render.IsMinimized = Memory.Read<byte>(pScreen + 0x60) == 0x01;
        render.IsMaximized = Memory.Read<byte>(pScreen + 0x61) == 0x01;
        render.IsResizing = Memory.Read<byte>(pScreen + 0x62) == 0x01;

        render.Width = Memory.Read<int>(pScreen + 0x68);
        render.Height = Memory.Read<int>(pScreen + 0x6C);

        return render;
    }
}