using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Placeholder;

internal class RelayCommand<T> : ICommand
{
    private readonly Action<T> mExecute = null;
    private readonly Predicate<T> mCanExecute = null;

    public RelayCommand(Action<T> execute)
      : this(execute, null)
    {
    }

    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
        if (execute == null)
            throw new ArgumentNullException("execute");

        this.mExecute = execute;
        this.mCanExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add
        {
            if (this.mCanExecute != null)
                CommandManager.RequerySuggested += value;
        }

        remove
        {
            if (this.mCanExecute != null)
                CommandManager.RequerySuggested -= value;
        }
    }

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return this.mCanExecute == null ? true : this.mCanExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        this.mExecute((T)parameter);
    }
}

internal class RelayCommand : ICommand
{
    private readonly Action mExecute;
    private readonly Func<bool> mCanExecute;

    public RelayCommand(Action execute)
      : this(execute, null)
    {
    }

    public RelayCommand(RelayCommand inputRC)
      : this(inputRC.mExecute, inputRC.mCanExecute)
    {
    }

    public RelayCommand(Action execute, Func<bool> canExecute)
    {
        if (execute == null)
            throw new ArgumentNullException("execute");

        this.mExecute = execute;
        this.mCanExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add
        {
            if (this.mCanExecute != null)
                CommandManager.RequerySuggested += value;
        }

        remove
        {
            if (this.mCanExecute != null)
                CommandManager.RequerySuggested -= value;
        }
    }

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return this.mCanExecute == null ? true : this.mCanExecute();
    }

    public void Execute(object parameter)
    {
        this.mExecute();
    }
}
