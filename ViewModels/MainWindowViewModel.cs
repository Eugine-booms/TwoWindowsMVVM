using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;

namespace TwoWindowsMVVM.ViewModels;

internal class MainWindowViewModel: ViewModelBase
{
	public string Title { get; set; } = "Главное окно";

	private string? _message;

	public string? Message
	{
		get { return _message; }
		set { Set(ref _message, value); }
	}
	private readonly ObservableCollection<TextMessageModel> _messages = new();
	public IEnumerable<TextMessageModel> Messages => _messages;

	#region commamds
	#region SendMessageCommand
	private LambdaCommand? _sendMessageCommand;
	public ICommand SendMessageCommand => _sendMessageCommand ??= new(OnSendMessageCommandExecute, prop => prop is string { Length: > 0 });

	private void OnSendMessageCommandExecute(object? p)
	{

	}
	#endregion

	#region OpenSecondWindowCommand
	private LambdaCommand? _openSecondWindowCommand;
	public ICommand OpenSecondWindowCommand => _openSecondWindowCommand ??= new(OnOpenSecondWindowCommandExecuted, ()=>true);

	private void OnOpenSecondWindowCommandExecuted()
	{

	}
	#endregion

	#region ChangeToSecondWindowCommand
	private LambdaCommand? _changeToSecondWindowCommand;
	public ICommand ChangeToSecondWindowCommand => _openSecondWindowCommand ??= new(OnChangeToSecondWindowCommandExecuted, () => true);

	private void OnChangeToSecondWindowCommandExecuted()
	{

	}
	#endregion
	#endregion



}