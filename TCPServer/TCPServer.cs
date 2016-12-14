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

namespace TCPServer
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            if (textBoxLocalPort.Enabled == true)
            {
                int LocalPortNum;
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
                    StartListening(LocalPortNum);
                    textBoxLocalPort.Enabled = false;
                    buttonListen.Text = "停止";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TCPServer启动失败" + Environment.NewLine + ex);
                }
            }
            else
            {
                StopListening();
                SetRemotePortNumTextAndEnableMessage("", false);
                textBoxLocalPort.Enabled = true;
                buttonListen.Text = "监听";
            }
        }
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream networkStream;

        private void StopListening()
        {
            if (tcpListener != null)
                tcpListener.Stop();
            if (tcpClient != null)
                tcpClient.Close();
            if (networkStream != null)
                networkStream.Dispose();
        }

        private void StartListening(int LocalPortNum)
        {
            tcpListener = new TcpListener(LocalPortNum);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTCPClient), tcpListener);
        }

        private void AcceptTCPClient(IAsyncResult ar)
        {
            try
            {
                tcpListener = (TcpListener)(ar.AsyncState);
                tcpClient = tcpListener.EndAcceptTcpClient(ar);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            SetRemotePortNumTextAndEnableMessage(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString(), true);

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
            SetRemotePortNumTextAndEnableMessage("", false);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTCPClient), tcpListener);
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
        delegate void SetRemotePortNumTextAndEnableMessage_Callback(string text, bool enable);
        private void SetRemotePortNumTextAndEnableMessage(string Text, bool enable)
        {
            if (textBoxRemortPort.InvokeRequired)
            {
                SetRemotePortNumTextAndEnableMessage_Callback d = new SetRemotePortNumTextAndEnableMessage_Callback(SetRemotePortNumTextAndEnableMessage);
                this.Invoke(d, new object[] { Text, enable });
            }
            else
            {
                textBoxRemortPort.Text = Text;
                buttonSendMessage.Enabled = enable;
                textBoxMessageHistory.Enabled = enable;
                textBoxMessageToSend.Enabled = enable;
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

