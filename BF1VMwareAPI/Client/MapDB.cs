using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class MapDB
{
    /// <summary>
    /// 地图数据
    /// </summary>
    public readonly static List<MetaInfo> AllMapInfoDb =
    [
        new() { Id="Levels/FrontEnd/FrontEnd", Name="大厅" },
        new() { Id="Levels/MP/MP_Amiens/MP_Amiens", Name="亚眠" },
        new() { Id="Levels/MP/MP_Chateau/MP_Chateau", Name="流血宴厅" },
        new() { Id="Levels/MP/MP_Desert/MP_Desert", Name="西奈沙漠" },
        new() { Id="Levels/MP/MP_FaoFortress/MP_FaoFortress", Name="法欧堡" },
        new() { Id="Levels/MP/MP_Forest/MP_Forest", Name="阿尔贡森林" },
        new() { Id="Levels/MP/MP_ItalianCoast/MP_ItalianCoast", Name="帝国边境" },
        new() { Id="Levels/MP/MP_MountainFort/MP_MountainFort", Name="格拉巴山" },
        new() { Id="Levels/MP/MP_Scar/MP_Scar", Name="圣康坦的伤痕" },
        new() { Id="Levels/MP/MP_Suez/MP_Suez", Name="苏伊士" },
        new() { Id="Xpack0/Levels/MP/MP_Giant/MP_Giant", Name="庞然暗影" },
        new() { Id="Xpack1/Levels/MP_Fields/MP_Fields", Name="苏瓦松" },
        new() { Id="Xpack1/Levels/MP_Graveyard/MP_Graveyard", Name="决裂" },
        new() { Id="Xpack1/Levels/MP_Underworld/MP_Underworld", Name="法乌克斯要塞" },
        new() { Id="Xpack1/Levels/MP_Verdun/MP_Verdun", Name="凡尔登高地" },
        new() { Id="Xpack1-3/Levels/MP_ShovelTown/MP_ShovelTown", Name="攻占托尔" },
        new() { Id="Xpack1-3/Levels/MP_Trench/MP_Trench", Name="尼维尔之夜" },
        new() { Id="Xpack2/Levels/MP/MP_Bridge/MP_Bridge", Name="勃鲁希洛夫关口" },
        new() { Id="Xpack2/Levels/MP/MP_Islands/MP_Islands", Name="阿尔比恩" },
        new() { Id="Xpack2/Levels/MP/MP_Ravines/MP_Ravines", Name="武普库夫山口" },
        new() { Id="Xpack2/Levels/MP/MP_Tsaritsyn/MP_Tsaritsyn", Name="察里津" },
        new() { Id="Xpack2/Levels/MP/MP_Valley/MP_Valley", Name="加利西亚" },
        new() { Id="Xpack2/Levels/MP/MP_Volga/MP_Volga", Name="窝瓦河" },
        new() { Id="Xpack3/Levels/MP/MP_Beachhead/MP_Beachhead", Name="海丽丝岬" },
        new() { Id="Xpack3/Levels/MP/MP_Harbor/MP_Harbor", Name="泽布吕赫" },
        new() { Id="Xpack3/Levels/MP/MP_Naval/MP_Naval", Name="黑尔戈兰湾" },
        new() { Id="Xpack3/Levels/MP/MP_Ridge/MP_Ridge", Name="阿奇巴巴" },
        new() { Id="Xpack4/Levels/MP/MP_Alps/MP_Alps", Name="剃刀边缘" },
        new() { Id="Xpack4/Levels/MP/MP_Blitz/MP_Blitz", Name="伦敦的呼唤: 夜袭" },
        new() { Id="Xpack4/Levels/MP/MP_Hell/MP_Hell", Name="帕斯尚尔" },
        new() { Id="Xpack4/Levels/MP/MP_London/MP_London", Name="伦敦的呼唤: 灾祸" },
        new() { Id="Xpack4/Levels/MP/MP_Offensive/MP_Offensive", Name="索姆河" },
        new() { Id="Xpack4/Levels/MP/MP_River/MP_River", Name="卡波雷托" }
    ];
}