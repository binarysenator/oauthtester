namespace Redbridge.WinUI;

public abstract class WindowViewModel : ViewModel, IWindowViewModel
{
    public abstract string Title { get; }
    public bool? DialogResult { get; protected set; }
}