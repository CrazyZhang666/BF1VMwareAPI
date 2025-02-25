using BF1VMwareAPI.Models;

namespace BF1VMwareAPI.Client;

public static class WeaponDB
{
    /// <summary>
    /// 全部武器信息
    /// </summary>
    public readonly static List<WeaponInfo> AllWeaponInfoDb =
    [
        ////////////////////////////////// 公用配枪 //////////////////////////////////

        new() { Guid="3CE86D7C-9951-4B25-9FD6-A97CA94F4A20", Kind="公用配枪", Id="U_M1911", Name="M1911" },
        new() { Guid="009736C2-B237-49AE-9DD1-E77AF7771FF2", Kind="公用配枪", Id="U_LugerP08", Name="P08 手枪" },
        new() { Guid="A666D907-0F72-4641-B43A-6AA756FFBC03", Kind="公用配枪", Id="U_FN1903", Name="Mle 1903" },
        new() { Guid="4DD1FAD2-1CF1-496C-BE29-BDAEBC931D74", Kind="公用配枪", Id="U_BorchardtC93", Name="C93" },
        new() { Guid="87643E53-CD17-FFC4-167B-AA72301A323A", Kind="公用配枪", Id="U_SmithWesson", Name="3 号左轮手枪" },
        new() { Guid="33F9105C-40C7-3980-7982-ADD4B9F6311A", Kind="公用配枪", Id="U_Kolibri", Name="Kolibri" },
        new() { Guid="64503392-4DDF-435D-8ABA-22730383E073", Kind="公用配枪", Id="U_NagantM1895", Name="纳甘左轮手枪" },
        new() { Guid="84AF0AF5-D981-48BE-8665-CC24A278DA6E", Kind="公用配枪", Id="U_Obrez", Name="Obrez 手枪" },
        new() { Guid="8680EFC0-CA02-43E0-8CA2-591FB279DD95", Kind="公用配枪", Id="U_Webley_Mk6", Name="Mk VI 左轮手枪" },
        new() { Guid="AF3F421B-F68B-401D-94B4-B982EE6C8A91", Kind="公用配枪", Id="U_M1911_Preorder_Hellfighter", Name="地狱战士 M1911" },
        new() { Guid="B97A8C29-A567-437F-9B6C-9E1E8FD86BF9", Kind="公用配枪", Id="U_LugerP08_Wep_Preorder", Name="红男爵的 P08" },
        new() { Guid="5962340E-AED8-4B93-A10E-D7C91FFD2460", Kind="公用配枪", Id="U_M1911_Suppressed", Name="M1911（消音器）" },
        new() { Guid="B9333E7C-3D7D-4147-A569-9FC9BB2B4F5D", Kind="公用配枪", Id="U_SingleActionArmy", Name="维和左轮 Peacekeeper" },
        new() { Guid="F7CED576-7629-402A-8598-4A4998C02E0A", Kind="公用配枪", Id="U_M1911_Preorder_Triforce", Name="步兵小子 M1911" },
        
        ////////////////////////////////// 公用手榴弹 //////////////////////////////////
   
        new() { Guid="F0B75644-5B3F-45CD-9E42-9B67F3D4D37F", Kind="手榴弹", Id="U_GermanStick", Name="破片手榴弹" },
        new() { Guid="F0B75644-5B3F-45CD-9E42-9B67F3D4D37F", Kind="手榴弹", Id="U_FragGrenade", Name="棒式手榴弹" },
        new() { Guid="EE6AC80E-FFDF-4E5A-923D-209CE9B86BF4", Kind="手榴弹", Id="U_GasGrenade", Name="毒气手榴弹" },
        new() { Guid="F9A8C36F-F5B6-4946-B3B9-F5923564CD51", Kind="手榴弹", Id="U_ImpactGrenade", Name="冲击手榴弹" },
        new() { Guid="8219207A-41E6-4ED2-A3E8-9690752EC40C", Kind="手榴弹", Id="U_Incendiary", Name="燃烧手榴弹" },
        new() { Guid="67B5683D-D897-4881-BB86-DACB9947264E", Kind="手榴弹", Id="U_MiniGrenade", Name="小型手榴弹" },
        new() { Guid="04CDC06B-F4B6-4696-BE9C-08E1D0D36347", Kind="手榴弹", Id="U_SmokeGrenade", Name="烟雾手榴弹" },
        new() { Guid="D4A99456-2ABA-4376-9870-200FD24C5D45", Kind="手榴弹", Id="U_Grenade_AT", Name="轻型反坦克手榴弹" },
        new() { Guid="55D01566-4322-4EAE-AD13-9DDAF2C2F399", Kind="手榴弹", Id="U_ImprovisedGrenade", Name="土制手榴弹" },
        new() { Guid="DD1BBA84-A6AB-4A66-986F-2B2556F6E7B1", Kind="手榴弹", Id="U_RussianBox", Name="俄罗斯标准手榴弹" },

        ////////////////////////////////// 突击兵 Assault //////////////////////////////////

        // 突击兵 主要武器
        new() { Guid="16D7C222-5ACA-4728-854D-6282E44846DC", Kind="突击兵 主要武器", Id="U_RemingtonM10_Wep_Slug", Name="Model 10-A（霰弹块）" },
        new() { Guid="508E534A-A7A5-41A1-8F8F-FEDFA0AFDA93", Kind="突击兵 主要武器", Id="U_RemingtonM10_Wep_Choke", Name="Model 10-A（猎人）" },
        new() { Guid="ED262207-65C8-46E1-B5D4-D7468143790F", Kind="突击兵 主要武器", Id="U_RemingtonM10", Name="Model 10-A（原厂）" },
        new() { Guid="9F97B37E-2A81-4AE3-A96A-4402B30BF184", Kind="突击兵 主要武器", Id="U_Winchester1897_Wep_Sweeper", Name="M97 战壕枪（扫荡）" },
        new() { Guid="EA7C6CF1-5801-4C52-8685-51B4C7B90CE9", Kind="突击兵 主要武器", Id="U_Winchester1897_Wep_LowRecoil", Name="M97 战壕枪（Back-Bored）" },
        new() { Guid="20D21E3D-BA5F-4239-8F90-42FCDDA12F51", Kind="突击兵 主要武器", Id="U_Winchester1897_Wep_Choke", Name="M97 战壕枪（猎人）" },
        new() { Guid="ADA8C89D-F213-401C-806C-B60483E2EEE7", Kind="突击兵 主要武器", Id="U_MP18_Wep_Trench", Name="MP 18（壕沟战）" },
        new() { Guid="A498D568-2F50-449C-BA5D-6864AB34F8D2", Kind="突击兵 主要武器", Id="U_MP18_Wep_Burst", Name="MP 18（实验）" },
        new() { Guid="765A6856-3A80-4196-8DB6-14A95B94AB85", Kind="突击兵 主要武器", Id="U_MP18_Wep_Accuracy", Name="MP 18（瞄准镜）" },
        new() { Guid="58E00507-4123-49D9-A9DE-0F5C7A267CC4", Kind="突击兵 主要武器", Id="U_BerettaM1918_Wep_Trench", Name="M1918 自动冲锋枪（壕沟战）" },
        new() { Guid="29539D1A-A492-4398-BABF-6BC8DBD4BECA", Kind="突击兵 主要武器", Id="U_BerettaM1918_Wep_Stability", Name="M1918 自动冲锋枪（冲锋）" },
        new() { Guid="2439B810-3ACD-4069-B1E9-0CDC2CE51985", Kind="突击兵 主要武器", Id="U_BerettaM1918", Name="M1918 自动冲锋枪（原厂）" },
        new() { Guid="FA78AFDF-D06D-4CBE-B325-945F9B4091C3", Kind="突击兵 主要武器", Id="U_BrowningA5_Wep_LowRecoil", Name="12g 自动霰弹枪（Back-Bored）" },
        new() { Guid="31D6D032-5B6F-4494-A04A-0FB8EDB130BB", Kind="突击兵 主要武器", Id="U_BrowningA5_Wep_Choke", Name="12g 自动霰弹枪（猎人）" },
        new() { Guid="D7A0DED9-EC54-4523-9294-656FA1881FE9", Kind="突击兵 主要武器", Id="U_BrowningA5_Wep_ExtensionTube", Name="12g 自动霰弹枪（加长）" },
        new() { Guid="2B253855-7BA0-4FF6-9F25-57D53B15FE32", Kind="突击兵 主要武器", Id="U_Hellriegel1915", Name="Hellriegel 1915（原厂）" },
        new() { Guid="B1E5A3BC-3D24-4FE5-84D1-4523D6DCE545", Kind="突击兵 主要武器", Id="U_Hellriegel1915_Wep_Accuracy", Name="Hellriegel 1915（防御）" },
        new() { Guid="8F241031-A76D-436B-AE5F-CD797B504A7A", Kind="突击兵 主要武器", Id="U_Winchester1897_Wep_Preorder", Name="地狱战士战壕霰弹枪" },
        new() { Guid="5D89166E-58E1-46FD-B854-69641E9DCEF7", Kind="突击兵 主要武器", Id="U_SjogrenShotgun", Name="Sj?gren Inertial（原厂）" },
        new() { Guid="42B442BF-6ACE-4592-A53B-96424B4ACABF", Kind="突击兵 主要武器", Id="U_SjogrenShotgun_Wep_Slug", Name="Sj?gren Inertial（霰弹块）" },
        new() { Guid="6B07DE60-5568-43C0-B1F6-D51A13A9BD3C", Kind="突击兵 主要武器", Id="U_Ribeyrolles", Name="利贝罗勒 1918（原厂）" },
        new() { Guid="C4B84F0E-D7FF-49D9-9796-E6CF95C058BD", Kind="突击兵 主要武器", Id="U_Ribeyrolles_Wep_Optical", Name="Ribeyrolles 1918（瞄准镜）" },
        new() { Guid="CCA1F8F7-5658-4DCA-BAA8-2C930C2EF5F0", Kind="突击兵 主要武器", Id="U_RemingtonModel1900", Name="Model 1900（原厂）" },
        new() { Guid="55381B1D-7E17-44BE-AC0B-33542A64BF96", Kind="突击兵 主要武器", Id="U_RemingtonModel1900_Wep_Slug", Name="Model 1900（霰弹块）" },
        new() { Guid="C4F8BC18-1908-4A83-ABB6-B812C05D49CE", Kind="突击兵 主要武器", Id="U_MaximSMG", Name="SMG 08/18（原厂）" },
        new() { Guid="DEC97287-AF0B-49E4-8FD8-CBC5FB5AF497", Kind="突击兵 主要武器", Id="U_MaximSMG_Wep_Accuracy", Name="SMG 08/18（瞄准镜）" },
        new() { Guid="E1297C9B-861A-4170-840B-83AC64A0C574", Kind="突击兵 主要武器", Id="U_SteyrM1912_P16", Name="M1912/P.16（冲锋）" },
        new() { Guid="39137F1F-B794-4265-BB30-490E1E182F81", Kind="突击兵 主要武器", Id="U_SteyrM1912_P16_Wep_Burst", Name="Maschinenpistole M1912/P.16（实验）" },
        new() { Guid="1C5B531F-26B4-429F-839B-99252610A7F0", Kind="突击兵 主要武器", Id="U_Mauser1917Trench", Name="M1917 战壕卡宾枪" },
        new() { Guid="245A23B1-53BA-4AB2-A416-224794F15FCB", Kind="突击兵 主要武器", Id="U_Mauser1917Trench_Wep_Scope", Name="M1917 卡宾枪（巡逻）" },
        new() { Guid="6C3EE48B-0974-48B1-AFF7-96FD4D684E82", Kind="突击兵 主要武器", Id="U_ChauchatSMG", Name="RSC 冲锋枪（原厂）" },
        new() { Guid="6DAFDE21-2502-41B4-878B-532E70905238", Kind="突击兵 主要武器", Id="U_ChauchatSMG_Wep_Optical", Name="RSC 冲锋枪（瞄准镜）" },
        new() { Guid="C70FE9E0-0A1C-470C-B377-68059953EAD8", Kind="突击兵 主要武器", Id="U_M1919Thompson_Wep_Trench", Name="Annihilator（壕沟）" },
        new() { Guid="DBC25B43-29D9-4FB4-B9EF-C4966CD773B3", Kind="突击兵 主要武器", Id="U_M1919Thompson_Wep_Stability", Name="Annihilator（冲锋）" },
        new() { Guid="A9985C95-7364-4AE3-BC77-C53651128EBE", Kind="突击兵 主要武器", Id="U_M1919Thompson", Name="M1919 冲锋枪" },
        new() { Guid="D8AEB334-58E2-4A52-83BA-F3C2107196F0", Kind="突击兵 主要武器", Id="U_FrommerStopAuto", Name="费罗梅尔停止手枪（自动）" },
        new() { Guid="7085A5B9-6A77-4766-83CD-3666DA3EDF28", Kind="突击兵 主要武器", Id="U_SawnOffShotgun", Name="短管霰弹枪" },

        // 突击兵 配枪
        new() { Guid="F5F1FAA5-1791-441F-BDB5-82F9A4D14BAF", Kind="突击兵 配枪", Id="U_GasserM1870", Name="加塞 M1870" },
        new() { Guid="25B28666-332D-4FCB-AD68-18184AD37702", Kind="突击兵 配枪", Id="U_LancasterHowdah", Name="Howdah 手枪" },
        new() { Guid="E0C46F74-92CF-0C0C-E475-806B37E14706", Kind="突击兵 配枪", Id="U_Hammerless", Name="1903 Hammerless" },

        // 突击兵 配备一二
        new() { Guid="079D8793-073C-4332-A959-19C74A9D2A46", Kind="突击兵 配备一二", Id="U_Dynamite", Name="炸药" },
        new() { Guid="72CCBF3E-C0FE-4657-A1A7-EACDB2D11985", Kind="突击兵 配备一二", Id="U_ATGrenade", Name="反坦克手榴弹" },
        new() { Guid="6DFD1536-BBBB-4528-917A-7E2821FB4B6B", Kind="突击兵 配备一二", Id="U_ATMine", Name="反坦克地雷" },
        new() { Guid="BE041F1A-460B-4FD5-9E4B-F1C803C0F42F", Kind="突击兵 配备一二", Id="U_BreechGun", Name="反坦克火箭炮" },
        new() { Guid="AE96B513-1F05-4E63-A273-E98FA91EE4D0", Kind="突击兵 配备一二", Id="U_BreechGun_Flak", Name="防空火箭炮" },

        ////////////////////////////////// 医疗兵 Medic //////////////////////////////////

        // 医疗兵 主要武器
        new() { Guid="DE3E0902-9C36-4CFA-B872-49282591F11C", Kind="医疗兵 主要武器", Id="U_CeiRigottiM1895_Wep_Trench", Name="Cei-Rigotti（壕沟战）" },
        new() { Guid="D71DA743-8F97-430B-A794-50F7974C28EC", Kind="医疗兵 主要武器", Id="U_CeiRigottiM1895_Wep_Range", Name="Cei-Rigotti（瞄准镜）" },
        new() { Guid="12EE7056-0D58-4570-ADA6-06D9062DE408", Kind="医疗兵 主要武器", Id="U_CeiRigottiM1895", Name="Cei-Rigotti（原厂）" },
        new() { Guid="EDF7E9DB-5847-4E21-9EF0-C1E01ED80D8B", Kind="医疗兵 主要武器", Id="U_MauserSL1916_Wep_Scope", Name="Selbstlader M1916（神射手）" },
        new() { Guid="88336091-0676-4B12-BA91-810C25ED67C4", Kind="医疗兵 主要武器", Id="U_MauserSL1916_Wep_Range", Name="Selbstlader M1916（瞄准镜）" },
        new() { Guid="3DCA71EC-EBCC-464C-B3CD-7251372FC0AD", Kind="医疗兵 主要武器", Id="U_MauserSL1916", Name="Selbstlader M1916（原厂）" },
        new() { Guid="2DFEF12D-7110-47F9-9185-78A081BDE76A", Kind="医疗兵 主要武器", Id="U_WinchesterM1907_Wep_Trench", Name="M1907 半自动步枪（壕沟战）" },
        new() { Guid="A9507FBD-8B45-49E6-803C-53A5D5EE0406", Kind="医疗兵 主要武器", Id="U_WinchesterM1907_Wep_Auto", Name="M1907 半自动步枪（扫荡）" },
        new() { Guid="DD36E432-B119-4D0F-95A1-541493BF7EE6", Kind="医疗兵 主要武器", Id="U_WinchesterM1907", Name="M1907 半自动步枪（原厂）" },
        new() { Guid="08AD9E6C-D453-48F4-BDE5-CF84652A12F0", Kind="医疗兵 主要武器", Id="U_Mondragon_Wep_Range", Name="蒙德拉贡步枪（瞄准镜）" },
        new() { Guid="EDECA6B4-795F-45B2-BD3F-967E96D40C7D", Kind="医疗兵 主要武器", Id="U_Mondragon_Wep_Stability", Name="蒙德拉贡步枪（冲锋）" },
        new() { Guid="BEB31317-EBBF-45FB-A102-0E115DAA5551", Kind="医疗兵 主要武器", Id="U_Mondragon_Wep_Bipod", Name="蒙德拉贡步枪（狙击手）" },
        new() { Guid="1F42E46E-603B-4325-AA42-31B86210D47C", Kind="医疗兵 主要武器", Id="U_RemingtonModel8", Name="自动装填步枪 8.35（原厂）" },
        new() { Guid="2066B449-91C9-4B9C-8C4C-40F5B9F0A58E", Kind="医疗兵 主要武器", Id="U_RemingtonModel8_Wep_Scope", Name="自动装填步枪 8.35（神射手）" },
        new() { Guid="9E7BE0C2-E44D-4B4F-99A7-B05D4451D254", Kind="医疗兵 主要武器", Id="U_RemingtonModel8_Wep_ExtendedMag", Name="自动装填步枪 8.25（加长）" },
        new() { Guid="47BEB21C-2CD6-4ED0-8253-33F8F980EB94", Kind="医疗兵 主要武器", Id="U_Luger1906", Name="Selbstlader 1906（原厂）" },
        new() { Guid="5B483B03-DD23-4E38-83C7-CD841A6E9927", Kind="医疗兵 主要武器", Id="U_Luger1906_Wep_Scope", Name="Selbstlader 1906（狙击手）" },
        new() { Guid="F73F9323-CD36-41F6-BFB7-3A2244342E70", Kind="医疗兵 主要武器", Id="U_RSC1917_Wep_Range", Name="RSC 1917（瞄准镜）" },
        new() { Guid="0051C834-6CF9-4CFB-BFBA-E54AF000A9E5", Kind="医疗兵 主要武器", Id="U_RSC1917", Name="RSC 1917（原厂）" },
        new() { Guid="207B1E7D-B45A-4622-B482-7CAE22C1539F", Kind="医疗兵 主要武器", Id="U_FedorovAvtomat_Wep_Trench", Name="费德洛夫自动步枪（壕沟战）" },
        new() { Guid="9E799054-23D4-4525-B777-6A30E99DA964", Kind="医疗兵 主要武器", Id="U_FedorovAvtomat_Wep_Range", Name="费德洛夫自动步枪（瞄准镜）" },
        new() { Guid="652BC7DF-9F78-4D93-BF96-2B6F9B6CE75C", Kind="医疗兵 主要武器", Id="U_GeneralLiuRifle", Name="刘将军步枪（原厂）" },
        new() { Guid="52208E58-292B-4B03-90C7-B620C9F582C9", Kind="医疗兵 主要武器", Id="U_GeneralLiuRifle_Wep_Stability", Name="刘将军步枪（冲锋）" },
        new() { Guid="71A33B25-58E3-4F65-90EB-F69042978D99", Kind="医疗兵 主要武器", Id="U_FarquharHill_Wep_Range", Name="Farquhar-Hill 步枪（瞄准镜）" },
        new() { Guid="53884B2B-4DEF-4A02-BEEE-0E7B6D39205E", Kind="医疗兵 主要武器", Id="U_FarquharHill_Wep_Stability", Name="Farquhar-Hill 步枪（冲锋）" },
        new() { Guid="11A0CC2F-9DE9-42FC-B528-91822B760819", Kind="医疗兵 主要武器", Id="U_BSAHowellM1916", Name="Howell 自动步枪（原厂）" },
        new() { Guid="8DFC892E-00AE-47EC-A1D3-B866D40EE587", Kind="医疗兵 主要武器", Id="U_BSAHowellM1916_Wep_Scope", Name="Howell 自动步枪（狙击手）" },
        new() { Guid="4CFA2055-EB98-48E6-9BD9-70AAE7AF04AE", Kind="医疗兵 主要武器", Id="U_FedorovDegtyarev", Name="费德洛夫 Degtyarev" },

        // 医疗兵 配枪
        new() { Guid="447B3866-1241-42D7-8AB2-384727CFE624", Kind="医疗兵 配枪", Id="U_WebFosAutoRev_455Webley", Name="自动左轮手枪" },
        new() { Guid="169D5DA6-8DB5-48B3-8101-DB208C4BB4DD", Kind="医疗兵 配枪", Id="U_MauserC96", Name="C96" },
        new() { Guid="8373B804-511A-AB86-256D-9CE36CE25BA5", Kind="医疗兵 配枪", Id="U_Mauser1914", Name="Taschenpistole M1914" },

        // 医疗兵 配备一二
        new() { Guid="EBA4454E-EEB6-4AF1-9286-BD841E297ED4", Kind="医疗兵 配备一二", Id="U_Syringe", Name="医疗用针筒" },
        new() { Guid="670F817E-89A6-4048-B8B2-D9997DD97982", Kind="医疗兵 配备一二", Id="U_MedicBag", Name="医护箱" },
        new() { Guid="9BCDB1F5-5E1C-4C3E-824C-8C05CC0CE21A", Kind="医疗兵 配备一二", Id="U_Bandages", Name="绷带包" },
        new() { Guid="F34B3039-7B3A-0272-14E7-628980A60F06", Kind="医疗兵 配备一二", Id="_RGL_Frag", Name="步枪手榴弹（破片）" },
        new() { Guid="03FDF635-8E98-4F74-A176-DB4960304DF5", Kind="医疗兵 配备一二", Id="_RGL_Smoke", Name="步枪手榴弹（烟雾）" },
        new() { Guid="165ED044-C2C5-43A1-BE04-8618FA5072D4", Kind="医疗兵 配备一二", Id="_RGL_HE", Name="步枪手榴弹（高爆）" },

        ////////////////////////////////// 支援兵 Support //////////////////////////////////

        // 支援兵 主要武器
        new() { Guid="B524273C-77FD-433E-8A40-270C00A4AE67", Kind="支援兵 主要武器", Id="U_LewisMG_Wep_Suppression", Name="路易士机枪（压制）" },
        new() { Guid="CCE43311-3362-4D84-91D0-6A3D83B9BA17", Kind="支援兵 主要武器", Id="U_LewisMG_Wep_Range", Name="路易士机枪（瞄准镜）" },
        new() { Guid="B79B965E-E080-475D-A1CC-2432DE5F3BF5", Kind="支援兵 主要武器", Id="U_LewisMG", Name="路易士机枪（轻量化）" },
        new() { Guid="465A4240-78EA-4648-868F-40EA06D5DC06", Kind="支援兵 主要武器", Id="U_HotchkissM1909_Wep_Stability", Name="M1909 贝内特·梅西耶机枪（冲锋）" },
        new() { Guid="02721F8C-6901-4389-B56A-89C3AC93C889", Kind="支援兵 主要武器", Id="U_HotchkissM1909_Wep_Range", Name="M1909 贝内特·梅西耶机枪（瞄准镜）" },
        new() { Guid="94286083-BE6A-46C0-AFAF-011635458AAA", Kind="支援兵 主要武器", Id="U_HotchkissM1909_Wep_Bipod", Name="M1909 贝内特·梅西耶机枪（望远瞄具）" },
        new() { Guid="75DEC4E1-9A85-43A3-BBDE-9908F7A65D23", Kind="支援兵 主要武器", Id="U_MadsenMG_Wep_Trench", Name="麦德森机枪（壕沟战）" },
        new() { Guid="6E9863F2-2A32-4A0A-8F6C-BBC668044B15", Kind="支援兵 主要武器", Id="U_MadsenMG_Wep_Stability", Name="麦德森机枪（冲锋）" },
        new() { Guid="E2812647-A994-413B-B24F-24CAF2578551", Kind="支援兵 主要武器", Id="U_MadsenMG", Name="麦德森机枪（轻量化）" },
        new() { Guid="2F0B54CD-CA30-4E9C-9384-5E967C478845", Kind="支援兵 主要武器", Id="U_Bergmann1915MG_Wep_Suppression", Name="MG15 n.A.（压制）" },
        new() { Guid="FFD12D82-9187-4F1A-823F-0F61E766EC98", Kind="支援兵 主要武器", Id="U_Bergmann1915MG_Wep_Stability", Name="MG15 n.A.（冲锋）" },
        new() { Guid="64BE05D1-CE33-4DE5-9458-AB083C776635", Kind="支援兵 主要武器", Id="U_Bergmann1915MG", Name="MG15 n.A.（轻量化）" },
        new() { Guid="3231A399-B1DB-4D04-B286-1338092424B9", Kind="支援兵 主要武器", Id="U_BARM1918_Wep_Trench", Name="M1918 白朗宁自动步枪（壕沟战）" },
        new() { Guid="7D987B4E-A08C-41AD-A68B-245FBB5B10EF", Kind="支援兵 主要武器", Id="U_BARM1918_Wep_Stability", Name="M1918 白朗宁自动步枪（冲锋）" },
        new() { Guid="2D800408-99C2-4A84-9B8E-C713F4B6C450", Kind="支援兵 主要武器", Id="U_BARM1918_Wep_Bipod", Name="M1918 白朗宁自动步枪（望远瞄具）" },
        new() { Guid="AB16FE32-BC40-4AB0-9F8C-07AADBBC1E4E", Kind="支援兵 主要武器", Id="U_BARM1918A2", Name="M1918A2 白朗宁自动步枪" },
        new() { Guid="5C2C5A64-6227-4FA3-A382-E9DD68C66DAD", Kind="支援兵 主要武器", Id="U_HuotAutoRifle", Name="Huot 自动步枪（轻量化）" },
        new() { Guid="EE0A0210-4B5F-48DC-A02F-5879C24B1580", Kind="支援兵 主要武器", Id="U_HuotAutoRifle_Wep_Range", Name="Huot 自动步枪（瞄准镜）" },
        new() { Guid="20BB8B94-1A01-4D8E-A2C7-7D19CE440802", Kind="支援兵 主要武器", Id="U_Chauchat", Name="绍沙轻机枪（轻量化）" },
        new() { Guid="2C12E5FE-909A-4F0C-99FD-B23FBD1A6B4C", Kind="支援兵 主要武器", Id="U_Chauchat_Wep_Bipod", Name="绍沙轻机枪（望远瞄具）" },
        new() { Guid="37207FD2-BD0C-460A-A065-6D8A5DEE2334", Kind="支援兵 主要武器", Id="U_ParabellumLMG", Name="Parabellum MG14/17（轻量化）" },
        new() { Guid="95BDD2DE-CF36-45E1-B2F6-1DC5B8F8E632", Kind="支援兵 主要武器", Id="U_ParabellumLMG_Wep_Suppression", Name="Parabellum MG14/17（压制）" },
        new() { Guid="406A7149-CFBC-4CD4-8ED7-B388AB1B5501", Kind="支援兵 主要武器", Id="U_PerinoM1908", Name="Perino Model 1908（轻量化）" },
        new() { Guid="1B3EA625-4AFD-465D-AC16-16356B26BB82", Kind="支援兵 主要武器", Id="U_PerinoM1908_Wep_Defensive", Name="Perino Model 1908（防御）" },
        new() { Guid="BE397913-E33F-40B2-87C4-F7B92426AAA1", Kind="支援兵 主要武器", Id="U_BrowningM1917", Name="M1917 机枪（轻量化）" },
        new() { Guid="96B134CC-5EDA-436A-9913-5ED429C696DD", Kind="支援兵 主要武器", Id="U_BrowningM1917_Wep_Suppression", Name="M1917 机枪（望远瞄具）" },
        new() { Guid="57D820BF-38CC-4F62-8069-617E063971A0", Kind="支援兵 主要武器", Id="U_MG0818", Name="轻机枪 08/18（轻量化）" },
        new() { Guid="16DF4163-78E0-4926-929A-E6052E04BE7F", Kind="支援兵 主要武器", Id="U_MG0818_Wep_Defensive", Name="轻机枪 08/18（压制）" },
        new() { Guid="6C8284DF-9CEC-4391-9E1B-0E355C2D1310", Kind="支援兵 主要武器", Id="U_WinchesterBurton_Wep_Trench", Name="波顿 LMR（战壕）" },
        new() { Guid="708392C1-38F7-4CFA-81E3-04FC90434021", Kind="支援兵 主要武器", Id="U_WinchesterBurton_Wep_Optical", Name="波顿 LMR（瞄准镜）" },
        new() { Guid="53B264D8-1E4D-42E9-AA31-401D55BA2F39", Kind="支援兵 主要武器", Id="U_MauserC96AutoPistol", Name="C96（卡宾枪）" },
        new() { Guid="0CC870E0-7AAE-44FE-B9D8-5D90706AF38B", Kind="支援兵 主要武器", Id="U_LugerArtillery", Name="P08 Artillerie" },
        new() { Guid="6CB23E70-F191-4043-951A-B43D6D2CF4A2", Kind="支援兵 主要武器", Id="U_PieperCarbine", Name="皮珀 M1893" },
        new() { Guid="3DC12572-2D2F-4439-95CA-8DFB80BA17F5", Kind="支援兵 主要武器", Id="U_M1911_Stock", Name="M1911（加长）" },
        new() { Guid="2B421852-CFF9-41FF-B385-34580D5A9BF0", Kind="支援兵 主要武器", Id="U_FN1903stock", Name="Mle 1903（加长）" },
        new() { Guid="EBE043CB-8D37-4807-9260-E2DD7EFC4BD2", Kind="支援兵 主要武器", Id="U_C93Carbine", Name="C93（卡宾枪）" },

        // 支援兵 配枪
        new() { Guid="333D0B8C-404B-4B99-9588-B01736E0B742", Kind="支援兵 配枪", Id="U_SteyrM1912", Name="Repetierpistole M1912" },
        new() { Guid="B8EA5E4D-5B6A-9958-473F-20E8B2088CFD", Kind="支援兵 配枪", Id="U_Bulldog", Name="斗牛犬左轮手枪" },
        new() { Guid="101FAD96-0E8B-4AB2-9299-299A15CB5BF1", Kind="支援兵 配枪", Id="U_BerettaM1915", Name="Modello 1915" },
        new() { Guid="CF71A87B-2BD4-4AF8-AE80-D3B9F6F5CEDE", Kind="支援兵 配枪", Id="U_M1911_A1", Name="M1911A1" },

        // 支援兵 配备一二
        new() { Guid="2B0EC5C1-81A5-424A-A181-29B1E9920DDA", Kind="支援兵 配备一二", Id="U_AmmoCrate", Name="弹药箱" },
        new() { Guid="52B19C38-72C0-4E0F-B051-EF11103F6220", Kind="支援兵 配备一二", Id="U_AmmoPouch", Name="弹药包" },
        new() { Guid="C71A02C3-608E-42AA-9179-A4324A4D4539", Kind="支援兵 配备一二", Id="U_Mortar", Name="迫击炮（空爆）" },
        new() { Guid="8BD0FABD-DCCE-4031-8156-B77866FCE1A0", Kind="支援兵 配备一二", Id="U_Mortar_HE", Name="迫击炮（高爆）" },
        new() { Guid="F59AA727-6618-4C1D-A5E2-007044CA3B89", Kind="支援兵 配备一二", Id="U_Wrench", Name="维修工具" },
        new() { Guid="95A5E9D8-E949-46C2-B5CA-36B3CA4C2E9D", Kind="支援兵 配备一二", Id="U_LimpetMine", Name="磁吸地雷" },
        new() { Guid="02D4481F-FBC3-4C57-AAAC-1B37DC92751E", Kind="支援兵 配备一二", Id="U_Crossbow", Name="十字弓发射器（破片）" },
        new() { Guid="60D24A79-BFD6-4C8F-B54F-D1AA6D2620DE", Kind="支援兵 配备一二", Id="U_Crossbow_HE", Name="十字弓发射器（高爆）" },

        ////////////////////////////////// 侦察兵 Scout   //////////////////////////////////

        // 侦察兵 主要武器
        new() { Guid="11AAA000-BEA2-44E4-A463-11CE25CA4E93", Kind="侦察兵 主要武器", Id="U_WinchesterM1895_Wep_Trench", Name="Russian 1895（壕沟战）" },
        new() { Guid="5BD7640B-2308-4CB9-98EB-26E4AB5AB1C9", Kind="侦察兵 主要武器", Id="U_WinchesterM1895_Wep_Long", Name="Russian 1895（狙击手）" },
        new() { Guid="4A960C79-5265-4559-B1D2-90E1B5BE7238", Kind="侦察兵 主要武器", Id="U_WinchesterM1895", Name="Russian 1895（步兵）" },
        new() { Guid="DA44F656-997F-4DD8-B3A2-34B9E057BE19", Kind="侦察兵 主要武器", Id="U_Gewehr98_Wep_Scope", Name="Gewehr 98（神射手）" },
        new() { Guid="2E2F512C-D9DC-470E-86E0-8B5F827FEA8A", Kind="侦察兵 主要武器", Id="U_Gewehr98_Wep_LongRange", Name="Gewehr 98（狙击手）" },
        new() { Guid="2EEF7FFC-A1A4-4143-A0DF-3F41EF611433", Kind="侦察兵 主要武器", Id="U_Gewehr98", Name="Gewehr 98（步兵）" },
        new() { Guid="F59A978F-54BB-43F9-8497-47EC8D907EA6", Kind="侦察兵 主要武器", Id="U_LeeEnfieldSMLE_Wep_Scope", Name="SMLE MKIII（神射手）" },
        new() { Guid="DB650ACE-7B44-4FA1-A146-EAE44E94C68C", Kind="侦察兵 主要武器", Id="U_LeeEnfieldSMLE_Wep_Med", Name="SMLE MKIII（卡宾枪）" },
        new() { Guid="CD35EDD7-6F6E-4B72-ACC7-37CD0E4D060A", Kind="侦察兵 主要武器", Id="U_LeeEnfieldSMLE", Name="SMLE MKIII（步兵）" },
        new() { Guid="7ED7AE0D-03C6-44D4-9072-261C6570B3BF", Kind="侦察兵 主要武器", Id="U_SteyrManM1895_Wep_Scope", Name="Gewehr M.95（神射手）" },
        new() { Guid="7668C6B5-D793-442A-8AFA-74E4CD158F33", Kind="侦察兵 主要武器", Id="U_SteyrManM1895_Wep_Med", Name="Gewehr M.95（卡宾枪）" },
        new() { Guid="E372F592-9278-4777-A9E3-C91B171FD1F7", Kind="侦察兵 主要武器", Id="U_SteyrManM1895", Name="Gewehr M.95（步兵）" },
        new() { Guid="B0987D7E-F43D-4AA7-9A8E-A33EFA985864", Kind="侦察兵 主要武器", Id="U_SpringfieldM1903_Wep_Scope", Name="M1903（神射手）" },
        new() { Guid="BA5E14FF-D373-4927-9D0F-11CD9423AE4B", Kind="侦察兵 主要武器", Id="U_SpringfieldM1903_Wep_LongRange", Name="M1903（狙击手）" },
        new() { Guid="9984202B-FE89-447C-879B-25A2B797A176", Kind="侦察兵 主要武器", Id="U_SpringfieldM1903_Wep_Pedersen", Name="M1903（实验）" },
        new() { Guid="43E292F0-511B-458B-852A-7EBDB20F6B27", Kind="侦察兵 主要武器", Id="U_MartiniHenry", Name="马提尼·亨利步枪（步兵）" },
        new() { Guid="0440A003-1E71-47A2-98A9-73EC23D83CB4", Kind="侦察兵 主要武器", Id="U_MartiniHenry_Wep_LongRange", Name="马提尼·亨利步枪（狙击手）" },
        new() { Guid="1AC12662-F06E-4562-80A3-FFD598CEB7EB", Kind="侦察兵 主要武器", Id="U_LeeEnfieldSMLE_Wep_Preorder", Name="阿拉伯的劳伦斯的 SMLE" },
        new() { Guid="85EFAE4D-6C60-4DA0-8F38-0548E1FB193F", Kind="侦察兵 主要武器", Id="U_Lebel1886_Wep_LongRange", Name="勒贝尔 M1886（狙击手）" },
        new() { Guid="59D35CF4-3530-4B8C-9519-A78E9577BA1A", Kind="侦察兵 主要武器", Id="U_Lebel1886", Name="勒贝尔 M1886（步兵）" },
        new() { Guid="FA55E980-2D48-4CFC-8700-1E0533C9CB4A", Kind="侦察兵 主要武器", Id="U_MosinNagant1891", Name="莫辛-纳甘 M91（步兵）" },
        new() { Guid="9A1C2640-9684-414E-9D05-94F5A9858296", Kind="侦察兵 主要武器", Id="U_MosinNagant1891_Wep_Scope", Name="莫辛-纳甘 M91（神射手）" },
        new() { Guid="4A392B4B-97FA-4672-B5D8-C4085A87CB39", Kind="侦察兵 主要武器", Id="U_MosinNagantM38", Name="莫辛-纳甘 M38 卡宾枪" },
        new() { Guid="4B831597-5062-461E-9CC9-9611BD1B50E3", Kind="侦察兵 主要武器", Id="U_VetterliVitaliM1870", Name="Vetterli-Vitali M1870/87（步兵）" },
        new() { Guid="B6B5C8CB-0C40-4522-8907-4FCE5B243C83", Kind="侦察兵 主要武器", Id="U_VetterliVitaliM1870_Wep_Med", Name="Vetterli-Vitali M1870/87（卡宾枪）" },
        new() { Guid="A3A708E8-6719-4178-9958-36814E906FD4", Kind="侦察兵 主要武器", Id="U_Type38Arisaka", Name="三八式步枪（步兵）" },
        new() { Guid="BB20B711-EF98-4708-998A-D78780B8B8C4", Kind="侦察兵 主要武器", Id="U_Type38Arisaka_Wep_Scope", Name="三八式步枪（巡逻）" },
        new() { Guid="D0DBCD64-BFAE-4B96-867E-C493641C269B", Kind="侦察兵 主要武器", Id="U_CarcanoCarbine", Name="卡尔卡诺 M91 卡宾枪" },
        new() { Guid="4E317627-F7F8-4014-BB22-B0ABEB7E9141", Kind="侦察兵 主要武器", Id="U_CarcanoCarbine_Wep_Scope", Name="卡尔卡诺 M91 卡宾枪（巡逻）" },
        new() { Guid="8FAB67E1-A8ED-4EC0-8135-DB2BAA832890", Kind="侦察兵 主要武器", Id="U_RossMkIII", Name="罗斯 MKIII（步兵）" },
        new() { Guid="168D4F4B-AD76-40D3-AD86-EB52890872D8", Kind="侦察兵 主要武器", Id="U_RossMkIII_Wep_Scope", Name="罗斯 MKIII（神射手）" },
        new() { Guid="D8F58A20-88D8-4C25-B395-385641324ACF", Kind="侦察兵 主要武器", Id="U_Enfield1917", Name="M1917 Enfield（步兵）" },
        new() { Guid="374F5969-7A06-4188-BA76-266F91304FE4", Kind="侦察兵 主要武器", Id="U_Enfield1917_Wep_LongRange", Name="M1917 Enfield（消音器）" },

        // 侦察兵 配枪
        new() { Guid="E5A72AA0-02C9-40B8-A74D-D60C921D1288", Kind="侦察兵 配枪", Id="U_MarsAutoPistol", Name="Mars 自动手枪" },
        new() { Guid="F08BC756-2600-4834-BDBA-4E53C4A24E1D", Kind="侦察兵 配枪", Id="U_Bodeo1889", Name="Bodeo 1889" },
        new() { Guid="FAE1EA24-DFBE-3E0A-E525-BC20340FE196", Kind="侦察兵 配枪", Id="U_FrommerStop", Name="费罗梅尔停止手枪" },

        // 侦察兵 配备一二
        new() { Guid="2543311A-B9BC-4F72-8E71-C9D32DCA9CFC", Kind="侦察兵 配备一二", Id="U_FlareGun", Name="信号枪（侦察）" },
        new() { Guid="ADAD5F72-BD74-46EF-AB42-99F95D88DF8E", Kind="侦察兵 配备一二", Id="U_FlareGun_Flash", Name="信号枪（闪光）" },
        new() { Guid="C43D1466-F9D1-474B-A737-3820B6989819", Kind="侦察兵 配备一二", Id="U_TrPeriscope", Name="战壕潜望镜" },
        new() { Guid="370323AD-6AFD-4D44-899E-7FB8144E580F", Kind="侦察兵 配备一二", Id="U_Shield", Name="狙击手护盾" },
        new() { Guid="C85A5030-C6DA-4DEF-8BA5-3087A80DEC17", Kind="侦察兵 配备一二", Id="U_HelmetDecoy", Name="狙击手诱饵" },
        new() { Guid="EF1C7B9B-8912-4298-8FCB-29CC75DD0E7F", Kind="侦察兵 配备一二", Id="U_TripWireBomb", Name="绊索炸弹（高爆）" },
        new() { Guid="033299D1-A8E6-4A5A-8932-6F2091745A9D", Kind="侦察兵 配备一二", Id="U_TripWireGas", Name="绊索炸弹（毒气）" },
        new() { Guid="9CF9EA1C-39A1-4365-85A1-3645B9621901", Kind="侦察兵 配备一二", Id="U_TripWireBurn", Name="绊索炸弹（燃烧）" },
        new() { Guid="2D64B139-27C8-4EDB-AB14-734993A96008", Kind="侦察兵 配备一二", Id="_KBullet", Name="K弹" },

        /////////////////////////////////////////////////////////////////////////////

        // 制式步枪
        new() { Guid="51C25C93-D4B0-4A03-81BA-E9AC600E5168", Kind="制式步枪", Id="U_SteyrManM1895_SI", Name="Gewehr M.95" },
        new() { Guid="9EDA2088-C4CF-43A1-A99D-7BD051EB6372", Kind="制式步枪", Id="U_SpringfieldM1903_SI", Name="M1903" },
        new() { Guid="85D2A502-DCEC-42D9-AF11-91D52823FB17", Kind="制式步枪", Id="U_Gewehr98_SI", Name="Gewehr 98" },
        new() { Guid="03750E5A-0178-4CB2-9F5D-A7A65C2B1029", Kind="制式步枪", Id="U_LeeEnfieldSMLE_SI", Name="SMLE MKIII" },
        new() { Guid="F6731994-3C9D-402C-B690-62ED2CC53306", Kind="制式步枪", Id="U_WinchesterM1895_SI", Name="Russian 1895" },
        new() { Guid="59CBDD10-807F-42C8-B3B9-E6AA55380C92", Kind="制式步枪", Id="U_MosinNagant1891_SI", Name="莫辛-纳甘 M91 步枪" },

        /////////////////////////////////////////////////////////////////////////////

        // 精英兵
        new() { Guid="0B575357-B536-45FF-BC1B-386560AE2163", Kind="精英兵", Id="U_MaximMG0815", Name="哨兵 MG 08/15" },
        new() { Guid="BCF1DDDF-C812-43E6-9F5A-F08109BAB746", Kind="精英兵", Id="U_VillarPerosa", Name="哨兵 维拉·佩罗萨冲锋枪" },
        new() { Guid="D4A1023A-6C3B-48DF-9515-C35A9463794D", Kind="精英兵", Id="U_FlameThrower", Name="喷火兵 Wex" },
        new() { Guid="8219207A-41E6-4ED2-A3E8-9690752EC40C", Kind="精英兵", Id="U_Incendiary_Hero", Name="燃烧手榴弹" },
        new() { Guid="8A849EDD-AE9F-4F9D-B872-7728067E4E9F", Kind="精英兵", Id="U_RoyalClub", Name="战壕奇兵 奇兵棒" },
        new() { Guid="1B74E3E0-2484-3BF0-AF8F-25BFA008B6F0", Kind="精英兵", Id="U_MartiniGrenadeLauncher", Name="入侵者 马提尼·亨利步枪榴弹发射器" },
        new() { Guid="7085A5B9-6A77-4766-83CD-3666DA3EDF28", Kind="精英兵", Id="U_SawnOffShotgun_FK", Name="短管霰弹枪" },
        new() { Guid="9D1BEE08-C101-4FF3-8ECA-244240171801", Kind="精英兵", Id="U_FlareGun_Elite", Name="信号枪 — 信号" },
        new() { Guid="64E2FAC6-9674-4E39-89D8-FA351D21C5C9", Kind="精英兵", Id="U_SpawnBeacon", Name="重生信标" },
        new() { Guid="A9DBBCBD-E028-4EE9-8123-252B983D8CD6", Kind="精英兵", Id="U_TankGewehr", Name="坦克猎手 Tankgewehr M1918" },
        new() { Guid="C43D1466-F9D1-474B-A737-3820B6989819", Kind="精英兵", Id="U_TrPeriscope_Elite", Name="战壕潜望镜" },
        new() { Guid="72CCBF3E-C0FE-4657-A1A7-EACDB2D11985", Kind="精英兵", Id="U_ATGrenade_VhKit", Name="反坦克手榴弹" },

        /////////////////////////////////////////////////////////////////////////////

        new() { Guid="E76568C5-B222-4C49-B4E0-D517425596C6", Kind="驾驶员下车", Id="U_WinchesterM1895_Horse", Name="Russian 1895（骑兵）" },
        new() { Guid="52B19C38-72C0-4E0F-B051-EF11103F6220", Kind="驾驶员下车", Id="U_AmmoPouch_Cav", Name="弹药包" },
        new() { Guid="9BCDB1F5-5E1C-4C3E-824C-8C05CC0CE21A", Kind="驾驶员下车", Id="U_Bandages_Cav", Name="绷带包" },
        new() { Guid="D4A99456-2ABA-4376-9870-200FD24C5D45", Kind="驾驶员下车", Id="U_Grenade_AT_Cavalry", Name="轻型反坦克手榴弹" },
        new() { Guid="009736C2-B237-49AE-9DD1-E77AF7771FF2", Kind="驾驶员下车", Id="U_LugerP08_VhKit", Name="P08 手枪" },
        
        /////////////////////////////////////////////////////////////////////////////
        
        // 近战
        new() { Guid="27FEC1DA-8B41-4F6F-87EA-B0225FBB964E", Kind="近战武器", Id="U_Shovel", Name="军铲" },
        new() { Guid="BCC17D36-9B5E-48E7-BCD0-2C390D0AA5E0", Kind="近战武器", Id="U_TrenchMace", Name="战壕槌" },
        new() { Guid="F9983578-E3E9-46FB-BCC5-6640825B7169", Kind="近战武器", Id="U_SawtoothKnife", Name="锯齿刀" },
        new() { Guid="5ECF98B5-035C-4D9E-99DA-0B5802E343B6", Kind="近战武器", Id="U_Club", Name="棍棒" },
        new() { Guid="EDC97B49-0582-4166-A489-B2171F26B392", Kind="近战武器", Id="U_AmericanTrenchKnife", Name="小型战壕刀" },
        new() { Guid="E6F76148-EBF4-4F1A-9AC0-A96DA81BD948", Kind="近战武器", Id="U_KnifeTrench", Name="战壕刀" },
        new() { Guid="60538A4D-7E4A-4755-BC4E-CF625691A3EB", Kind="近战武器", Id="U_BoloKnife", Name="地狱战士双刃短刀" },
        new() { Guid="01EDB113-9A7A-4639-80C2-E557B0BFD95B", Kind="近战武器", Id="U_USTrenchKnife1917", Name="美军战壕刀" },
        new() { Guid="624E46AC-B9C2-45B0-B193-8D74C9437EFA", Kind="近战武器", Id="U_BeduinDagger", Name="贝都因匕首" },
        new() { Guid="C41B429F-0991-4FDE-B298-5CCF940FD10D", Kind="近战武器", Id="U_JambiyaKnife", Name="双刃弯刀" },
        new() { Guid="F56F6EBF-B486-47E8-B31C-7EC694E51498", Kind="近战武器", Id="U_SpikedClub", Name="狼牙棒" },
        new() { Guid="4E40014C-B574-41A7-AF7C-8FE4556AC201", Kind="近战武器", Id="U_BayonetCharge", Name="刺刀衝锋" },
        new() { Guid="9AA7F012-93CB-4CA2-9B5F-3DDEFB7050BD", Kind="近战武器", Id="U_Hatchet", Name="手斧" },
        new() { Guid="47EFBE34-8604-4811-BD9B-51415E04F251", Kind="近战武器", Id="U_BartekBludgeon", Name="鲍尔泰克巨木棒" },
        new() { Guid="A32A090F-16B9-4546-983A-43BE721BDA6B", Kind="近战武器", Id="U_Saber_Cav", Name="骑兵军刀" },
        new() { Guid="EF835C7F-2569-4524-BE13-4C4B5988A93F", Kind="近战武器", Id="U_ScoutKnifeM1916", Name="野战刀" },
        new() { Guid="5BE36F02-DE5E-4DDD-8E09-74FD16F39EFC", Kind="近战武器", Id="U_ScoutKnife", Name="求生小刀" },
        new() { Guid="F1A70E1E-8A1A-406F-B9EC-DA388A690513", Kind="近战武器", Id="U_Pickaxe", Name="鹤嘴锄" },
        new() { Guid="DE1AEA73-D8AE-47E9-B2C2-48E0BC817E11", Kind="近战武器", Id="U_Frenchnail", Name="铁钉小刀" },
        new() { Guid="34D4650D-BC3A-4670-B462-56B9293B369A", Kind="近战武器", Id="U_RoyalSabre", Name="军刀" },
        new() { Guid="5703EA77-6B58-492B-84A8-9E2C7858BDA8", Kind="近战武器", Id="U_TrenchFleur", Name="战壕鸢尾刀" },
        new() { Guid="8A849EDD-AE9F-4F9D-B872-7728067E4E9F", Kind="近战武器", Id="U_RoyalClub", Name="奇兵棒" },
        new() { Guid="45629BFF-8046-4C75-9C39-BE10C0866C41", Kind="近战武器", Id="U_BIllhook", Name="钩镰" },
        new() { Guid="CBFB454C-DBF2-41DB-A4BA-628F8FC14C34", Kind="近战武器", Id="U_TankerClub", Name="齿轮槌" },
        new() { Guid="78502D88-206A-4216-BD0D-F5FCFDCDAF44", Kind="近战武器", Id="U_Kukri", Name="反曲刀" },
        new() { Guid="6EE87AD3-DC0C-40A7-84FF-7558CD317557", Kind="近战武器", Id="U_ArditiDaggerNew", Name="敢死队匕首" },
        new() { Guid="CB3DE34F-3706-42BD-B7E6-00D54EA6B936", Kind="近战武器", Id="U_Lance_Cav", Name="骑兵长枪" },
        new() { Guid="5B8AFD98-8C0D-4846-91FF-3334A2C41062", Kind="近战武器", Id="U_CossackDagger", Name="哥萨克匕首" },
        new() { Guid="E0F9C0D2-939A-4E89-AA8B-B3AF5ADA5C86", Kind="近战武器", Id="U_GrenadeClub", Name="哑弹棒" },
        new() { Guid="57EAB779-B881-4D9A-8F16-A7EC3B359061", Kind="近战武器", Id="U_Totokia", Name="鸟嘴槌" },
        new() { Guid="E6D69CA1-B643-4CA1-8AF0-24AB0B8EEF81", Kind="近战武器", Id="U_HuntingKnife", Name="法军屠刀" },
        new() { Guid="020C3966-C489-4D5A-9883-5F1D26F7CFC3", Kind="近战武器", Id="U_RussianCombatKnife", Name="俄军勳刀" },
        new() { Guid="688C92FA-A3DB-4519-A0C2-DE24CCF00EB0", Kind="近战武器", Id="U_CoupeCoupe", Name="开山刀" },
        new() { Guid="2AD2C37C-E68C-4DFB-9FD0-313A2C2AF45B", Kind="近战武器", Id="U_RussianAxe", Name="俄军战斧" },
        new() { Guid="52590553-2E05-4A74-B168-A1D741D60942", Kind="近战武器", Id="U_NavalCutlass", Name="海军弯刀" },
        new() { Guid="0A553FF6-89EB-4A01-8697-5EEE975B2651", Kind="近战武器", Id="U_MarineHook", Name="勾索" },
        new() { Guid="3C23E897-CB52-4794-98D8-C321C95E30A9", Kind="近战武器", Id="U_OttomanFlangedMace", Name="鄂图曼钉头锤" },
        new() { Guid="917B1B48-21BC-4FCE-A45C-BDE2A1C561FB", Kind="近战武器", Id="U_SpikedClubBarbedWire", Name="铁丝木棒" },
        new() { Guid="5BCDA8AE-E088-4106-B4D6-1AEC26B7F140", Kind="近战武器", Id="U_Ararebo", Name="金碎棒" },
        new() { Guid="4913316F-B1BF-46F2-8B15-EACF0E5B07C9", Kind="近战武器", Id="U_KilijSabre", Name="鄂图曼弯刀" },
        new() { Guid="38E74B0D-04FE-46CF-B3B8-B4AAE88A83EF", Kind="近战武器", Id="U_Yatagan", Name="穆斯林弯刀" },
        new() { Guid="42561396-096D-4B56-AA3E-F5EABA8E6147", Kind="近战武器", Id="U_MeatCleaver", Name="切肉刀" },
        new() { Guid="7CB43200-5E40-40FB-89FD-5B550AC2879F", Kind="近战武器", Id="U_Prybar", Name="撬棍" },
        new() { Guid="7B0EEEF0-5C96-4766-8B49-AE48EB4D9937", Kind="近战武器", Id="U_BrokenBottle", Name="碎酒瓶" },
        new() { Guid="FA7A0B58-1929-4812-8BB6-ABE00CE2387C", Kind="近战武器", Id="U_Bottle", Name="酒瓶" },
        new() { Guid="C5118EA9-F587-44DC-BFB1-EA55C33F577E", Kind="近战武器", Id="U_Sickle", Name="镰刀" },
        new() { Guid="EA096988-1E90-4554-A45B-90EB6FA8F04B", Kind="近战武器", Id="U_WelshBlade", Name="威尔士刀" },
        
        // 其他
        new() { Guid="15C7D4EA-F225-4B6C-B2AE-452871A5CA77", Kind="其他", Id="U_GasMask", Name="防毒面具" },
    ];
}