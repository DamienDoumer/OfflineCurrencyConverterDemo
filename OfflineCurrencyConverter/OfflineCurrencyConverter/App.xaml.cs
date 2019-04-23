using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using OfflineCurrencyConverter.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace OfflineCurrencyConverter
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // Initialize Live Reload.
<<<<<<< HEAD
//#if DEBUG
//            LiveReload.Init();
//#endif
=======
#if DEBUG
            LiveReload.Init();
#endif
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
            new AppLocator();
            MainPage = (new MainPage());
		}

		protected override void OnStart ()
		{
<<<<<<< HEAD
            AppCenter.Start("ios=;" +
                "uwp=;" +
=======
            AppCenter.Start("ios=" +
                "uwp=" +
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
                "android=", typeof(Analytics), typeof(Crashes));
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
