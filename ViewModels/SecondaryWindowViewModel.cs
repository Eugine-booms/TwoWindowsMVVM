using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;

namespace TwoWindowsMVVM.ViewModels;

internal class SecondaryWindowViewModel : ViewModelBase
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

	#region OpenMainWindowCommand
	private LambdaCommand? _openMainWindowCommand;
	public ICommand OpenMainWindowCommand => _openMainWindowCommand ??= new(OnOpenMainWindowCommandExecuted, () => true);

	private void OnOpenMainWindowCommandExecuted()
	{

	}
	#endregion

	#region ChangeToMainWindowCommand
	private LambdaCommand? _changeToMainWindowCommand;
	public ICommand ChangeToMainWindowCommand => _openMainWindowCommand ??= new(OnChangeToMainWindowCommandExecuted, () => true);

	private void OnChangeToMainWindowCommandExecuted()
	{

	}
	#endregion
	#endregion



}