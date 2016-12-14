using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (textBoxLocalPort.Enabled == true)
            {
                int RemotePortNum, LocalPortNum;
                IPAddress RemoteIP;
                try
                {
                    RemotePortNum = Int32.Parse(textBoxRemortPort.Text);
                    if (RemotePortNum < 1024 || RemotePortNum > 65535)
                        throw new ArgumentOutOfRangeException("LocalPortNum", RemotePortNum, "有效的端口号是1024-65535");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的远程端口号有误，请重新输入。" + Environment.NewLine + ex);
                    return;
                }
                try
                {
                    RemoteIP = IPAddress.Parse(textBoxRemoteIP.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的远程IP有误，请重新输入。" + Environment.NewLine + ex);
                    return;
                }
                try
                {
                    LocalPortNum = Int32.Parse(textBoxLocalPort.Text);
                    if (LocalPortNum < 1024 || LocalPortNum > 65535)
                        throw new ArgumentOutOfRangeException("LocalPortNum", LocalPortNum, "有效的端口号是1024-65535");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的本地端口号有误，请重新输入。" + Environment.NewLine + ex);
                    return;
                }
                try
                {
                    StartConnect(RemotePortNum, LocalPortNum, RemoteIP);
                    textBoxLocalPort.Enabled = false;
                    textBoxRemoteIP.Enabled = false;
                    textBoxRemortPort.Enabled = false;
                    buttonConnect.Text = "断开";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TCPClient启动失败" + Environment.NewLine + ex);
                }
            }
            else
            {
                Disconnect();
                SetEnableMessage(false);
                textBoxLocalPort.Enabled = true;
                textBoxRemoteIP.Enabled = true;
                textBoxRemortPort.Enabled = true;
                buttonConnect.Text = "连接";
            }
        }

        private void Disconnect()
        {
            if (tcpClient != null)
                tcpClient.Close();
            if (networkStream != null)
                networkStream.Dispose();
        }

        TcpClient tcpClient;
        NetworkStream networkStream;
        private void StartConnect(int remotePortNum, int LocalPortNum, IPAddress RemoteIP)
        {
            tcpClient = new TcpClient(new IPEndPoint(IPAddress.Parse("0.0.0.0"), LocalPortNum));
            tcpClient.BeginConnect(RemoteIP, remotePortNum, new AsyncCallback(Connect), tcpClient);
        }

        private void Connect(IAsyncResult ar)
        {
            tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.EndConnect(ar);
            SetEnableMessage(true);

            networkStream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int n;
            while ((n = networkStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string TextToAdd = "Resived at 【{0}】, from 【{1}】" + Environment.NewLine + Encoding.ASCII.GetString(buffer, 0, n) + Environment.NewLine;
                TextToAdd = TextToAdd.Replace("{0}", DateTime.Now.ToString());
                TextToAdd = TextToAdd.Replace("{1}", ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString());
                TextBoxMessageHistory_AddText(TextToAdd);
            }
            networkStream.Dispose();
            tcpClient.Close();
        }
        delegate void SetEnableMessage_Callback(bool enable);
        private void SetEnableMessage(bool enable)
        {
            if (textBoxRemortPort.InvokeRequired)
            {
                SetEnableMessage_Callback d = new SetEnableMessage_Callback(SetEnableMessage);
                this.Invoke(d, new object[] { enable });
            }
            else
            {
                buttonSendMessage.Enabled = enable;
                textBoxMessageHistory.Enabled = enable;
                textBoxMessageToSend.Enabled = enable;
            }
        }

        delegate void TextBoxMessageHistory_AddText_Callback(string text);
        private void TextBoxMessageHistory_AddText(string Text)
        {
            if (textBoxMessageHistory.InvokeRequired)
            {
                TextBoxMessageHistory_AddText_Callback d = new TextBoxMessageHistory_AddText_Callback(TextBoxMessageHistory_AddText);
                this.Invoke(d, new object[] { Text });
            }
            else
            {
                textBoxMessageHistory.AppendText(Text);
                textBoxMessageHistory.ScrollToCaret();
            }
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (textBoxMessageToSend.Text.Equals(""))
                return;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(textBoxMessageToSend.Text);
            networkStream.Write(msg, 0, msg.Length);
            string TextToAdd = "Send at 【{0}】, to 【{1}】" + Environment.NewLine + textBoxMessageToSend.Text + Environment.NewLine;
            TextToAdd = TextToAdd.Replace("{0}", DateTime.Now.ToString());
            TextToAdd = TextToAdd.Replace("{1}", ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString());
            TextBoxMessageHistory_AddText(TextToAdd);
            textBoxMessageToSend.Text = "";
        }
    }
}
