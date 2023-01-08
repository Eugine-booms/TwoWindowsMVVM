using System.Reflection;

namespace TwoWindowsMVVM.ViewModels;

internal class MainWindowViewModel: ViewModelBase
{
	public string Title { get; set; } = "Главное окно";
}