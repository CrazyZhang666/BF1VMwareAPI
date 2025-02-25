using BF1VMwareAPI.Enums;
using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;
using BF1VMwareAPI.Utils;

namespace BF1VMwareAPI.Core;

public static class Player
{
    /// <summary>
    /// 服务器最大玩家数量
    /// </summary>
    private const int MaxPlayer = 70;

    /// <summary>
    /// 获取自己信息
    /// </summary>
    public static LocalPlayer GetLocalPlayer()
    {
        var pClientPlayer = Obfuscation.GetLocalPlayer();
        if (!Memory.IsValid(pClientPlayer))
            return null;

        return new LocalPlayer()
        {
            Clan = Memory.ReadString(pClientPlayer + 0x2151, 8),
            Name = Memory.ReadString(pClientPlayer + 0x0040, 64),
            PersonaId = Memory.Read<long>(pClientPlayer + 0x0038),
            IsSpectator = Memory.Read<byte>(pClientPlayer + 0x1C31) == 0x01
        };
    }

    /// <summary>
    /// 获取游戏内全部玩家列表信息
    /// </summary>
    public static List<PlayerInfo> GetAllPlayerList()
    {
        var _playerList = new List<PlayerInfo>();
        var _weaponSlot = new string[8] { "", "", "", "", "", "", "", "" };

        ////////////////////// 玩家数据 //////////////////////

        for (int i = 0; i < MaxPlayer; i++)
        {
            var pClientPlayer = Obfuscation.GetPlayerById(i);
            // 过滤无效数据
            if (!Memory.IsValid(pClientPlayer))
                continue;

            // 玩家数字Id
            var personaId = Memory.Read<long>(pClientPlayer + 0x0038);
            if (personaId is 0)
                continue;

            // 玩家标记，用于和得分板数据匹配（按照玩家进入服务器顺序）
            var mark = Memory.Read<byte>(pClientPlayer + 0x1D7C);
            // 玩家队伍Id，0/1/2
            var teamId = Memory.Read<int>(pClientPlayer + 0x1C34);
            // 是否为观战玩家，bool类型（0x01为观战，否则不是）
            var spectator = Memory.Read<byte>(pClientPlayer + 0x1C31);
            // 小队Id，枚举值
            var squadId = Memory.Read<int>(pClientPlayer + 0x1E50);
            // 玩家队标
            var clan = Memory.ReadString(pClientPlayer + 0x2151, 8);
            // 玩家名称
            var name = Memory.ReadString(pClientPlayer + 0x0040, 64);

            // 玩家兵种
            var offset = Memory.Read<long>(pClientPlayer + 0x11A8);
            var kit = Memory.ReadString(Memory.Read<long>(offset + 0x0028), 64);

            // 清空武器槽
            for (int j = 0; j < 8; j++)
                _weaponSlot[j] = string.Empty;

            // 载具实体指针
            var pClientVehicleEntity = Memory.Read<long>(pClientPlayer + 0x1D38);
            // 玩家实体指针
            var pClientSoldierEntity = Memory.Read<long>(pClientPlayer + 0x1D48);

            // 当玩家进入载具后，pClientVehicleEntity与pClientSoldierEntity相同
            var isInVehicle = Memory.IsValid(pClientVehicleEntity) && Memory.IsValid(pClientSoldierEntity);
            // 玩家是否存活
            var isAlive = true;

            // 玩家角度
            var authorativeYaw = 0.0f;
            // 玩家角度2
            var authorativePitch = 0.0f;
            // 玩家姿态
            var poseType = (byte)0x00;
            // 玩家坐标
            var location = new Vector3();
            // 玩家Transform
            var transform = new Matrix4x4();

            // 载具生命值
            var vehicleHealth = 0.0f;
            // 玩家生命值
            var health = 0.0f;

            // 当前激活的武器索引
            var activeSlot = -1;

            // 玩家进入载具
            if (isInVehicle)
            {
                // 判断载具生命值指针是否有效
                var pVehicleHealthComponent = Memory.Read<long>(pClientVehicleEntity + 0x01D0);
                if (!Memory.IsValid(pVehicleHealthComponent))
                {
                    isAlive = false;
                    goto NO_WEAPON;
                }

                vehicleHealth = Memory.Read<float>(pVehicleHealthComponent + 0x0040);
                // 判断载具是否死亡
                if (vehicleHealth <= 0)
                {
                    isAlive = false;
                    goto NO_WEAPON;
                }

                //////////////////////////////////////////////////////////

                // 玩家载具坐标
                var m_collection = Memory.Read<long>(pClientVehicleEntity + 0x38);
                var _9 = Memory.Read<byte>(m_collection + 0x09);
                var _10 = Memory.Read<byte>(m_collection + 0x0A);
                var componentCollectionOffset = 0x20 * (_10 + (0x02 * _9));

                transform = Memory.Read<Matrix4x4>(m_collection + componentCollectionOffset + 0x10);
                if (Math.Abs(transform.M11 + transform.M12 + transform.M13) > 3.0f)
                {
                    location.X = transform.M11;
                    location.Y = transform.M12;
                    location.Z = transform.M13;

                }
                else if (Math.Abs(transform.M21 + transform.M22 + transform.M23) > 3.0f)
                {
                    location.X = transform.M21;
                    location.Y = transform.M22;
                    location.Z = transform.M23;
                }
                else if (Math.Abs(transform.M31 + transform.M32 + transform.M33) > 3.0f)
                {
                    location.X = transform.M31;
                    location.Y = transform.M32;
                    location.Z = transform.M33;
                }
                else if (Math.Abs(transform.M41 + transform.M42 + transform.M43) > 3.0f)
                {
                    location.X = transform.M41;
                    location.Y = transform.M42;
                    location.Z = transform.M43;
                }

                //////////////////////////////////////////////////////////

                // 载具实体数据指针
                var pVehicleEntityData = Memory.Read<long>(pClientVehicleEntity + 0x0030);
                // 读取载具名称
                _weaponSlot[0] = Memory.ReadString(Memory.Read<long>(pVehicleEntityData + 0x02F8), 64);

                // 载具具体名称（弱指针，不稳定）
                for (int count = 0; count < 100; count++)
                {
                    var tempMultiUnlockAsset = Memory.Read<long>(pClientPlayer + 0x13A8 + count * 0x08);
                    if (!Memory.IsValid(tempMultiUnlockAsset))
                        continue;

                    var vtable = Memory.Read<long>(tempMultiUnlockAsset);
                    if (vtable == 0x142B8E188)
                    {
                        var tempVehicleName = Memory.ReadString(Memory.Read<long>(tempMultiUnlockAsset + 0x20), 64);
                        if (GameUtil.FixVehicleKits(_weaponSlot[0], tempVehicleName))
                        {
                            _weaponSlot[1] = tempVehicleName;
                            break;
                        }
                    }
                }

                //////////////////////////////////////////////////////////

                // SoldierWeaponsComponent
                // ComponentTable
                // 载具武器组件数量
                var componentCount = Memory.Read<byte>(pClientVehicleEntity + 0x570 + 0x09);
                // 临时存放载具武器名称
                var componentNames = new List<string>();
                for (var count = 0; count < componentCount; count++)
                {
                    var componentOffset = pClientVehicleEntity + 0x570 + count * 0x20;

                    // 用来过滤未激活的载具武器
                    var activeFlag = Memory.Read<short>(componentOffset - 0x08);
                    if (activeFlag != 2056)
                        continue;

                    // ComponentTulpe
                    var pWeaponComponent = Memory.Read<long>(componentOffset);
                    if (!Memory.IsValid(pWeaponComponent))
                        continue;

                    // ClientAimRotationBoneComponent* m_ClientAimRotationBoneComponent; // 0x0010
                    var pWeaponComponentData = Memory.Read<long>(pWeaponComponent + 0x10);
                    if (!Memory.IsValid(pWeaponComponentData))
                        continue;
                    var pComponentName = Memory.Read<long>(pWeaponComponentData + 0x120);
                    if (!Memory.IsValid(pComponentName))
                        continue;

                    var weaponName = Memory.ReadString(pComponentName, 64);
                    if (!string.IsNullOrWhiteSpace(weaponName))
                        componentNames.Add(weaponName);
                }

                _weaponSlot[2] = string.Join(", ", componentNames);
            }
            else
            {
                // 判断客户端玩家实体指针是否有效
                if (!Memory.IsValid(pClientSoldierEntity))
                {
                    isAlive = false;
                    goto NO_WEAPON;
                }

                // 判断玩家生命值指针是否有效
                var pSoldierHealthComponent = Memory.Read<long>(pClientSoldierEntity + 0x1D0);
                if (!Memory.IsValid(pSoldierHealthComponent))
                {
                    isAlive = false;
                    goto NO_WEAPON;
                }

                // 判断玩家是否死亡
                health = Memory.Read<float>(pSoldierHealthComponent + 0x40);
                if (health <= 0)
                {
                    isAlive = false;
                    goto NO_WEAPON;
                }

                //////////////////////////////////////////////////////////

                // 玩家角度
                authorativeYaw = Memory.Read<float>(pClientSoldierEntity + 0x0604);
                // 玩家角度2
                authorativePitch = Memory.Read<float>(pClientSoldierEntity + 0x0634);
                // 玩家姿态
                poseType = Memory.Read<byte>(pClientSoldierEntity + 0x0638);
                // 玩家坐标
                location = Memory.Read<Vector3>(pClientSoldierEntity + 0x0990);
                // 玩家Transform
                transform = Memory.Read<Matrix4x4>(pClientSoldierEntity + 0x0960);

                // 获取玩家武器组件
                var pClientSoldierWeaponComponent = Memory.Read<long>(pClientSoldierEntity + 0x698);
                var m_handler = Memory.Read<long>(pClientSoldierWeaponComponent + 0x8A8);

                // 当前激活的武器索引
                activeSlot = Memory.Read<int>(pClientSoldierWeaponComponent + 0x950);

                // 获取玩家不同武器槽位的武器名称
                for (int solt = 0; solt < 8; solt++)
                {
                    // m_handler + m_activeSlot * 0x8 = ClientSoldierWeapon
                    var pClientSoldierWeapon = Memory.Read<long>(m_handler + solt * 0x8);
                    // ClientWeapon* m_pWeapon; //0x4A30 [ClientWeapon]
                    var pClientWeapon = Memory.Read<long>(pClientSoldierWeapon + 0x4A30);
                    // WeaponModifier* m_pWeaponModifier; //0x0020
                    var pWeaponModifier = Memory.Read<long>(pClientWeapon + 0x20);
                    // UnlockAssetBase* m_pSoldierWeaponUnlockAsset; //0x0038 [SoldierWeaponUnlockAsset]
                    var pSoldierWeaponUnlockAsset = Memory.Read<long>(pWeaponModifier + 0x38);
                    // const char* m_DebugUnlockId; // 0x20
                    var m_DebugUnlockId = Memory.Read<long>(pSoldierWeaponUnlockAsset + 0x20);
                    _weaponSlot[solt] = Memory.ReadString(m_DebugUnlockId, 64);
                }
            }

        NO_WEAPON:
            // 玩家死亡后，兵种信息不会清除，这里要手动清除
            if (!isAlive)
                kit = string.Empty;

            // 过滤重复玩家，并填充数据
            var index = _playerList.FindIndex(val => val.PersonaId == personaId);
            if (index == -1)
            {
                var player = new PlayerInfo()
                {
                    Mark = mark,
                    TeamId = teamId,
                    IsSpectator = GameUtil.IsSpectator(spectator),
                    Clan = clan,
                    Name = name,
                    PersonaId = personaId,
                    SquadId = squadId,
                    SquadName = ClientUtil.GetSquadName(squadId),
                    Kit = kit,
                    KitName = ClientUtil.GetPlayerKitName(kit),

                    IsAlive = isAlive,
                    IsInVehicle = isInVehicle,

                    AuthorativeYaw = authorativeYaw,
                    AuthorativePitch = authorativePitch,
                    PoseType = poseType,
                    PoseName = ClientUtil.GetPlayerPoseTypeName(poseType),

                    Location = location,
                    Transform = transform,

                    VehicleHealth = vehicleHealth,
                    Health = health,

                    ActiveSlot = activeSlot
                };

                if (isAlive && player.IsInVehicle)
                {
                    // 0 载具类型
                    player.WeaponS0 = PlayerUtil.GetPlayerVehicle(_weaponSlot[0], "载具类型");
                    // 1 载具名称
                    player.WeaponS1 = PlayerUtil.GetPlayerVehicle(_weaponSlot[1], "载具名称（不稳定）");
                    // 2 载具武器
                    player.WeaponS2 = PlayerUtil.GetPlayerVehicle2(_weaponSlot[2], "载具武器（不稳定）");
                }
                else if (isAlive)
                {
                    // 0 主要武器
                    player.WeaponS0 = PlayerUtil.GetPlayerWeapon(_weaponSlot[0], "主要武器");
                    // 1 配枪
                    player.WeaponS1 = PlayerUtil.GetPlayerWeapon(_weaponSlot[1], "配枪");
                    // 2 配备一
                    player.WeaponS2 = PlayerUtil.GetPlayerWeapon(_weaponSlot[2], "配备一");
                    // 3 特殊
                    player.WeaponS3 = PlayerUtil.GetPlayerWeapon(_weaponSlot[3], "特殊");
                    // 4 V键
                    player.WeaponS4 = PlayerUtil.GetPlayerWeapon(_weaponSlot[4], "V键");
                    // 5 配备二
                    player.WeaponS5 = PlayerUtil.GetPlayerWeapon(_weaponSlot[5], "配备二");
                    // 6 手榴弹
                    player.WeaponS6 = PlayerUtil.GetPlayerWeapon(_weaponSlot[6], "手榴弹");
                    // 7 近战
                    player.WeaponS7 = PlayerUtil.GetPlayerWeapon(_weaponSlot[7], "近战");
                }

                _playerList.Add(player);
            }
        }

        ////////////////////// 得分板数据 //////////////////////

        // 获取得分板指针（链表）
        var pClientScoreboard = Memory.Read<long>(Offsets.SCOREBOARD);
        pClientScoreboard = Memory.Read<long>(pClientScoreboard + 0x68);

        for (int i = 0; i < MaxPlayer; i++)
        {
            pClientScoreboard = Memory.Read<long>(pClientScoreboard);
            var pScoreboardOffset = Memory.Read<long>(pClientScoreboard + 0x10);
            if (!Memory.IsValid(pScoreboardOffset))
                continue;

            // 获取得分板数据
            var mark = Memory.Read<byte>(pScoreboardOffset + 0x300);
            var rank = Memory.Read<int>(pScoreboardOffset + 0x304);
            var kill = Memory.Read<int>(pScoreboardOffset + 0x308);
            var dead = Memory.Read<int>(pScoreboardOffset + 0x30C);
            var score = Memory.Read<int>(pScoreboardOffset + 0x314);

            // 填充得分板数据
            var player = _playerList.Find(val => val.Mark == mark);
            if (player is not null)
            {
                player.Rank = rank;
                player.Kill = kill;
                player.Dead = dead;
                player.Score = score;
            }
        }

        return _playerList;
    }

    /// <summary>
    /// 获取战地1当前进入服务器队伍0/1/2中玩家数据，已按照得分顺序排序
    /// </summary>
    public static List<PlayerInfo> GetTeamPlayerList(TeamId teamId)
    {
        var teamList = new List<PlayerInfo>();

        var clientPlayers = GetAllPlayerList();
        if (clientPlayers.Count == 0)
            return teamList;

        foreach (var item in clientPlayers)
        {
            if (item.TeamId != (int)teamId)
                continue;

            teamList.Add(item);
        }

        if (teamList.Count == 0)
            return teamList;

        if (teamId != TeamId.TeamNeutral)
            teamList.Sort((a, b) => b.Score.CompareTo(a.Score));

        for (var i = 0; i < teamList.Count; i++)
            teamList[i].Index = i + 1;

        return teamList;
    }
}