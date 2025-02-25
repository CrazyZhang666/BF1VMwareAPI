using BF1VMwareAPI.Helper;

namespace BF1VMwareAPI;

/// <summary>
/// App.xaml 的交互逻辑
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// 主程序互斥体
    /// </summary>
    public static Mutex AppMainMutex;
    /// <summary>
    /// 应用程序名称
    /// </summary>
    private readonly string AppName = ResourceAssembly.GetName().Name;

    /// <summary>
    /// 保证程序只能同时启动一个
    /// </summary>
    protected override void OnStartup(StartupEventArgs e)
    {
        LoggerHelper.Info($"欢迎使用 {AppName} 程序");

        // 注册异常捕获
        RegisterEvents();

        //////////////////////////////////////////////////////

        AppMainMutex = new Mutex(true, AppName, out var createdNew);
        if (!createdNew)
        {
            LoggerHelper.Warn("请不要重复打开，程序已经运行");
            MsgBoxHelper.Warning($"请不要重复打开，程序已经运行\n如果一直提示，请到\"任务管理器-详细信息（win7为进程）\"里\n强制结束 \"{AppName}.exe\" 程序");
            Environment.Exit(0);
            return;
        }

        //////////////////////////////////////////////////////

        LoggerHelper.Info("正在进行 Dokan 环境检测...");
        var sysWOW64Dir = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
        var dokan2 = Path.Combine(sysWOW64Dir, "dokan2.dll");
        var dokannp2 = Path.Combine(sysWOW64Dir, "dokannp2.dll");
        if (!File.Exists(dokan2) || !File.Exists(dokannp2))
        {
            LoggerHelper.Error("检测到 Dokan 环境异常，请先安装 Dokan x64 环境");
            MsgBoxHelper.Error("检测到 Dokan 环境异常，请先安装 Dokan x64 环境\nhttps://github.com/dokan-dev/dokany/releases", "初始化错误");
            ProcessHelper.OpenLink("https://github.com/dokan-dev/dokany/releases");
            Environment.Exit(0);
            return;
        }
        LoggerHelper.Info("当前系统 Dokan 环境检测正常");

        //////////////////

        LoggerHelper.Info("正在进行 VMware 环境检测...");
        Globals.VMwareInstall = VMwareHelper.GetVMwareInstallPath();
        if (string.IsNullOrWhiteSpace(Globals.VMwareInstall))
        {
            LoggerHelper.Error("获取VMware安装路径失败，程序终止");
            MsgBoxHelper.Error("获取VMware安装路径失败，请先安装VMware虚拟机程序", "初始化错误");
            Environment.Exit(0);
            return;
        }
        LoggerHelper.Info("当前系统 VMware 环境检测正常");

        //////////////////

        LoggerHelper.Info("正在进行 vmrun.exe 环境检测...");
        Globals.VmRunExePath = Path.Combine(Globals.VMwareInstall, "vmrun.exe");
        if (!File.Exists(Globals.VmRunExePath))
        {
            LoggerHelper.Error("未发现 vmrun.exe 程序位置，程序终止");
            MsgBoxHelper.Error("未发现 vmrun.exe 程序位置，请先确保VMware虚拟机程序完整", "初始化错误");
            Environment.Exit(0);
            return;
        }
        LoggerHelper.Info("当前系统 vmrun.exe 环境检测正常");

        //////////////////

        LoggerHelper.Info("正在进行 Http端口 可用性检测...");
        var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        var ipEndPoints = ipProperties.GetActiveTcpListeners();
        foreach (var endPoint in ipEndPoints)
        {
            if (endPoint.Port == 10086)
            {
                LoggerHelper.Error("检测到 Http端口 10086 被占用，程序终止");
                MsgBoxHelper.Error("检测到 Http端口 10086 被占用，先请解除端口占用", "初始化错误");
                Environment.Exit(0);
                return;
            }
        }
        LoggerHelper.Info("当前系统 Http端口 检测正常");

        //////////////////////////////////////////////////////

        base.OnStartup(e);
    }

    /// <summary>
    /// 注册异常捕获事件
    /// </summary>
    private void RegisterEvents()
    {
        DispatcherUnhandledException += App_DispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    }

    /// <summary>
    /// UI线程未捕获异常处理事件（UI主线程）
    /// </summary>
    private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var msg = GetExceptionInfo(e.Exception, e.ToString());
        SaveCrashLog(msg);
    }

    /// <summary>
    /// 非UI线程未捕获异常处理事件（例如自己创建的一个子线程）
    /// </summary>
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var msg = GetExceptionInfo(e.ExceptionObject as Exception, e.ToString());
        SaveCrashLog(msg);
    }

    /// <summary>
    /// Task线程内未捕获异常处理事件
    /// </summary>
    private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        var msg = GetExceptionInfo(e.Exception, e.ToString());
        SaveCrashLog(msg);
    }

    /// <summary>
    /// 生成自定义异常消息
    /// </summary>
    private string GetExceptionInfo(Exception ex, string backStr)
    {
        var builder = new StringBuilder();

        builder.AppendLine($"程序版本: {Globals.VersionInfo}");
        builder.AppendLine($"用户名称: {Globals.UserName}");
        builder.AppendLine($"电脑名称: {Globals.MachineName}");
        builder.AppendLine($"系统版本: {Globals.OSVersion}");
        builder.AppendLine($"系统目录: {Globals.SystemDirectory}");
        builder.AppendLine($"运行库平台: {Globals.RuntimeVersion}");
        builder.AppendLine($"运行库版本: {Globals.OSArchitecture}");
        builder.AppendLine($"运行库环境: {Globals.RuntimeIdentifier}");
        builder.AppendLine("------------------------------");
        builder.AppendLine($"崩溃时间: {DateTime.Now}");

        if (ex is not null)
        {
            builder.AppendLine($"异常类型: {ex.GetType().Name}");
            builder.AppendLine($"异常信息: {ex.Message}");
            builder.AppendLine($"堆栈调用: \n{ex.StackTrace}");
        }
        else
        {
            builder.AppendLine($"未处理异常: {backStr}");
        }

        return builder.ToString();
    }

    /// <summary>
    /// 保存崩溃日志
    /// </summary>
    private void SaveCrashLog(string log)
    {
        try
        {
            var path = Path.Combine(Globals.Dir_Crash, $"CrashReport-{DateTime.Now:yyyyMMdd_HHmmss_ffff}.log");
            File.WriteAllText(path, log);
        }
        catch { }
    }
}