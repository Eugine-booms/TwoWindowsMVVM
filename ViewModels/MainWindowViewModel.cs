using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;
using TwoWindowsMVVM.Services;

namespace TwoWindowsMVVM.ViewModels;

internal class MainWindowViewModel: DialogViewModel
{
	private string? _message;
	private readonly ObservableCollection<TextMessageModel> _messages = new();
	private readonly IUserDialog _userDialog;

	public string? Message
	{
		get { return _message; }
		set { Set(ref _message, value); }
	}
	public IEnumerable<TextMessageModel> Messages => _messages;
	
	
	

	#region ctor
	public MainWindowViewModel()
	{
		Title = "Главное окно";
	}
	public MainWindowViewModel(IUserDialog userDialog): this()
	{
		this._userDialog = userDialog;
	}

	#endregion

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
		_userDialog.OpenSecondaryWindow();
	}
	#endregion

	#region ChangeToSecondWindowCommand
	private LambdaCommand? _changeToSecondWindowCommand;

	

	public ICommand ChangeToSecondWindowCommand => _changeToSecondWindowCommand ??= new(OnChangeToSecondWindowCommandExecuted, () => true);

	private void OnChangeToSecondWindowCommandExecuted()
	{
		_userDialog.OpenSecondaryWindow();
		OnDialogComplete(EventArgs.Empty);
	}
	#endregion
	#endregion



}