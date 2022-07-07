namespace OAuthTester.ViewModels;

public interface IWindowViewModel
{
    string Title { get; }
    bool? DialogResult { get; }
}