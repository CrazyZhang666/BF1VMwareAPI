using System;
using System.Runtime.InteropServices;

namespace BF1DevConsole.Native;

public static class Win32
{
    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, int nsize, out IntPtr lpNumberOfBytesRead);
}