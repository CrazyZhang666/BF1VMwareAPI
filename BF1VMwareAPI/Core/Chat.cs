using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;

namespace BF1VMwareAPI.Core;

public static class Chat
{
    /// <summary>
    /// 获取聊天管理指针是否有效
    /// </summary>
    private static bool GetChatManagerIsValid()
    {
        var pClientGameContext = Memory.Read<long>(Offsets.CLIENT_GAME_CONTEXT);
        if (!Memory.IsValid(pClientGameContext))
            return false;

        var pOnlineManager = Memory.Read<long>(pClientGameContext + 0x70);
        if (!Memory.IsValid(pOnlineManager))
            return false;

        var pClientConnection = Memory.Read<long>(pOnlineManager + 0x38);
        if (!Memory.IsValid(pClientConnection))
            return false;

        var pChatManager = Memory.Read<long>(pClientConnection + 0x7E10);
        if (!Memory.IsValid(pChatManager))
            return false;

        return true;
    }

    /// <summary>
    /// 判断战地1聊天框是否开启，开启返回true，关闭或其他返回false
    /// </summary>
    private static bool GetChatBoxIsOpen()
    {
        var address = Memory.Read<long>(Offsets.CHAT_MESSAGE);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x08);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x28);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x00);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x20);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x18);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x28);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x38);
        if (!Memory.IsValid(address))
            return false;
        address = Memory.Read<long>(address + 0x40);
        if (!Memory.IsValid(address))
            return false;

        return Memory.Read<byte>(address + 0x30) == 0x01;
    }

    /// <summary>
    /// 获取聊天框列表指针地址，成功返回指针，失败返回0
    /// </summary>
    private static long GetChatListPtrAddress()
    {
        var address = Memory.Read<long>(Offsets.CHAT_MESSAGE);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x70);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x20);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x18);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x28);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x28);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x38);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0xD8);
        if (!Memory.IsValid(address))
            return 0;
        address = Memory.Read<long>(address + 0x50);
        if (!Memory.IsValid(address))
            return 0;
        else
            return address;
    }

    /// <summary>
    /// 获取最新聊天发送者
    /// </summary>
    private static string GetLatestChatSender(long chatPtr, out long pSender)
    {
        pSender = 0;

        pSender = Memory.Read<long>(chatPtr + Offsets.CHAT_LATEST_SENDER);
        if (!Memory.IsValid(pSender))
            return string.Empty;
        pSender = Memory.Read<long>(pSender);
        if (!Memory.IsValid(pSender))
            return string.Empty;

        return Memory.ReadString(pSender, 32);
    }

    /// <summary>
    /// 获取最新聊天发送内容
    /// </summary>
    private static string GetLatestChatContent(long chatPtr, out long pContent)
    {
        pContent = 0;

        pContent = Memory.Read<long>(chatPtr + Offsets.CHAT_LATEST_CONTENT);
        if (!Memory.IsValid(pContent))
            return string.Empty;
        pContent = Memory.Read<long>(pContent);
        if (!Memory.IsValid(pContent))
            return string.Empty;

        return Memory.ReadString(pContent, 256);
    }

    /// <summary>
    /// 获取服务器最新聊天信息
    /// </summary>
    public static ChatInfo GetLatestChatInfo()
    {
        if (!GetChatManagerIsValid())
            return null;

        var chatPtr = GetChatListPtrAddress();
        if (!Memory.IsValid(chatPtr))
            return null;

        /////////////////////////////

        var chatInfo = new ChatInfo();

        var sender = GetLatestChatSender(chatPtr, out long pSender);
        var content = GetLatestChatContent(chatPtr, out long pContent);

        if (Memory.IsValid(pSender) && Memory.IsValid(pContent))
        {
            // 删除末尾字符
            chatInfo.Sender = sender.TrimEnd(':');
            chatInfo.SenderPtr = pSender;
            chatInfo.Content = content;
            chatInfo.ContentPtr = pContent;
        }

        return chatInfo;
    }
}