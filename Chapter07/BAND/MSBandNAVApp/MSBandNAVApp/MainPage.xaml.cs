//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices.WindowsRuntime;
//using Windows.Foundation;
//using Windows.Foundation.Collections;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Controls.Primitives;
//using Windows.UI.Xaml.Data;
//using Windows.UI.Xaml.Input;
//using Windows.UI.Xaml.Media;
//using Windows.UI.Xaml.Navigation;

//// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

//namespace MSBandNAVApp
//{
//    /// <summary>
//    /// An empty page that can be used on its own or navigated to within a Frame.
//    /// </summary>
//    public sealed partial class MainPage : Page
//    {
//        public MainPage()
//        {
//            this.InitializeComponent();
//        }
//    }
//}



using Microsoft.Band;
using Windows.UI.Xaml.Controls;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Band.Sensors;
using System.Text;
//using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

//LINK riferimento: http://peted.azurewebsites.net/microsoft-band-heart-rate-sample-uwp/


namespace MSBandNAVApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IBandClient _bandClient;
        private IBandInfo _bandInfo;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GetHeartRate();
        }

        private void btnCheck_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GetHeartRate();
        }



        //Reads the fitness data from the Band
        private async void GetHeartRate()
        {
            if (_bandClient != null)
                return;

            var bands = await BandClientManager.Instance.GetBandsAsync();
            _bandInfo = bands.First();

            _bandClient = await BandClientManager.Instance.ConnectAsync(_bandInfo);

            var uc = _bandClient.SensorManager.HeartRate.GetCurrentUserConsent();
            bool isConsented = false;
            if (uc == UserConsent.NotSpecified)
            {
                isConsented = await _bandClient.SensorManager.HeartRate.RequestUserConsentAsync();
            }

            if (isConsented || uc == UserConsent.Granted)
            {
                _bandClient.SensorManager.HeartRate.ReadingChanged += async (obj, ev) =>
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        HeartRateDisplay.Text = ev.SensorReading.HeartRate.ToString();
                    });
                };
                await _bandClient.SensorManager.HeartRate.StartReadingsAsync();

                //Here we can call the NAV Service Layer REST API to pass the heart rate data
            }
        }

        
    }
}

