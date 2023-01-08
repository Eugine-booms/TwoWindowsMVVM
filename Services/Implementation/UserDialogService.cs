using Microsoft.Extensions.DependencyInjection;
using System;

namespace TwoWindowsMVVM.Services
{
	internal class UserDialogService : IUserDialog
	{
		private readonly IServiceProvider _services;


		public UserDialogService(IServiceProvider services)
		{
			this._services = services;
		}

		private MainWindow? _mainWindow;


		public void OpenMainWindow()
		{
			if (_mainWindow is { } window)
			{
				window.Show();
				return;
			}
			_mainWindow = _services.GetRequiredService<MainWindow>();
			_mainWindow.Closed += (_, _) => _mainWindow = null;
			_mainWindow.Show();
		}
		private SecondaryWindow? _secondaryWindow;
		public void OpenSecondaryWindow()
		{
			if (_secondaryWindow is { } window)
			{
				window.Show();
				return;
			}
			_secondaryWindow = _services.GetRequiredService<SecondaryWindow>();
			_secondaryWindow.Closed += (_, _) => _secondaryWindow = null;
			_secondaryWindow.Show();
		}
	}
}
