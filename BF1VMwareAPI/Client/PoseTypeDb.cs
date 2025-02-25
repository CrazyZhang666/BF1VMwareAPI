using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public class PoseTypeDb
{
    /// <summary>
    /// 姿态类型数据
    /// </summary>
    public readonly static List<MetaInfo> AllPoseTypeInfoDb =
    [
        new() { Id="0", Name="Stand" },
        new() { Id="1", Name="Crouch" },
        new() { Id="2", Name="Prone" }
    ];
}