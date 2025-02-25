using BF1DevConsole.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BF1DevConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.Title = "战地1获取游戏数据 v1.0.0.0";

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        var pList = Process.GetProcessesByName("bf1");
        var bf1Process = pList.Length > 0 ? pList[0] : null;
        if (bf1Process != null)
        {
            Memory.Initialize();

            var pClientPlayer = Obfuscation.GetLocalPlayer();
            // 载具实体指针
            var pClientVehicleEntity = Memory.Read<long>(pClientPlayer + 0x1D38);
            // 玩家实体指针
            var pClientSoldierEntity = Memory.Read<long>(pClientPlayer + 0x1D48);

            Console.WriteLine($"玩家基址\t : \t0x{pClientPlayer:x}");
            Console.WriteLine($"玩家载具基址\t : \t0x{pClientVehicleEntity:x}");
            Console.WriteLine($"玩家士兵基址\t : \t0x{pClientSoldierEntity:x}");

            // 载具武器组件数量
            var componentCount = Memory.Read<byte>(pClientVehicleEntity + 0x570 + 0x09);
            Console.WriteLine($"载具武器组件数量\t : \t{componentCount}");
            for (var count = 0; count < componentCount; count++)
            {
                var componentPtr = pClientVehicleEntity + 0x570 + count * 0x20;

                var testActive = Memory.Read<short>(componentPtr - 0x08);
                if (testActive != 2056)
                    continue;

                Console.WriteLine($"componentPtr\t : \t0x{componentPtr:x}");

                var pointer = Memory.Read<long>(componentPtr);
                if (!Memory.IsValid(pointer))
                    continue;
                var weaponComponentData = Memory.Read<long>(pointer + 0x10);
                if (!Memory.IsValid(weaponComponentData))
                    continue;
                var weaponPointer = Memory.Read<long>(weaponComponentData + 0x120);
                if (!Memory.IsValid(weaponPointer))
                    continue;

                var weaponName = Memory.ReadString(weaponPointer, 64);
                if (!string.IsNullOrWhiteSpace(weaponName))
                    Console.WriteLine($"载具武器组件名称\t : \t{weaponName}");
            }

            Console.WriteLine("按任意键结束程序");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("未发现战地1游戏进程");
            Console.WriteLine("");

            Console.WriteLine("按任意键结束程序");
            Console.ReadKey();
        }
    }
}