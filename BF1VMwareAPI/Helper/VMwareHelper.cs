namespace BF1VMwareAPI.Helper;

public static class VMwareHelper
{
    /// <summary>
    /// 从注册表获取 VMware 安装路径
    /// </summary>
    public static string GetVMwareInstallPath()
    {
        var regPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\vmware.exe";
        return RegistryHelper.GetRegistryTargetVaule(regPath, "path");
    }

    /// <summary>
    /// 获取 vmrun.exe list 返回结果
    /// </summary>
    public static async Task<string> GetVmRunExeCmdList()
    {
        var result = await ProcessHelper.GetCmdProcessResult(Globals.VmRunExePath, "list");
        // 获取完成后去除首尾空白
        result = result.Trim();
        if (string.IsNullOrWhiteSpace(result))
            return string.Empty;

        LoggerHelper.Trace($"GetVmRunExeCmdList 返回结果为: {result}");

        // 按照换行符拆分字符串
        // "Total running VMs: 0\r\n"
        var strArray = result.Split(Environment.NewLine);

        LoggerHelper.Trace($"GetVmRunExeCmdList 返回结果拆分数量为: {strArray.Length}");

        // 说明未检测到虚拟机
        if (strArray.Length == 1)
            return string.Empty;
        // 已经检测到一个及其以上的虚拟机，我们只需要第一个
        if (strArray.Length >= 2)
            return strArray[1];

        return string.Empty;
    }

    /// <summary>
    /// 获取 vmrun.exe checkToolsState 返回结果
    /// </summary>
    public static async Task<string> GetVmRunExeCmdCheckToolsState(string vmxPath)
    {
        var result = await ProcessHelper.GetCmdProcessResult(Globals.VmRunExePath, $"checkToolsState \"{vmxPath}\"");
        // 获取完成后去除首尾空白
        result = result.Trim();
        if (string.IsNullOrWhiteSpace(result))
            return string.Empty;

        LoggerHelper.Trace($"GetVmRunExeCmdCheckToolsState 返回结果为: {result}");

        return result;
    }

    /// <summary>
    /// 获取第一个 VMware 虚拟机是否已经完全运行
    /// </summary>
    public static async Task<bool> GetFirstVMwareIsFullRunnig()
    {
        var vmxPath = await GetVmRunExeCmdList();
        if (string.IsNullOrWhiteSpace(vmxPath))
            return false;

        var result = await GetVmRunExeCmdCheckToolsState(vmxPath);
        if (string.IsNullOrWhiteSpace(result))
            return false;

        if (result.Equals("running", StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}