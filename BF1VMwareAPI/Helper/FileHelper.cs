namespace BF1VMwareAPI.Helper;

public static class FileHelper
{
    /// <summary>
    /// 创建文件夹
    /// </summary>
    public static void CreateDirectory(string dirPath)
    {
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
    }
}