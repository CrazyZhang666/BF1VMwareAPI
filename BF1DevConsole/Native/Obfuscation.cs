namespace BF1DevConsole.Native;

public static class Obfuscation
{
    /// <summary>
    /// 读取自己指针
    /// </summary>
    /// <returns></returns>
    public static long GetLocalPlayer()
    {
        return EncryptedPlayerMgr(0xF0, 0);
    }

    /// <summary>
    /// 读其他玩家指针
    /// </summary>
    /// <param name="id">玩家ID</param>
    /// <returns></returns>
    public static long GetPlayerById(int id)
    {
        return EncryptedPlayerMgr(0xF8, id);
    }

    /// <summary>
    /// 解密玩家指针
    /// </summary>
    /// <param name="offset">自己 0xF0 玩家 0xF8</param>
    /// <param name="id">如果是自己，则id=0</param>
    /// <returns></returns>
    private static long EncryptedPlayerMgr(int offset, int id)
    {
        var pClientGameContext = Memory.Read<long>(Offsets.CLIENTGAMECONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return 0;

        var pClientPlayerManager = Memory.Read<long>(pClientGameContext + 0x68);
        if (!Memory.IsValid(pClientPlayerManager))
            return 0;

        var pObfuscationMgr = Memory.Read<long>(Offsets.OBFUSCATIONMGR);
        if (!Memory.IsValid(pObfuscationMgr))
            return 0;

        var playerListXorValue = Memory.Read<long>(pClientPlayerManager + offset);
        var playerListKey = playerListXorValue ^ Memory.Read<long>(pObfuscationMgr + 0x70);

        var mpBucketArray = Memory.Read<long>(pObfuscationMgr + 0x10);

        var mnBucketCount = Memory.Read<int>(pObfuscationMgr + 0x18);
        if (mnBucketCount == 0)
            return 0;

        var startCount = (int)playerListKey % mnBucketCount;

        var mpBucketArray_startCount = Memory.Read<long>(mpBucketArray + startCount * 0x08);
        var node_first = Memory.Read<long>(mpBucketArray_startCount);
        var node_second = Memory.Read<long>(mpBucketArray_startCount + 0x08);
        var node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);

        while (playerListKey != node_first)
        {
            mpBucketArray_startCount = node_mpNext;

            node_first = Memory.Read<long>(mpBucketArray_startCount);
            node_second = Memory.Read<long>(mpBucketArray_startCount + 0x08);
            node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);
        }

        var encryptedPlayerMgr = node_second;
        // ...
        return EncryptedPlayerMgr_GetPlayer(encryptedPlayerMgr, id);
    }

    /// <summary>
    /// 解密玩家指针
    /// </summary>
    /// <param name="encryptedPlayerMgr">玩家指针</param>
    /// <param name="id">玩家ID</param>
    /// <returns></returns>
    private static long EncryptedPlayerMgr_GetPlayer(long encryptedPlayerMgr, int id)
    {
        var xorValue1 = Memory.Read<long>(encryptedPlayerMgr + 0x20) ^ Memory.Read<long>(encryptedPlayerMgr + 0x08);
        var xorValue2 = xorValue1 ^ Memory.Read<long>(encryptedPlayerMgr + 0x10);
        if (!Memory.IsValid(xorValue2))
            return 0;

        return xorValue1 ^ Memory.Read<long>(xorValue2 + 0x08 * id);
    }
}