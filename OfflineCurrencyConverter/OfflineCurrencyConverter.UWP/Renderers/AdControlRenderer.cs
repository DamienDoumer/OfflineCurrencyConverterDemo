using Microsoft.Advertising.WinRT.UI;
using OfflineCurrencyConverter.UWP.Renderers;
using OfflineCurrencyConverter.Views.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyAdControl), typeof(AdControlRenderer))]
namespace OfflineCurrencyConverter.UWP.Renderers
{
    public class AdControlRenderer : ViewRenderer<MyAdControl, AdControl>
    {

<<<<<<< HEAD
        string bannerId = "dasfadf";
        AdControl adView;
=======
        //string bannerId = "1100030501";
        string bannerId = "dasfadf";
        AdControl adView;
        //string applicationID = "9n9205db10t1";
>>>>>>> 1948cc2fb01ecba111675272d5f13a0034c03987
        string applicationID = "fasre";
        void CreateNativeAdControl()
        {
            if (adView != null)
                return;

            var width = 300;
            var height = 50;
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
            {
                width = 500;
                height = 90;
            }

            // Setup your BannerView, review AdSizeCons class for more Ad sizes. 
            adView = new AdControl
            {
                ApplicationId = applicationID,
                AdUnitId = bannerId,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom,
                Width = width,
                Height = height
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyAdControl> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}
