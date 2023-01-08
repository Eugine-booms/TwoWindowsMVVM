using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TwoWindowsMVVM.Services;
using TwoWindowsMVVM.ViewModels;

namespace TwoWindowsMVVM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

	private static IServiceProvider? _services;
	public static IServiceProvider? Services => _services ??= InitializingServices().BuildServiceProvider();

	private static IServiceCollection InitializingServices()
	{
		var services = new ServiceCollection();
		services.AddSingleton<MainWindowViewModel>();
		services.AddTransient<SecondaryWindowViewModel>();

		services.AddTransient<MainWindow>(s =>
		{
			var vm = s.GetRequiredService<MainWindowViewModel>();
			var window = new MainWindow { DataContext = vm };
			vm.DialogComplete += (_, _) => window.Close();
			return window;
		});
		services.AddTransient<SecondaryWindow>(s =>
		{
			var vm = s.GetRequiredService<SecondaryWindowViewModel>();
			var window = new SecondaryWindow { DataContext = vm };
			vm.DialogComplete += (_, _) => window.Close();
			return window;
		});

		services.AddSingleton<IUserDialog, UserDialogService>();
		return services;
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		Services.GetRequiredService<IUserDialog>().OpenMainWindow();
	}
}
