using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
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

		services.AddTransient<MainWindow>(s => new MainWindow { DataContext = s.GetRequiredService<MainWindowViewModel>() });
		services.AddTransient<SecondaryWindow>(s => new SecondaryWindow { DataContext = s.GetRequiredService<SecondaryWindowViewModel>() });
		return services;
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		Services.GetRequiredService<MainWindow>().Show();
	}
}
