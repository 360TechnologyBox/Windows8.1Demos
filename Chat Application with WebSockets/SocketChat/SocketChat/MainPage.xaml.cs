using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.Web;
using System.Threading;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238



namespace SocketChat
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

        public MessageWebSocket ws;
        public DataWriter dw;

        private async void btnSetUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ws = new MessageWebSocket();
                ws.Control.MessageType = SocketMessageType.Utf8;
                ws.MessageReceived += ws_MessageReceived;
                ws.Closed += ws_Closed;
                ws.Control.SupportedProtocols.Add("echo-protocol");                
                lstChatBox.Items.Add(ws.Information.Protocol.ToString());
                await ws.ConnectAsync(new Uri("ws://localhost:8080/"));
                
                dw = new DataWriter(ws.OutputStream);

                sendMessage(txtBoxUser.Text + " joined !");

            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();         
            }


        }

        void ws_Closed(IWebSocket sender, WebSocketClosedEventArgs args)
        {
            MessageWebSocket webSocket = Interlocked.Exchange(ref ws, null);
            if (webSocket != null)
            {
                webSocket.Dispose();
            }
        }

        async void ws_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            try
            {
                string read = "";
                using (DataReader reader = args.GetDataReader())
                {
                    reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                     read = reader.ReadString(reader.UnconsumedBufferLength);
                }

                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { lstChatBox.Items.Add(read); });


            }
            catch (Exception ex) 
            {
                WebErrorStatus status = WebSocketError.GetStatus(ex.GetBaseException().HResult);
                //handle errors
            }

             
        }
        
        
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
             sendMessage(txtBoxUser.Text + " : " +  txtBoxMessage.Text);
        }

        private async void sendMessage(string data)
        {
            dw.UnicodeEncoding = UnicodeEncoding.Utf8;
            dw.WriteString(data);
            await dw.StoreAsync();
        }


    }
}
