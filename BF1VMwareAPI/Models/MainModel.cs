using CommunityToolkit.Mvvm.ComponentModel;

namespace BF1VMwareAPI.Models;

public partial class MainModel : ObservableObject
{
    [ObservableProperty]
    private bool isVmmInitOK;

    [ObservableProperty]
    private bool isBf1InitOK;

    [ObservableProperty]
    private ulong visitCount;

    [ObservableProperty]
    private string runningTime;
}