using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace _24._06NP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int port = 12345;
        static string address = "192.168.1.68";
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public MainWindow()
        {
            InitializeComponent();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            socket.Connect(ipPoint);
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(ListenServer);
            thread.Start();
        }

        private void ListenServer()
        {
            string message = "";
            Dispatcher.Invoke(new ThreadStart(() => message = PostIndexTextBox.Text));

            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);

            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);

            Dispatcher.Invoke(new ThreadStart(() => StreetsTextBox.Text = builder.ToString()));
        }
    }
}
