using ListViewWithSubListView.ViewModels;
using ListViewWithSubListView.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ListViewWithSubListView
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Hotels(new HotelsGroupViewModel());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
