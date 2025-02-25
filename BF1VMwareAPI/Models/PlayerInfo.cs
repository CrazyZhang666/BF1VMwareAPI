namespace BF1VMwareAPI.Models;

public class PlayerInfo
{
    public int Index { get; set; }

    public byte Mark { get; set; }
    public int TeamId { get; set; }
    public bool IsSpectator { get; set; }
    public string Clan { get; set; }
    public string Name { get; set; }
    public long PersonaId { get; set; }

    public int SquadId { get; set; }
    public string SquadName { get; set; }

    public int Rank { get; set; }
    public int Kill { get; set; }
    public int Dead { get; set; }
    public int Score { get; set; }

    public string Kit { get; set; }
    public string KitName { get; set; }

    public byte PoseType { get; set; }
    public string PoseName { get; set; }

    public bool IsAlive { get; set; }
    public bool IsInVehicle { get; set; }

    public float AuthorativeYaw { get; set; }
    public float AuthorativePitch { get; set; }
    public Vector3 Location { get; set; }
    public Matrix4x4 Transform { get; set; }

    public float VehicleHealth { get; set; }
    public float Health { get; set; }

    public int ActiveSlot { get; set; }

    public WeaponInfo WeaponS0 { get; set; }
    public WeaponInfo WeaponS1 { get; set; }
    public WeaponInfo WeaponS2 { get; set; }
    public WeaponInfo WeaponS3 { get; set; }
    public WeaponInfo WeaponS4 { get; set; }
    public WeaponInfo WeaponS5 { get; set; }
    public WeaponInfo WeaponS6 { get; set; }
    public WeaponInfo WeaponS7 { get; set; }
}