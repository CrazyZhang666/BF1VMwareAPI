using BF1VMwareAPI.Api;
using BF1VMwareAPI.Helper;
using BF1VMwareAPI.Models;
using BF1VMwareAPI.Native;
using CommunityToolkit.Mvvm.Input;
using Hardcodet.Wpf.TaskbarNotification;
using Vmmsharp;
using Timer = System.Timers.Timer;
using Window = ModernWpf.Controls.Window;

namespace BF1VMwareAPI;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow
{
    private const string _apiHost = "http://127.0.0.1:10086";

    /// <summary>
    /// 窗口关闭识别标志
    /// </summary>
    private bool _isCodeClose = false;
    /// <summary>
    /// 第一次通知标志
    /// </summary>
    private bool _isFirstNotice = false;

    /// <summary>
    /// 主程序运行标志
    /// </summary>
    private bool _isAppRunning = true;

    /// <summary>
    /// 记录软件开始运行时间
    /// </summary>
    private DateTime _startTime;
    /// <summary>
    /// 用于统计软件运行时间
    /// </summary>
    private Timer _timerUpdate;

    /// <summary>
    /// 数据模型
    /// </summary>
    public MainModel MainModel { get; set; } = new();

    /// <summary>
    /// 用于向外暴露主窗口实例
    /// </summary>
    public static Window MainWinInstance { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 窗口加载完成事件
    /// </summary>
    private void Window_Main_Loaded(object sender, RoutedEventArgs e)
    {
        Title = $"战地1虚拟机API v{Globals.VersionInfo}";

        // 重置窗口关闭标志
        _isCodeClose = false;
        // 向外暴露主窗口实例
        MainWinInstance = this;
    }

    /// <summary>
    /// 窗口渲染完成事件
    /// </summary>
    private async void Window_Main_ContentRendered(object sender, EventArgs e)
    {
        // 记录软件开始运行时间
        _startTime = DateTime.Now;
        MainModel.RunningTime = "0天, 0时, 0分, 0秒";

        _timerUpdate = new Timer()
        {
            Interval = 1000
        };
        _timerUpdate.Elapsed += TimerUpdate_Elapsed;
        _timerUpdate.Start();

        //////////////////////////////////////////

        // 自动初始化内存模块线程
        new Thread(AutoInitBF1Thread)
        {
            Name = "AutoInitBF1Thread",
            IsBackground = true
        }.Start();

        // 运行HTTP WebAPI服务器线程
        new Thread(RunWebApiServerThread)
        {
            Name = "RunWebApiServerThread",
            IsBackground = true
        }.Start();

        //////////////////////////////////////////

        // 检查更新
        await CheckUpdate();
    }

    /// <summary>
    /// 窗口关闭时事件
    /// </summary>
    private void Window_Main_Closing(object sender, CancelEventArgs e)
    {
        // 当用户从UI点击关闭时才执行
        if (!_isCodeClose)
        {
            // 取消关闭事件，隐藏主窗口
            e.Cancel = true;
            this.Hide();

            // 仅第一次通知
            if (!_isFirstNotice)
            {
                NotifyIcon_Main.ShowBalloonTip("战地1虚拟机API 已最小化到托盘", "可通过托盘右键菜单完全退出程序", BalloonIcon.Info);
                _isFirstNotice = true;
            }

            return;
        }

        _isAppRunning = false;
        _timerUpdate.Stop();

        // 释放内存模块
        Memory.UnInitialize();

        // 释放托盘图标
        NotifyIcon_Main?.CloseBalloon();
        NotifyIcon_Main?.Dispose();
        NotifyIcon_Main = null;

        LoggerHelper.Info($"接口调用次数: {MainModel.VisitCount}次");
        LoggerHelper.Info($"程序运行时间: {MainModel.RunningTime}");

        LoggerHelper.Info("关闭主程序成功");
    }

    ///////////////////////////////////////////////////////

    /// <summary>
    /// 定时更新UI线程
    /// </summary>
    private void TimerUpdate_Elapsed(object sender, ElapsedEventArgs e)
    {
        var nowTime = DateTime.Now;
        var timeSpan = nowTime.Subtract(_startTime);

        MainModel.RunningTime = string.Format("{0}天, {1}时, {2}分, {3}秒", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }

    /// <summary>
    /// 自动初始化内存模块线程
    /// </summary>
    private async void AutoInitBF1Thread()
    {
        while (_isAppRunning)
        {
            try
            {
                var vmxProcessId = 0;
                var isVmxRunning = false;

                // vmware-vmx.exe
                var pArray = Process.GetProcessesByName("vmware-vmx");
                LoggerHelper.Trace($"vmware-vmx.exe 进程数量为: {pArray.Length}");

                if (pArray.Length > 0)
                {
                    // 获取第一个VMX进程Id
                    vmxProcessId = pArray.First().Id;
                    if (vmxProcessId is not 0)
                    {
                        isVmxRunning = true;
                        LoggerHelper.Trace($"获取第一个VMX进程Id为: {vmxProcessId}");
                    }
                }

                //////////////////////////////////////////

                if (isVmxRunning)
                {
                    if (!Memory.IsVmmInitSuccess())
                    {
                        // 如果VMX正在运行，并且Vmm实例尚未初始化
                        // 一般为刚启动虚拟机时发生

                        // 先等待虚拟机完全开机
                        if (!await VMwareHelper.GetFirstVMwareIsFullRunnig())
                        {
                            LoggerHelper.Trace("正在等待VMware虚拟机完全开机中...");
                            goto SLEEP;
                        }

                        LoggerHelper.Info($"检测到VMware虚拟机已开机，vmx进程Id为: {vmxProcessId}");

                        // ro=1 代表只读取内存，禁止写入
                        // id=xxx 需要填写 vmware-vmx.exe 的进程Id
                        // "-v", "-vm", "-waitinitialize", 
                        var vmmArgs = new string[] { "-device", $"vmware://ro=1,id={vmxProcessId}" };

                        var vmxVmm = new Vmm(vmmArgs);
                        if (vmxVmm is not null)
                        {
                            Memory.SetVmmInstance(vmxVmm);
                            MainModel.IsVmmInitOK = true;
                            LoggerHelper.Info("初始化 Vmm 实例成功");
                        }
                        else
                        {
                            MainModel.IsVmmInitOK = false;
                            LoggerHelper.Trace("错误！初始化 Vmm 实例失败");
                        }
                    }
                    else if (!Memory.IsBf1InitSuccess())
                    {
                        // 如果VMX正在运行，并且Vmm实例已经初始化，但是BF1进程尚未初始化
                        // 一般为完全启动虚拟机时发生

                        var vmmProcess = Memory.VmmInstance.Process(Memory.Bf1ExeName);
                        if (vmmProcess is not null)
                        {
                            Memory.SetBf1VmmProcess(vmmProcess);
                            MainModel.IsBf1InitOK = true;
                            LoggerHelper.Info($"初始化虚拟机 bf1.exe 进程成功，进程ID为: {vmmProcess.PID}");
                        }
                        else
                        {
                            MainModel.IsBf1InitOK = false;
                            LoggerHelper.Trace("错误！初始化虚拟机 bf1.exe 进程失败");
                        }
                    }
                    else if (Memory.IsBf1InitSuccess())
                    {
                        // 查询虚拟机中BF1的PID是否有效，以判断BF1进程是否关闭
                        if (!Memory.VmmInstance.PIDs.Contains(Memory.Bf1VmmProcess.PID))
                        {
                            Memory.UnInitBf1Process();
                            MainModel.IsBf1InitOK = false;
                            LoggerHelper.Warn("检测到虚拟机 bf1.exe 进程已关闭");
                        }
                    }
                }
                else
                {
                    // 如果VMX未运行，并且Vmm实例已经初始化
                    // 如果VMX未运行，并且BF1进程已经初始化
                    // 一般直接关闭虚拟机进程时发生

                    if (Memory.IsVmmInitSuccess() || Memory.IsBf1InitSuccess())
                    {
                        // 开始重置战地1内存模块
                        Memory.UnInitialize();

                        MainModel.IsVmmInitOK = false;
                        MainModel.IsBf1InitOK = false;
                        LoggerHelper.Warn("检测到虚拟机 vmware-vmx.exe 已关闭");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("自动初始化内存模块发生异常", ex);
            }

        //////////////////////////////////////////

        SLEEP:
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    /// 运行HTTP WebAPI服务器线程
    /// </summary>
    private void RunWebApiServerThread()
    {
        var builder = WebApplication.CreateBuilder();

        ////////////////////////////////////////

        // 允许跨域
        builder.Services.AddCors(cros =>
        {
            cros.AddPolicy("AllowAllOrigins", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("V1", new OpenApiInfo
            {
                Version = "V1",
                Title = "战地1虚拟机API",
                Description = "以http形式从VMware虚拟机穿透获取战地1内存中数据，方便不同语言调用",
                Contact = new OpenApiContact()
                {
                    Name = "GitHub",
                    Url = new Uri("https://github.com/CrazyZhang666/BF1VMwareAPI")
                }
            });
            // 显示文档注释
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
        });

        ////////////////////////////////////////

        var app = builder.Build();

        app.UseCors("AllowAllOrigins");

        // http://127.0.0.1:10086/index.html
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/V1/swagger.json", "API版本 V1");
            options.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Use(async (context, next) =>
        {
            // 统计接口调用次数
            MainModel.VisitCount++;
            await next();
        });

        ////////////////////////////////////////

        app.Run(_apiHost);
    }

    /// <summary>
    /// 检查更新
    /// </summary>
    private async Task CheckUpdate()
    {
        LoggerHelper.Info("正在检测新版本中...");

        // 最多执行4次
        for (int i = 0; i <= 4; i++)
        {
            // 当第4次还是失败，终止程序
            if (i > 3)
            {
                LoggerHelper.Error("检测新版本失败，请检查网络连接");

                MainWinInstance.IsShowMaskLayer = true;
                _ = MessageBox.Show($"检测新版本失败，请检查网络连接", "网络错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                MainWinInstance.IsShowMaskLayer = false;
                return;
            }

            // 第1次不提示重试
            if (i > 0)
            {
                LoggerHelper.Warn($"检测新版本失败，开始第 {i} 次重试中...");
            }

            var webVersion = await CoreApi.GetWebUpdateVersion();
            if (webVersion is not null)
            {
                if (Globals.VersionInfo >= webVersion)
                {
                    LoggerHelper.Info($"恭喜，当前是最新版本 {Globals.VersionInfo}");
                    return;
                }

                LoggerHelper.Info($"发现最新版本，请前往GitHub下载最新版本 {webVersion}");

                MainWinInstance.IsShowMaskLayer = true;
                if (MessageBox.Show($"发现新版本 v{webVersion}，是否立即前往GitHub下载最新版本？", "发现新版本",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    ProcessHelper.OpenLink("https://github.com/CrazyZhang666/BF1VMwareAPI/releases");
                }
                MainWinInstance.IsShowMaskLayer = false;
                return;
            }
        }
    }

    /// <summary>
    /// 打开程序数据目录
    /// </summary>
    [RelayCommand]
    private void OpenAppDataFolder()
    {
        ProcessHelper.OpenDirectory(Globals.Dir_Default);
    }

    /// <summary>
    /// 显示主窗口
    /// </summary>
    [RelayCommand]
    private void ShowWindow()
    {
        this.Show();

        if (this.WindowState == WindowState.Minimized)
            this.WindowState = WindowState.Normal;

        this.Activate();
        this.Focus();
    }

    /// <summary>
    /// 退出程序
    /// </summary>
    [RelayCommand]
    private void ExitApp()
    {
        // 设置关闭标志
        _isCodeClose = true;
        this.Close();
    }
}