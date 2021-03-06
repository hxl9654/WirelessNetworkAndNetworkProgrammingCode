﻿namespace UDPClient
{
    partial class UDPClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxRemoteIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textBoxMessageToSend = new System.Windows.Forms.TextBox();
            this.textBoxMessageHistory = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxRemortPort = new System.Windows.Forms.TextBox();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxRemoteIP
            // 
            this.textBoxRemoteIP.Location = new System.Drawing.Point(54, 202);
            this.textBoxRemoteIP.Name = "textBoxRemoteIP";
            this.textBoxRemoteIP.Size = new System.Drawing.Size(106, 21);
            this.textBoxRemoteIP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 107;
            this.label3.Text = "远程IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 108;
            this.label2.Text = "远程端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 109;
            this.label1.Text = "本地端口";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(233, 226);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(45, 23);
            this.buttonSendMessage.TabIndex = 5;
            this.buttonSendMessage.Text = "发送";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textBoxMessageToSend
            // 
            this.textBoxMessageToSend.Location = new System.Drawing.Point(12, 228);
            this.textBoxMessageToSend.Name = "textBoxMessageToSend";
            this.textBoxMessageToSend.Size = new System.Drawing.Size(215, 21);
            this.textBoxMessageToSend.TabIndex = 4;
            // 
            // textBoxMessageHistory
            // 
            this.textBoxMessageHistory.Location = new System.Drawing.Point(12, 35);
            this.textBoxMessageHistory.Multiline = true;
            this.textBoxMessageHistory.Name = "textBoxMessageHistory";
            this.textBoxMessageHistory.ReadOnly = true;
            this.textBoxMessageHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessageHistory.Size = new System.Drawing.Size(260, 161);
            this.textBoxMessageHistory.TabIndex = 104;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(130, 8);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(45, 21);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "启动";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxRemortPort
            // 
            this.textBoxRemortPort.Location = new System.Drawing.Point(225, 199);
            this.textBoxRemortPort.Name = "textBoxRemortPort";
            this.textBoxRemortPort.Size = new System.Drawing.Size(47, 21);
            this.textBoxRemortPort.TabIndex = 3;
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(69, 8);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(47, 21);
            this.textBoxLocalPort.TabIndex = 0;
            // 
            // UDPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxRemoteIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.textBoxMessageToSend);
            this.Controls.Add(this.textBoxMessageHistory);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxRemortPort);
            this.Controls.Add(this.textBoxLocalPort);
            this.Name = "UDPClient";
            this.Text = "UDPClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRemoteIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textBoxMessageToSend;
        private System.Windows.Forms.TextBox textBoxMessageHistory;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxRemortPort;
        private System.Windows.Forms.TextBox textBoxLocalPort;
    }
}

