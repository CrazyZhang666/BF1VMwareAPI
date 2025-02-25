using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BF1DevConsole.Native;

public static class Memory
{
    /// <summary>
    /// 战地1进程类
    /// </summary>
    private static Process Bf1Process { get; set; } = null;

    /// <summary>
    /// 战地1进程Id
    /// </summary>
    public static int Bf1ProId { get; private set; } = 0;
    /// <summary>
    /// 战地1主模块基地址
    /// </summary>
    public static long Bf1ProBaseAddress { get; private set; } = 0;
    /// <summary>
    /// 战地1进程句柄
    /// </summary>
    public static IntPtr Bf1ProHandle { get; private set; } = IntPtr.Zero;

    /// <summary>
    /// 初始化内存模块
    /// </summary>
    /// <returns></returns>
    public static bool Initialize()
    {
        if (Bf1ProHandle != IntPtr.Zero)
            return false;

        var pArray = Process.GetProcessesByName("bf1");
        if (pArray.Length == 0)
            return false;

        Bf1Process = pArray.First();

        if (Bf1Process.MainWindowHandle == IntPtr.Zero)
            return false;

        if (Bf1Process.Id == 0)
            return false;

        Bf1ProId = Bf1Process.Id;
        Bf1ProBaseAddress = Bf1Process.MainModule.BaseAddress.ToInt64();
        Bf1ProHandle = Bf1Process.Handle;

        return true;
    }

    /// <summary>
    /// 释放内存模块
    /// </summary>
    public static void UnInitialize()
    {
        if (Bf1ProHandle != IntPtr.Zero)
            Bf1ProHandle = IntPtr.Zero;

        if (Bf1ProBaseAddress != 0)
            Bf1ProBaseAddress = 0;

        if (Bf1ProId != 0)
            Bf1ProId = 0;

        if (Bf1Process != null)
            Bf1Process = null;
    }

    /// <summary>
    /// 战地1内存模块是否初始化成功
    /// </summary>
    /// <returns></returns>
    public static bool IsInitSuccess()
    {
        return Bf1ProHandle != IntPtr.Zero;
    }

    /// <summary>
    /// 泛型读取内存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="address"></param>
    /// <returns></returns>
    public static T Read<T>(long address) where T : struct
    {
        var buffer = new byte[Marshal.SizeOf(typeof(T))];
        Win32.ReadProcessMemory(Bf1ProHandle, address, buffer, buffer.Length, out _);
        return ByteArrayToStructure<T>(buffer);
    }

    /// <summary>
    /// 读取字符串
    /// </summary>
    /// <param name="address"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static string ReadString(long address, int size)
    {
        var buffer = new byte[size];
        Win32.ReadProcessMemory(Bf1ProHandle, address, buffer, size, out _);

        for (int i = 0; i < buffer.Length; i++)
        {
            if (buffer[i] == 0)
            {
                var _buffer = new byte[i];
                Buffer.BlockCopy(buffer, 0, _buffer, 0, i);
                return Encoding.UTF8.GetString(_buffer);
            }
        }

        return Encoding.UTF8.GetString(buffer);
    }

    //////////////////////////////////////////////////////////////////

    /// <summary>
    /// 判断内存地址是否有效
    /// </summary>
    /// <param name="Address"></param>
    /// <returns></returns>
    public static bool IsValid(long Address)
    {
        return Address >= 0x10000 && Address < 0x000F000000000000;
    }

    /// <summary>
    /// 字符数组转结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
    {
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

        try
        {
            var obj = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            if (obj != null)
                return (T)obj;
            else
                return default;
        }
        finally
        {
            handle.Free();
        }
    }
}