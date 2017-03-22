using DeviceLocation.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DeviceLocation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnTransmitLocation_Click(object sender, RoutedEventArgs e)
        {
            var geoLocator = new Geolocator();
            geoLocator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition pos = await geoLocator.GetGeopositionAsync();
            string latitude = "Latitude: " + pos.Coordinate.Point.Position.Latitude.ToString();
            string longitude = "Longitude: " + pos.Coordinate.Point.Position.Longitude.ToString();

            MissionTicket mission = new MissionTicket();
            mission.Code = ((MissionTicket)cmbMissions.SelectedValue).Code;
            mission.Date = DateTime.Now;
            mission.Status = (string)cmbStatuss.SelectedValue;
            mission.Latitude = pos.Coordinate.Point.Position.Latitude;
            mission.Longitude = pos.Coordinate.Point.Position.Longitude;
            mission.Note = txtNote.Text;
            try
            {
                //Makes an HTTP POST to the WEB API service
                var httpClient = new HttpClient();
                var uri = new Uri("http://localhost:54691/api/Missions/AddMission");
                var json = JsonConvert.SerializeObject(mission);
                var response = await httpClient.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                //Handle exception here...
            }
        }

        private async void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //These data will come by calling the REST service            
            var uri = new Uri("http://localhost:54691/api/Missions/GetMissionsForUserID/stefano");
            var httpClient = new HttpClient();

            // Always catch network exceptions for async methods
            string result=String.Empty;
            List<MissionTicket> model = null;
            try
            {
                result = await httpClient.GetStringAsync(uri);
                //Here we have to serialize the JSON object to a list of Mission objects
                model = JsonConvert.DeserializeObject<List<MissionTicket>>(result);
            }
            catch(Exception ex)
            {
                string dett = ex.Message;    
            }
            
            // Once your app is done using the HttpClient object call dispose to 
            // free up system resources (the underlying socket and memory used for the object)
            httpClient.Dispose();

            //Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            //Assign the ItemsSource to the List.
            comboBox.ItemsSource = model;

            //Make the first item selected as default.
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the ComboBox.
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
        }

        private void cmbStatus_Loaded(object sender, RoutedEventArgs e)
        {
            //Fixed values
            List<string> data = new List<string>();
            data.Add("Started");
            data.Add("In Progress");
            data.Add("Delivered");

            //Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            //Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            //Make the first item selected as default.
            comboBox.SelectedIndex = 0;
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
        }
    }
}
