using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using Microsoft.Azure.Devices.Client;
using BuildAzure.IoT.Adafruit.BME280;

namespace IoTWeatherHub
{
    public sealed partial class MainPage : Page
    {
        private DeviceClient deviceClient;
        private string iotHubUri = "piiothub.azure-devices.net";
        private string deviceKey = "Tj60asOk5ffVAT6a6SvZKMOqo8DYKSwWV7eQ2pLf0/k=";
        private BME280Sensor _sensor;

        public MainPage()
        {
            //this.InitializeComponent();
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("raspberrypi2", deviceKey), TransportType.Mqtt);
            _sensor = new BME280Sensor();
            DeviceToCloudMessage();
        }

        private async void DeviceToCloudMessage()
        {
            await _sensor.Initialize();

            float temperature = 0.00f;
            float humidity = 0.00f;

            while (true)
            {
                temperature = await _sensor.ReadTemperature();
                humidity = await _sensor.ReadHumidity();

                var telemetryDataPoint = new
                {
                    date = String.Format("{0}, {1}, {2}",
                                         DateTime.Now.ToLocalTime().TimeOfDay.Hours,
                                         DateTime.Now.ToLocalTime().TimeOfDay.Minutes,
                                         DateTime.Now.ToLocalTime().TimeOfDay.Seconds),
                    temp = Math.Round(temperature, 2),
                    humid = Math.Round(humidity, 2)
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                await deviceClient.SendEventAsync(message);
                Debug.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                Task.Delay(5000).Wait();
            }
        }
    }
}
