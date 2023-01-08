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
	public static IServiceProvider? Services => _services??= InitializingServices().BuildServiceProvider();

	private static IServiceCollection InitializingServices()
	{
		var services = new ServiceCollection();
		services.AddSingleton<MainWindowViewModel>();
		services.AddTransient<SecondaryWindowViewModel>();
		return services;
	}
}
