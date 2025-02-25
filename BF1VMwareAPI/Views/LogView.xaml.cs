using BF1VMwareAPI.Extend;
using BF1VMwareAPI.Helper;
using BF1VMwareAPI.Models;
using NLog;
using NLog.Common;

namespace BF1VMwareAPI.Views;

/// <summary>
/// LogView.xaml 的交互逻辑
/// </summary>
public partial class LogView : UserControl
{
    public ObservableCollection<LogInfo> ObsCol_LogInfos { get; set; } = new();

    private const int _maxRowCount = 100;

    public LogView()
    {
        InitializeComponent();

        ToDoList();
    }

    private void ToDoList()
    {
        LoggerHelper.PreHeat();

        if (!DesignerProperties.GetIsInDesignMode(this))
        {
            var targetResult = LogManager.Configuration.AllTargets
                .Where(t => t is NlogViewerTarget).Cast<NlogViewerTarget>();

            foreach (var target in targetResult)
            {
                target.LogReceived += LogReceived;
            }
        }
    }

    /// <summary>
    /// 处理日志接收事件
    /// </summary>
    private void LogReceived(AsyncLogEventInfo logEventInfo)
    {
        var logEvent = logEventInfo.LogEvent;

        this.Dispatcher.BeginInvoke(() =>
        {
            if (_maxRowCount > 0 && ObsCol_LogInfos.Count > _maxRowCount)
                ObsCol_LogInfos.RemoveAt(0);

            var item = new LogInfo()
            {
                Time = logEvent.TimeStamp.ToString("HH:mm:ss"),
                Level = logEvent.Level.Name,
                Message = $"{logEvent.Message} {logEvent.Exception?.Message}"
            };

            ObsCol_LogInfos.Add(item);

            // 滚动最后一行
            ScrollToLast();
        });
    }

    /// <summary>
    /// 日志滚动到最后一行
    /// </summary>
    private void ScrollToLast()
    {
        if (ListView_Logger.Items.Count <= 0)
            return;

        ListView_Logger.SelectedIndex = ListView_Logger.Items.Count - 1;
        ListView_Logger.ScrollIntoView(ListView_Logger.SelectedItem);
    }

    /// <summary>
    /// 重新设置日志等级
    /// </summary>
    private void RadioButton_LogLevel_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton radioButton)
            return;

        if (radioButton.Content is null)
            return;

        switch (radioButton.Content.ToString())
        {
            case "Trace":
                LoggerHelper.ResetMinLogLevel(LogLevel.Trace);
                break;
            case "Debug":
                LoggerHelper.ResetMinLogLevel(LogLevel.Debug);
                break;
            case "Info":
                LoggerHelper.ResetMinLogLevel(LogLevel.Info);
                break;
            case "Warn":
                LoggerHelper.ResetMinLogLevel(LogLevel.Warn);
                break;
            case "Error":
                LoggerHelper.ResetMinLogLevel(LogLevel.Error);
                break;
            case "Fatal":
                LoggerHelper.ResetMinLogLevel(LogLevel.Fatal);
                break;
        }
    }
}