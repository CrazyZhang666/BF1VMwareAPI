namespace BF1VMwareAPI.Helper;

public static class RegistryHelper
{
    /// <summary>
    /// 读取注册表
    /// </summary>
    public static string GetRegistryTargetVaule(string regPath, string keyName)
    {
        try
        {
            var localMachine = Registry.LocalMachine;

            using var regKey = localMachine.OpenSubKey(regPath);
            if (regKey is null)
                return string.Empty;

            return regKey.GetValue(keyName).ToString();
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"读取注册表异常 {regPath} {keyName}", ex);
            return string.Empty;
        }
    }
}