using System;
using System.Windows.Input;

namespace TwoWindowsMVVM.Commands
{
	internal abstract class Command : ICommand
	{
		protected virtual bool CanExecute(object? p) => true;
		protected abstract void Execute (object? p);

		bool ICommand.CanExecute(object? parameter) => 
			CanExecute(parameter);

		void ICommand.Execute(object? parameter)
		{
			if (((ICommand)this).CanExecute(parameter))
				Execute (parameter);
		}

		event EventHandler? ICommand.CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}
