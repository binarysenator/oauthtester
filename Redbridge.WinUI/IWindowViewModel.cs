namespace Redbridge.WinUI;

public interface IWindowViewModel
{
    string Title { get; }
    bool? DialogResult { get; }
}