namespace TCPServer
{
    partial class TCPServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textBoxMessageToSend = new System.Windows.Forms.TextBox();
            this.textBoxMessageHistory = new System.Windows.Forms.TextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.textBoxRemortPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "本地端口";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Enabled = false;
            this.buttonSendMessage.Location = new System.Drawing.Point(231, 228);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(45, 23);
            this.buttonSendMessage.TabIndex = 13;
            this.buttonSendMessage.Text = "发送";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textBoxMessageToSend
            // 
            this.textBoxMessageToSend.Enabled = false;
            this.textBoxMessageToSend.Location = new System.Drawing.Point(10, 230);
            this.textBoxMessageToSend.Name = "textBoxMessageToSend";
            this.textBoxMessageToSend.Size = new System.Drawing.Size(215, 21);
            this.textBoxMessageToSend.TabIndex = 12;
            // 
            // textBoxMessageHistory
            // 
            this.textBoxMessageHistory.Enabled = false;
            this.textBoxMessageHistory.Location = new System.Drawing.Point(12, 39);
            this.textBoxMessageHistory.Multiline = true;
            this.textBoxMessageHistory.Name = "textBoxMessageHistory";
            this.textBoxMessageHistory.ReadOnly = true;
            this.textBoxMessageHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessageHistory.Size = new System.Drawing.Size(260, 185);
            this.textBoxMessageHistory.TabIndex = 11;
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(120, 10);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(45, 23);
            this.buttonListen.TabIndex = 10;
            this.buttonListen.Text = "监听";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(67, 10);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(47, 21);
            this.textBoxLocalPort.TabIndex = 8;
            // 
            // textBoxRemortPort
            // 
            this.textBoxRemortPort.Enabled = false;
            this.textBoxRemortPort.Location = new System.Drawing.Point(231, 10);
            this.textBoxRemortPort.Name = "textBoxRemortPort";
            this.textBoxRemortPort.Size = new System.Drawing.Size(47, 21);
            this.textBoxRemortPort.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "远程端口";
            // 
            // TCPServer
            // 
            this.AcceptButton = this.buttonListen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.textBoxMessageToSend);
            this.Controls.Add(this.textBoxMessageHistory);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.textBoxRemortPort);
            this.Controls.Add(this.textBoxLocalPort);
            this.Name = "TCPServer";
            this.Text = "TCPServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textBoxMessageToSend;
        private System.Windows.Forms.TextBox textBoxMessageHistory;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.TextBox textBoxRemortPort;
        private System.Windows.Forms.Label label2;
    }
}

