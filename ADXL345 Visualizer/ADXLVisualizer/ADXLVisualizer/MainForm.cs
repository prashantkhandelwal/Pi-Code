using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ADXLVisualizer
{
    public partial class MainForm : Form
    {
        public ChartValues<ObservableValue> Values_X { get; set; }
        public ChartValues<ObservableValue> Values_Y { get; set; }
        public ChartValues<ObservableValue> Values_Z { get; set; }

        Socket server;
        IPEndPoint ipEndPoint;
        byte[] data;

        public MainForm()
        {
            InitializeComponent();

            data = new byte[1024];

            ipEndPoint = new IPEndPoint(
                            IPAddress.Parse("192.168.1.8"), 50007);

            server = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipEndPoint);
            }
            catch (SocketException)
            {
                MessageBox.Show("Unable to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ADXLViz.LegendLocation = LegendLocation.Right;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Values_X = new ChartValues<ObservableValue>();
            Values_Y = new ChartValues<ObservableValue>();
            Values_Z = new ChartValues<ObservableValue>();
          
            ADXLViz.Series.Add(new LineSeries
            {
                Values = Values_X,
                Title = "X",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true
            });

            ADXLViz.Series.Add(new LineSeries
            {
                Values = Values_Y,
                Title = "Y",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true
            });

            ADXLViz.Series.Add(new LineSeries
            {
                Values = Values_Z,
                Title = "Z",
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string stringData;
            server.Send(Encoding.ASCII.GetBytes("adxl"));
            data = new byte[1024];
            int recv = server.Receive(data);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            string[] adxl = stringData.Replace(" ", "").Split('|');

            Values_X.Add(new ObservableValue(Convert.ToDouble(adxl[0].Split(':')[1])));
            Values_Y.Add(new ObservableValue(Convert.ToDouble(adxl[1].Split(':')[1])));
            Values_Z.Add(new ObservableValue(Convert.ToDouble(adxl[2].Split(':')[1])));

            if (Values_X.Count > 10) Values_X.RemoveAt(0);
            if (Values_Y.Count > 10) Values_Y.RemoveAt(0);
            if (Values_Z.Count > 10) Values_Z.RemoveAt(0);

            X_Label.Text = Convert.ToString(adxl[0].Split(':')[1]);
            Y_Label.Text = Convert.ToString(adxl[1].Split(':')[1]);
            Z_Label.Text = Convert.ToString(adxl[2].Split(':')[1]);
        }
    }
}
