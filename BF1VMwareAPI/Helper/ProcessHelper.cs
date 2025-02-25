namespace BF1VMwareAPI.Helper;

public static class ProcessHelper
{
    /// <summary>
    /// 打开http链接
    /// </summary>
    public static void OpenLink(string url)
    {
        if (!url.StartsWith("http"))
        {
            LoggerHelper.Warn($"链接不是http格式 {url}");
            return;
        }

        try
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"打开http链接发生异常 {url}", ex);
        }
    }

    /// <summary>
    /// 打开文件夹路径
    /// </summary>
    public static void OpenDirectory(string dirPath)
    {
        if (!Directory.Exists(dirPath))
        {
            LoggerHelper.Warn($"文件夹路径不存在 {dirPath}");
            return;
        }

        try
        {
            Process.Start(new ProcessStartInfo(dirPath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"打开文件夹异常 {dirPath}", ex);
        }
    }

    /// <summary>
    /// 运行控制台程序并获取返回结果
    /// </summary>
    public static async Task<string> GetCmdProcessResult(string cmdPath, string args)
    {
        try
        {
            var cmdProcess = new Process();

            cmdProcess.StartInfo.FileName = cmdPath;
            cmdProcess.StartInfo.Arguments = args;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardError = true;
            // 避免路径带中文导致乱码
            cmdProcess.StartInfo.StandardInputEncoding = Encoding.UTF8;
            cmdProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            cmdProcess.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            cmdProcess.Start();

            cmdProcess.StandardInput.AutoFlush = true;
            cmdProcess.StandardInput.Close();

            var output = cmdProcess.StandardOutput.ReadToEnd();
            cmdProcess.StandardOutput.Close();

            await cmdProcess.WaitForExitAsync();

            cmdProcess.Close();
            cmdProcess.Dispose();

            return output;
        }
        catch (Exception ex)
        {
            LoggerHelper.Error("运行控制台程序发生异常", ex);
            return string.Empty;
        }
    }
}