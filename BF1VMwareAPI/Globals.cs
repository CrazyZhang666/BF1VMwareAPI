using BF1VMwareAPI.Helper;

namespace BF1VMwareAPI;

public static class Globals
{
    public static string VMwareInstall { get; set; }
    public static string VmRunExePath { get; set; }

    //////////////////////////////////

    public static string Dir_MyDocuments { get; private set; }
    public static string Dir_Default { get; private set; }

    public static string Dir_Config { get; private set; }
    public static string Dir_NLog { get; private set; }
    public static string Dir_Crash { get; private set; }

    //////////////////////////////////

    public static readonly Version VersionInfo;

    public static readonly string UserName;             // Win10
    public static readonly string MachineName;          // CRAZYZHANG
    public static readonly string OSVersion;            // Microsoft Windows NT 10.0.19045.0
    public static readonly string SystemDirectory;      // C:\Windows\system32

    public static readonly string RuntimeVersion;       // .NET 6.0.29
    public static readonly string OSArchitecture;       // X64
    public static readonly string RuntimeIdentifier;    // win10-x64

    static Globals()
    {
        Dir_MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Dir_Default = Path.Combine(Dir_MyDocuments, "BF1VMwareAPI");

        Dir_Config = Path.Combine(Dir_Default, "Config");
        Dir_NLog = Path.Combine(Dir_Default, "NLog");
        Dir_Crash = Path.Combine(Dir_Default, "Crash");

        FileHelper.CreateDirectory(Dir_Config);
        FileHelper.CreateDirectory(Dir_NLog);
        FileHelper.CreateDirectory(Dir_Crash);

        //////////////////////////////////////

        VersionInfo = Application.ResourceAssembly.GetName().Version;

        UserName = Environment.UserName;
        MachineName = Environment.MachineName;
        OSVersion = Environment.OSVersion.ToString();
        SystemDirectory = Environment.SystemDirectory;

        RuntimeVersion = RuntimeInformation.FrameworkDescription;
        OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
        RuntimeIdentifier = RuntimeInformation.RuntimeIdentifier;
    }
}