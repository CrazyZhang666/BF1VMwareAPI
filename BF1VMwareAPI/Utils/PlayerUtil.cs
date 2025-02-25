using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Utils;

public static class PlayerUtil
{
    /// <summary>
    /// 获取不同载具槽详情数据
    /// </summary>
    public static WeaponInfo GetPlayerVehicle(string vehicle, string kind)
    {
        var weaponInfo = ClientUtil.GetVehicleInfo(vehicle);
        if (weaponInfo is not null)
            return weaponInfo;

        return new WeaponInfo()
        {
            Kind = kind,
            Name = vehicle
        };
    }

    /// <summary>
    /// 获取不同载具槽详情数据
    /// </summary>
    public static WeaponInfo GetPlayerVehicle2(string vehicle, string kind)
    {
        return new WeaponInfo()
        {
            Kind = kind,
            Name = vehicle
        };
    }

    /// <summary>
    /// 获取不同武器槽详情数据
    /// </summary>
    public static WeaponInfo GetPlayerWeapon(string weapon, string kind)
    {
        var tempWeapon = weapon;

        if (weapon.Contains("_KBullet"))
            tempWeapon = "_KBullet";
        else if (weapon.Contains("_RGL_Frag"))
            tempWeapon = "_RGL_Frag";
        else if (weapon.Contains("_RGL_Smoke"))
            tempWeapon = "_RGL_Smoke";
        else if (weapon.Contains("_RGL_HE"))
            tempWeapon = "_RGL_HE";

        var weaponInfo = ClientUtil.GetWeaponInfo(tempWeapon);
        if (weaponInfo is not null)
        {
            return new WeaponInfo()
            {
                Guid = weaponInfo.Guid,
                Kind = kind,
                Id = weapon,
                Name = weaponInfo.Name
            };
        }

        return new WeaponInfo()
        {
            Kind = kind,
            Name = weapon
        };
    }
}