using System;
using System.Windows.Input;

namespace OAuthTester.ViewModels.Commands;

public class DelegateCommand : ICommand
{
    private readonly Func<object?, bool>? _canExecute;
    private readonly Action<object?> _execute;

    public DelegateCommand(Action<object?> execute)
    {
        _execute = execute;
        _canExecute = null;
    }

    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanExecute(object? parameter)
    {
        if (_canExecute != null)
        {
            return _canExecute(parameter);
        }

        return true;
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}