using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;
using TwoWindowsMVVM.Services;

namespace TwoWindowsMVVM.ViewModels;

internal class SecondaryWindowViewModel : ViewModelBase
{
	
	private readonly ObservableCollection<TextMessageModel> _messages = new();
	private readonly IUserDialog _userDialog;
	private string? _message;

	#region ctor
	public SecondaryWindowViewModel()
	{
		Title =  "Вторичное окно";
	}
	public SecondaryWindowViewModel(IUserDialog userDialog):this() 
	{
		this._userDialog = userDialog;
	}

	#endregion

	public string? Message
	{
		get { return _message; }
		set { Set(ref _message, value); }
	}
	public string Title { get; set; }
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
		_userDialog.OpenMainWindow();
	}
	#endregion

	#region ChangeToMainWindowCommand
	private LambdaCommand? _changeToMainWindowCommand;
	public ICommand ChangeToMainWindowCommand => _openMainWindowCommand ??= new(OnChangeToMainWindowCommandExecuted, () => true);

	private void OnChangeToMainWindowCommandExecuted()
	{
		_userDialog.OpenMainWindow();

	}
	#endregion
	#endregion



}