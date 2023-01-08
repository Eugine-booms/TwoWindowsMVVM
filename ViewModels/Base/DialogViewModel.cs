using System;

namespace TwoWindowsMVVM.ViewModels;

internal class DialogViewModel : TitledViewModel
{
	public event EventHandler? DialogComplete;

	protected virtual void OnDialogComplete(EventArgs e)=> 
		DialogComplete?.Invoke(this, e);	
}
