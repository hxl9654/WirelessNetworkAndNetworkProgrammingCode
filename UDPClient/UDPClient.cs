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
using System.Net.NetworkInformation;

namespace UDPClient
{
    public partial class UDPClient : Form
    {
        public UDPClient()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
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
                    StartUDPResive(LocalPortNum);
                    SetEnableMessage(true);
                    textBoxLocalPort.Enabled = false;
                    buttonConnect.Text = "停止";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("UDPClient启动失败" + Environment.NewLine + ex);
                }
            }
            else
            {
                Disconnect();
                SetEnableMessage(false);
                textBoxLocalPort.Enabled = true;
                buttonConnect.Text = "启动";
            }
        }

        private void Disconnect()
        {
            if (udpClient != null)
            {
                udpClient.Close();
            }
        }

        UdpClient udpClient;

        private void StartUDPResive(int LocalPortNum)
        {
            udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse("0.0.0.0"), LocalPortNum));
            udpClient.BeginReceive(new AsyncCallback(UDPResive), udpClient);
        }

        private void UDPResive(IAsyncResult ar)
        {
            UdpClient udpClient = (UdpClient)ar.AsyncState;
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiveBytes = udpClient.EndReceive(ar, ref iPEndPoint);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);

            string TextToAdd = "Resived at 【{0}】, from 【{1}】" + Environment.NewLine + receiveString + Environment.NewLine;
            TextToAdd = TextToAdd.Replace("{0}", DateTime.Now.ToString());
            TextToAdd = TextToAdd.Replace("{1}", iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString());
            TextBoxMessageHistory_AddText(TextToAdd);

            udpClient.Close();
            StartUDPResive(Int32.Parse(textBoxLocalPort.Text));
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
            int RemotePortNum;
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
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(textBoxMessageToSend.Text);

            udpClient.Send(msg, msg.Length, new IPEndPoint(RemoteIP, RemotePortNum));

            string TextToAdd = "Send at 【{0}】, to 【{1}】" + Environment.NewLine + textBoxMessageToSend.Text + Environment.NewLine;
            TextToAdd = TextToAdd.Replace("{0}", DateTime.Now.ToString());
            TextToAdd = TextToAdd.Replace("{1}", textBoxRemoteIP.Text + ":" + textBoxRemortPort.Text);
            TextBoxMessageHistory_AddText(TextToAdd);
            textBoxMessageToSend.Text = "";
        }
    }
}
