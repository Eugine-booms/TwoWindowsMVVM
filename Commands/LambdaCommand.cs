using System;

namespace TwoWindowsMVVM.Commands
{
	internal class LambdaCommand : Command
	{
		private readonly Delegate? _execute;
		private readonly Delegate? _canExecute;

		public LambdaCommand(Action<object?> execute, Func<bool>? canExecute = null)
		{
			_execute= execute;
			_canExecute = canExecute;
		}
		public LambdaCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public LambdaCommand(Action execute, Func<bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
		public LambdaCommand(Action execute, Func<object?, bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		protected override bool CanExecute(object? p)
		{
			if (!base.CanExecute(p)) return false;
			return _canExecute switch
			{
				null							=> true,
				Func<bool> can_exec				=> can_exec(),
				Func<object?, bool> can_exec	=> can_exec(p),
				_								=> throw new InvalidOperationException($"Тип делегата {_canExecute.GetType()} не поддерживается коммандой")
			};
		}

		protected override void Execute(object? p)
		{
			switch (_execute)
			{
				default: 						throw new InvalidOperationException($"Тип делегата {_execute.GetType()} не поддерживается коммандой");
				case null:						throw new InvalidOperationException("Не указан делегат вызова команды");
				case Action execute:			execute(); break;
				case Action<object?> exicute:	exicute(p); break;
					 
						
			}
		}
	}

	internal class LambdaCommand<T> : Command
	{
		private readonly Delegate? _execute;
		private readonly Delegate? _canExecute;

		public LambdaCommand(Action<T?> execute, Func<bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
		public LambdaCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public LambdaCommand(Action execute, Func<bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
		public LambdaCommand(Action execute, Func<T?, bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}


		protected override bool CanExecute(object? p)
		{
			if (!base.CanExecute(p))
				return false;
			return _canExecute switch
			{
				null => true,
				Func<bool> can_exec => can_exec(),
				Func<T?, bool> can_exec => can_exec((T?)Convert.ChangeType( p, typeof(T))),
				_ => throw new InvalidOperationException($"Тип делегата {_canExecute.GetType()} не поддерживается коммандой")
			};
		}

		protected override void Execute(object? p)
		{
			switch (_execute)
			{
				default:						throw new InvalidOperationException($"Тип делегата {_execute.GetType()} не поддерживается коммандой");
				case null:						throw new InvalidOperationException("Не указан делегат вызова команды");
				case Action execute:			execute();	break;
				case Action<object?> exicute:	exicute((T?)Convert.ChangeType( p, typeof(T)));	break;


			}
		}
	}
}
