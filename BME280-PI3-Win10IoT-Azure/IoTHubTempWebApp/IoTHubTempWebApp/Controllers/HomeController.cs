using IoTHubTempWebApp.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IoTHubTempWebApp.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = "Endpoint=sb://iothubqueue-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=88kJcD1mvJnO1jtiiY+AcUtIoinW//V/lF2WicOJ50s=";
        private string queueName = "iothubqueue";
        private IHubContext _hubContext;

        public HomeController()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<IoTHub>();
        }

        public ActionResult Index()
        {
            Task task = Task.Run(() =>
            {

                QueueClient client = QueueClient.CreateFromConnectionString(connectionString, queueName, ReceiveMode.ReceiveAndDelete);

                client.OnMessage(message =>
                {
                    Stream stream = message.GetBody<Stream>();
                    StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                    string s = reader.ReadToEnd();
                    _hubContext.Clients.All.ioTHubNotification(s);

                });
            });

            task.Wait();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}