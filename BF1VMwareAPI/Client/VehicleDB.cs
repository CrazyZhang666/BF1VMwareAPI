using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class VehicleDB
{
    /// <summary>
    /// 全部载具信息
    /// </summary>
    public readonly static List<WeaponInfo> AllVehicleInfoDb =
    [
        // 巡航坦克
        new() { Guid="4723A26F-98AE-55BA-7B3F-3AE7E0E3B0C7", Kind="坦克", Id="ID_P_VNAME_MARKV", Name="巡航坦克 Mark V 巡航坦克" },
        new() { Guid="1708EEA2-212C-49F6-BFBC-8B7B85D7C18E", Kind="巡航坦克1", Id="U_GBR_MarkV_Package_Mortar", Name="迫击炮巡航坦克" },
        new() { Guid="95322EBA-2947-4549-9FD7-190C8A73ACF1", Kind="巡航坦克2", Id="U_GBR_MarkV_Package_AntiTank", Name="坦克猎手巡航坦克" },
        new() { Guid="B700869D-EAFD-490F-B830-8A918B8C9F50", Kind="巡航坦克3", Id="U_GBR_MarkV_Package_SquadSupport", Name="小队支援巡航坦克" },

        // 重型坦克
        new() { Guid="4AA28E71-6FDA-A50B-80A8-B52D070FF884", Kind="坦克", Id="ID_P_VNAME_A7V", Name="重型坦克 AV7 重型坦克" },
        new() { Guid="F55867B4-B103-48BE-84DD-B965126F62B9", Kind="重型坦克1", Id="U_GER_A7V_Package_Assault", Name="重型突击坦克" },
        new() { Guid="A1C403C0-B629-4AAF-8368-A7D48DE01CEE", Kind="重型坦克2", Id="U_GER_A7V_Package_Breakthrough", Name="重型突破坦克" },
        new() { Guid="0805949B-787A-444C-9686-40AE498ADE02", Kind="重型坦克3", Id="U_GER_A7V_Package_Flamethrower", Name="重型火焰喷射器坦克" },
        
        // 轻型坦克
        new() { Guid="A79071D2-5C4F-0BA8-0ECC-FCB1376E2FBA", Kind="坦克", Id="ID_P_VNAME_FT17", Name="轻型坦克 FT-17 轻型坦克" },
        new() { Guid="A0701525-4101-FC60-63BF-A41BE6D93790", Kind="轻型坦克1", Id="U_FRA_FT_Package_37mm", Name="轻型近距离支援坦克" },
        new() { Guid="5F9EE054-B187-4E5F-8C17-20414DD936F8", Kind="轻型坦克2", Id="U_FRA_FT_Package_20mm", Name="轻型侧翼攻击坦克" },
        new() { Guid="0209F742-63E4-44EB-8D59-2F32376A5A18", Kind="轻型坦克3", Id="U_FRA_FT_Package_75mm", Name="轻型榴弹炮坦克" },
        
        // 火炮装甲车
        new() { Guid="A92386FB-7D4B-0E8A-6F2B-CC63FC2A8D78", Kind="坦克", Id="ID_P_VNAME_ARTILLERYTRUCK", Name="装甲车 火炮装甲车" },
        new() { Guid="9BE48854-7F2F-4D4C-929A-0F76CEFFD531", Kind="火炮装甲车1", Id="U_GBR_PierceArrow_Package_Artillery", Name="火炮装甲车" },
        new() { Guid="D2607A39-24CA-4F63-82CC-2F74A143019F", Kind="火炮装甲车2", Id="U_GBR_PierceArrow_Package_AntiAircraft", Name="防空装甲车" },
        new() { Guid="1A772C92-F4FD-4B96-9EA5-D24BFCEFAACE", Kind="火炮装甲车3", Id="U_GBR_PierceArrow_Package_Mortar", Name="迫击炮装甲车" },
        
        // 攻击坦克
        new() { Guid="12F1002B-97FA-490B-822F-E621C6827BFB", Kind="坦克", Id="ID_P_VNAME_STCHAMOND", Name="攻击坦克 圣沙蒙" },
        new() { Guid="DA20A6BA-DB41-4AE4-B21E-F1EFE7155687", Kind="攻击坦克1", Id="U_FRA_StChamond_Package_Assault", Name="战地攻击坦克" },
        new() { Guid="513CDCE5-DA08-4215-8F28-C6D43E4C4DF4", Kind="攻击坦克2", Id="U_FRA_StChamond_Package_Gas", Name="毒气攻击坦克" },
        new() { Guid="2AEA6637-54D3-4497-AC62-F40769CB8BB5", Kind="攻击坦克3", Id="U_FRA_StChamond_Package_Standoff", Name="对峙攻击坦克" },
        
        // 突袭装甲车
        new() { Guid="705E9B4E-5E97-FD3C-9979-A4F2D11AE06F", Kind="坦克", Id="ID_P_VNAME_ASSAULTTRUCK", Name="突袭装甲车 朴帝洛夫·加福德" },
        new() { Guid="DAE015D9-40BD-4EE2-AE53-0E444AD13C97", Kind="突袭装甲车1", Id="U_RU_PutilovGarford_Package_AssaultGun", Name="突袭装甲车" },
        new() { Guid="9F33D192-9120-4C45-ADCA-8FAE8AC45808", Kind="突袭装甲车2", Id="U_RU_PutilovGarford_Package_AntiVehicle", Name="反坦克装甲车" },
        new() { Guid="56EF66F4-93A8-4074-BA39-4CE36C4F940D", Kind="突袭装甲车3", Id="U_RU_PutilovGarford_Package_Recon", Name="侦察装甲车" },

        /////////////////////////////////////////////////////////////////////////////

        // 攻击机
        new() { Guid="EB79DB6E-8A05-9618-3368-34DCBE3C3C17", Kind="飞机", Id="ID_P_VNAME_HALBERSTADT", Name="攻击机 哈尔伯施塔特 CL.II 攻击机" },
        new() { Guid="33A894B8-BCE1-8689-3064-7308BBC781CC", Kind="飞机", Id="ID_P_VNAME_BRISTOL", Name="攻击机 布里斯托 F2.B 攻击机" },
        new() { Guid="189D43F5-E653-416B-B6D6-D0137C28375D", Kind="飞机", Id="ID_P_VNAME_SALMSON", Name="攻击机 A.E.F 2-A2 攻击机" },
        new() { Guid="C3272C97-B92E-4E2A-B842-06EF06DC2CB0", Kind="飞机", Id="ID_P_VNAME_RUMPLER", Name="攻击机 Rumpler C.I 攻击机" },

        new() { Guid="BDCF3DFA-53DA-4596-83DE-1FDCF4FF54D5", Kind="攻击机1", Id="U_2Seater_Package_GroundSupport", Name="地面支援攻击机" },
        new() { Guid="78B907FE-4AB9-4EA3-BA0B-DB4550B10A79", Kind="攻击机2", Id="U_2Seater_Package_TankHunter", Name="坦克猎手攻击机" },
        new() { Guid="77DEED01-0F85-40AB-9FAB-A9F4C986E143", Kind="攻击机3", Id="U_2Seater_Package_AirshipBuster", Name="飞船毁灭者攻击机" },

        // 轰炸机
        new() { Guid="2B0D6EA6-8978-6400-7E85-C8ED33E3B6B3", Kind="飞机", Id="ID_P_VNAME_GOTHA", Name="轰炸机 戈塔 G 轰炸机" },
        new() { Guid="91ECED06-9066-470D-BFE0-A1122118A5B3", Kind="飞机", Id="ID_P_VNAME_CAPRONI", Name="轰炸机 卡普罗尼 CA.5 轰炸机" },
        new() { Guid="DF87BA6E-961D-4F14-86B4-AE5F1326BA14", Kind="飞机", Id="ID_P_VNAME_DH10", Name="轰炸机 Airco DH.10 轰 炸机" },
        new() { Guid="887AA8B4-878C-4943-B688-BAE3E9A5A4E7", Kind="飞机", Id="ID_P_VNAME_HBG1", Name="轰炸机 汉莎·布兰登堡 G.I 轰炸机" },

        new() { Guid="0ABB969B-9C64-46F7-8585-6C193E3D5A89", Kind="轰炸机1", Id="U_Bomber_Package_Barrage", Name="弹幕轰炸机" },
        new() { Guid="FEF203CB-39D0-42DA-9BDF-D9860AFDCBFA", Kind="轰炸机2", Id="U_Bomber_Package_Firestorm", Name="火焰风暴轰炸机" },
        new() { Guid="911EA1A1-D98F-4A49-9D59-037E2815BA12", Kind="轰炸机3", Id="U_Bomber_Package_Torpedo", Name="鱼雷轰炸机" },

        // 战斗机
        new() { Guid="CB7D595C-0376-4C72-A8B8-1455965EA81E", Kind="飞机", Id="ID_P_VNAME_SPAD", Name="战斗机 SPAD S XIII 战斗机" },
        new() { Guid="ADF5B89F-5854-43C4-BAD4-46C9D1C020F5", Kind="飞机", Id="ID_P_VNAME_SOPWITH", Name="战斗机 索普维斯骆驼式战斗机" },
        new() { Guid="AD78AD89-1824-B113-75EC-CFD3180A367D", Kind="飞机", Id="ID_P_VNAME_DR1", Name="战斗机 DR.1 战斗机" },
        new() { Guid="6D6C110E-EBC9-42CC-BB7A-ACA156638D3C", Kind="飞机", Id="ID_P_VNAME_ALBATROS", Name="战斗机 信天翁 D-III 战斗机" },

        new() { Guid="54C04100-3CC3-4915-93C2-3BEA0C7C4728", Kind="战斗机1", Id="U_Scout_Package_Dogfighter", Name="空战机" },
        new() { Guid="551169B3-86FE-43E1-B6D1-803538144C85", Kind="战斗机2", Id="U_Scout_Package_BomberKiller", Name="轰炸机杀手" },
        new() { Guid="80898555-0015-4F22-B8C4-2455EC013318", Kind="战斗机3", Id="U_Scout_Package_TrenchFighter", Name="战壕战斗机" },

        // 重型轰炸机
        new() { Guid="E305E0C1-FED8-00FD-747A-C9282C51F524", Kind="飞机", Id="ID_P_VNAME_ILYAMUROMETS", Name="重型轰炸机 伊利亚·穆罗梅茨" },

        new() { Guid="71E57BCD-D952-45CB-86EA-6EC78284DD27", Kind="重型轰炸机1", Id="U_HeavyBomber_Package_Strategic", Name="重型战略轰炸机" },
        new() { Guid="7F281B18-7FA2-42AE-9486-7545EF3458FE", Kind="重型轰炸机2", Id="U_HeavyBomber_Package_Demolition", Name="重型爆破轰炸机" },
        new() { Guid="C81FBAD3-6611-426C-93FA-43EACD46D34E", Kind="重型轰炸机3", Id="U_HeavyBomber_Package_Support", Name=" 重型支援轰炸机" },

        // 飞船
        new() { Guid="4289E1A4-5EBE-7FA3-52D8-AFDB8ED374BA", Kind="飞船", Id="ID_P_VNAME_ASTRATORRES", Name="飞船 C 级飞船" },

        new() { Guid="9B3FA5E2-AD85-49FE-9FEA-289716C47384", Kind="飞船1", Id="U_CoastalAirship_Package_Observation", Name="观察者" },
        new() { Guid="725003FB-82AF-4751-A2F8-380FB694951F", Kind="飞船2", Id="U_CoastalAirship_Package_Raider", Name="掠夺者" },
        
        /////////////////////////////////////////////////////////////////////////////
        
        // 驱逐舰
        new() { Guid="67B44E81-D1DA-B485-D185-D6520CF59E4B", Kind="驱逐舰", Id="ID_P_VNAME_HMS_LANCE", Name="驱逐舰 L 级驱逐舰" },

        new() { Guid="22C66AF9-9865-4B5D-B02C-2B66F6104F35", Kind="驱逐舰1", Id="U_HMS_Lance_Package_Destroyer", Name="鱼雷艇驱逐舰" },
        new() { Guid="DFEF3253-6560-45DC-8123-C0BC943B0E7F", Kind="驱逐舰2", Id="U_HMS_Lance_Package_Minelayer", Name="水雷布设艇" },
        
        /////////////////////////////////////////////////////////////////////////////
        
        // 战马
        new() { Guid="7CA00F5A-E5DE-3FD9-ECAD-7D4FC5C1AC80", Kind="骑兵", Id="ID_P_VNAME_HORSE", Name="骑兵 战马" },

        /////////////////////////////////////////////////////////////////////////////
        
        // 迫击炮
        new() { Guid="C71A02C3-608E-42AA-9179-A4324A4D4539", Kind="特殊载具", Id="ID_P_INAME_U_MORTAR", Name="特殊载具 空爆迫击炮" },
        new() { Guid="8BD0FABD-DCCE-4031-8156-B77866FCE1A0", Kind="特殊载具", Id="ID_P_INAME_MORTAR_HE", Name="特殊载具 高爆迫击炮" },
            
        /////////////////////////////////////////////////////////////////////////////

        // 运输载具        
        new() { Guid="1F37F90F-F85E-A4EA-0CA0-977FBC04DB6C", Kind="运输载具", Id="ID_P_VNAME_MODEL30", Name="运输载具 M30 侦察车" },
        new() { Guid="A9D9062B-FFEC-429E-9DD5-E24EB9D9C51B", Kind="运输载具", Id="ID_P_VNAME_MERCEDES_37", Name="运输载具 37/95 侦察车" },
        new() { Guid="F73DA041-0864-4782-BEDD-D9C08D86DA7D", Kind="运输载具", Id="ID_P_VNAME_BENZ_MG", Name="运输载具 KFT 侦察车" },
        new() { Guid="56C8EC6A-6667-547E-8393-B047A1BCB730", Kind="运输载具", Id="ID_P_VNAME_MOTORCYCLE", Name="运输载具 MC 18J 附边车摩托车" },
        new() { Guid="41A7B28A-FE39-4FC8-9AA3-9AD7BC4F6A3C", Kind="运输载具", Id="ID_P_VNAME_NSU", Name="运输载具 MC 3.5HP  附边车摩托车" },
        new() { Guid="7FEDA17B-6A27-1946-A02E-AA72A72FBCD7", Kind="运输载具", Id="ID_P_VNAME_ROLLS", Name="运输载具 RNAS 装甲车" },
        new() { Guid="045085BF-D9E2-476F-9363-C11DD9BDDC61", Kind="运输载具", Id="ID_P_VNAME_ROMFELL", Name="运输载具 Romfell 装甲车" },
        new() { Guid="B30F9312-6887-46C5-873F-2670906856AE", Kind="运输载具", Id="ID_P_VNAME_EHRHARDT", Name="运输载具 EV4 装甲车" },
        new() { Guid="87E38FC3-022D-4A88-80B5-6E3BD58C320F", Kind="运输载具", Id="ID_P_VNAME_TERNI", Name="运输载具 F.T. 装甲车" },
        new() { Guid="FA740EE6-6C1E-2F97-D48B-0EF8D1C7D11B", Kind="运输载具", Id="ID_P_VNAME_MAS15", Name="运输载具 M.A.S 鱼雷快艇" },
        new() { Guid="EA1C556F-DC5A-4764-BE8F-E661AF2B2C3B", Kind="运输载具", Id="ID_P_VNAME_YLIGHTER", Name="运输载具 Y-Lighter 登陆艇" },
        
        /////////////////////////////////////////////////////////////////////////////

        // 定点武器
        new() { Guid="E7825334-17D9-3BA1-D59C-8497155B8DBB", Kind="定点武器", Id="ID_P_VNAME_FIELDGUN", Name="定点武器 FK 96 野战炮" },
        new() { Guid="12689F49-C72C-6BFE-07E9-A26258C0FCA0", Kind="定点武器", Id="ID_P_VNAME_TURRET", Name="定点武器 堡垒火炮" },
        new() { Guid="2E5402EF-6303-B756-AEE9-E7926AB5FEF8", Kind="定点武器", Id="ID_P_VNAME_AASTATION", Name="定点武器 QF 1 防空炮" },
        new() { Guid="690ABB5C-7B7E-4609-B37A-2DB46C2F6287", Kind="定点武器", Id="ID_P_INAME_MAXIM", Name="定点武器 重型机枪" },
        //new() { Guid="A3C6FC16-2DF6-4719-9A5F-E079CDB928F3", Kind="定点武器", Id="ID_P_INAME_MAXIM", Name="定点武器 高爆机炮" },
        new() { Guid="EFB07B81-BBA3-413E-AF40-221CC104C21D", Kind="定点武器", Id="ID_P_VNAME_BL9", Name="定点武器 BL 9.2 攻城炮" },
        new() { Guid="B3BFBF74-6475-598C-C097-06DA0375F14A", Kind="定点武器", Id="ID_P_VNAME_COASTALBATTERY", Name="定点武器 350/52 o 岸防炮" },
        new() { Guid="6A1423D9-81B0-ECAB-7376-05AC2535DFDD", Kind="定点武器", Id="ID_P_VNAME_SK45GUN", Name="定点武器 SK45 岸防炮" },
        
        /////////////////////////////////////////////////////////////////////////////
        
        // 机械巨兽
        new() { Guid="1A7DEECF-4F0E-E343-9644-D6D91DCAEC12", Kind="机械巨兽", Id="ID_P_VNAME_ZEPPELIN", Name="机械巨兽 飞船 l30" },
        new() { Guid="A3ED808E-1525-412B-8E77-9EB6902A55D2", Kind="机械巨兽", Id="ID_P_VNAME_ARMOREDTRAIN", Name="机械巨兽 装甲列车" },
        new() { Guid="003FCC0A-2758-8508-4774-78E66FA1B5E3", Kind="机械巨兽", Id="ID_P_VNAME_IRONDUKE", Name="机械巨兽 无畏舰" },
        new() { Guid="BBFC5A91-B2FC-48D2-8913-658C08072E6E", Kind="机械巨兽", Id="ID_P_VNAME_CHAR", Name="机械巨兽 Char 2C" },
    ];
}