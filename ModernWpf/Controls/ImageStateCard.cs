namespace ModernWpf.Controls;

public class ImageStateCard : Control
{
    /// <summary>
    /// 标题图片
    /// </summary>
    public ImageSource Source
    {
        get { return (ImageSource)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }
    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageStateCard), new PropertyMetadata(default));

    /// <summary>
    /// 标题文本
    /// </summary>
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(ImageStateCard), new PropertyMetadata(default));

    /// <summary>
    /// 内容文本
    /// </summary>
    public string Content
    {
        get { return (string)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(string), typeof(ImageStateCard), new PropertyMetadata(default));
}