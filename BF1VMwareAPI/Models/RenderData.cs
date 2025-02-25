namespace BF1VMwareAPI.Models;

public class RenderData
{
    public int FrameCounter { get; set; }
    public int FramesInProgress { get; set; }
    public int FramesInProgress2 { get; set; }
    public bool IsActive { get; set; }
    public bool IsTopWindow { get; set; }
    public bool IsMinimized { get; set; }
    public bool IsMaximized { get; set; }
    public bool IsResizing { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string AdapterName { get; set; }
}