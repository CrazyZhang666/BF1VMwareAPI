namespace ModernWpf.Controls;

public class IconStateCard : Control
{
    /// <summary>
    /// Icon图标
    /// </summary>
    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(IconStateCard), new PropertyMetadata(default));

    /// <summary>
    /// Icon图标大小
    /// </summary>
    public double IconSize
    {
        get { return (double)GetValue(IconSizeProperty); }
        set { SetValue(IconSizeProperty, value); }
    }
    public static readonly DependencyProperty IconSizeProperty =
        DependencyProperty.Register("IconSize", typeof(double), typeof(IconStateCard), new PropertyMetadata(default));

    /// <summary>
    /// 标题文本
    /// </summary>
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(IconStateCard), new PropertyMetadata(default));

    /// <summary>
    /// 内容文本
    /// </summary>
    public string Content
    {
        get { return (string)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(string), typeof(IconStateCard), new PropertyMetadata(default));
}