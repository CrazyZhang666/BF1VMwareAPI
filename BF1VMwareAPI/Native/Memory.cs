using BF1VMwareAPI.Helper;
using Vmmsharp;

namespace BF1VMwareAPI.Native;

public static class Memory
{
    public const string Bf1ExeName = "bf1.exe";

    /// <summary>
    /// Vmm实例
    /// </summary>
    public static Vmm VmmInstance { get; private set; } = null;
    /// <summary>
    /// 战地1Vmm进程类
    /// </summary>
    public static VmmProcess Bf1VmmProcess { get; private set; } = null;

    /// <summary>
    /// 释放内存模块
    /// </summary>
    public static void UnInitialize()
    {
        try
        {
            UnInitBf1Process();
            UnInitVmwareVMX();

            LoggerHelper.Info("释放内存模块成功");
        }
        catch (Exception ex)
        {
            LoggerHelper.Error("释放内存模块发生异常", ex);
        }
    }

    /// <summary>
    /// 设置 VmmInstance
    /// </summary>
    public static void SetVmmInstance(Vmm vmm)
    {
        VmmInstance = vmm;
    }

    /// <summary>
    /// 设置 Bf1VmmProcess
    /// </summary>
    public static void SetBf1VmmProcess(VmmProcess vmmProcess)
    {
        Bf1VmmProcess = vmmProcess;
    }

    /// <summary>
    /// 虚拟机Vmm实例是否初始化成功
    /// </summary>
    public static bool IsVmmInitSuccess()
    {
        return VmmInstance is not null;
    }

    /// <summary>
    /// 战地1进程是否初始化成功
    /// </summary>
    public static bool IsBf1InitSuccess()
    {
        return Bf1VmmProcess is not null;
    }

    /// <summary>
    /// 释放 VmwareVMX
    /// </summary>
    public static void UnInitVmwareVMX()
    {
        if (VmmInstance is not null)
        {
            VmmInstance.Close();
            VmmInstance.Dispose();
            VmmInstance = null;
            LoggerHelper.Info("释放 VmwareVMX 成功");
        }
    }

    /// <summary>
    /// 释放 Bf1VmmProcess
    /// </summary>
    public static void UnInitBf1Process()
    {
        if (Bf1VmmProcess is not null)
        {
            Bf1VmmProcess = null;
            LoggerHelper.Info("释放 Bf1VmmProcess 成功");
        }
    }

    /// <summary>
    /// 泛型读取内存
    /// </summary>
    public static T Read<T>(long address) where T : struct
    {
        var buffer = new byte[Marshal.SizeOf(typeof(T))];
        buffer = Bf1VmmProcess.MemRead((ulong)address, (uint)buffer.Length);
        return ByteArrayToStructure<T>(buffer);
    }

    /// <summary>
    /// 读取字符串
    /// </summary>
    public static string ReadString(long address, int size)
    {
        var buffer = new byte[size];
        buffer = Bf1VmmProcess.MemRead((ulong)address, (uint)buffer.Length);

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
    public static bool IsValid(long Address)
    {
        return Address >= 0x10000 && Address < 0x000F000000000000;
    }

    /// <summary>
    /// 字符数组转结构
    /// </summary>
    private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
    {
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

        try
        {
            var data = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            if (data is not null)
                return (T)data;
            else
                return default;
        }
        finally
        {
            handle.Free();
        }
    }
}