namespace ProxyServerApp
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
			this.stopBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.startBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.blockFileBtn = new System.Windows.Forms.Button();
			this.decryptSSLCheck = new System.Windows.Forms.CheckBox();
			this.makeLogCheck = new System.Windows.Forms.CheckBox();
			this.majorLogsTxt = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.clearMajorLogsaBtn = new System.Windows.Forms.Button();
			this.detailedLogsCheck = new System.Windows.Forms.CheckBox();
			this.portNum = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.portNum)).BeginInit();
			this.SuspendLayout();
			// 
			// stopBtn
			// 
			this.stopBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.stopBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stopBtn.Location = new System.Drawing.Point(227, 89);
			this.stopBtn.Margin = new System.Windows.Forms.Padding(4);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.Size = new System.Drawing.Size(100, 28);
			this.stopBtn.TabIndex = 0;
			this.stopBtn.Text = "Stop";
			this.stopBtn.UseVisualStyleBackColor = true;
			this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 30);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(203, 174);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// startBtn
			// 
			this.startBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.startBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startBtn.Location = new System.Drawing.Point(468, 89);
			this.startBtn.Margin = new System.Windows.Forms.Padding(4);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(100, 28);
			this.startBtn.TabIndex = 2;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(253, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Enter Port Number";
			// 
			// blockFileBtn
			// 
			this.blockFileBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.blockFileBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blockFileBtn.Location = new System.Drawing.Point(227, 124);
			this.blockFileBtn.Margin = new System.Windows.Forms.Padding(4);
			this.blockFileBtn.Name = "blockFileBtn";
			this.blockFileBtn.Size = new System.Drawing.Size(341, 42);
			this.blockFileBtn.TabIndex = 6;
			this.blockFileBtn.Text = "Open Blocekd Webs File";
			this.blockFileBtn.UseVisualStyleBackColor = true;
			this.blockFileBtn.Click += new System.EventHandler(this.BlockFileBtn_Click);
			// 
			// decryptSSLCheck
			// 
			this.decryptSSLCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.decryptSSLCheck.AutoSize = true;
			this.decryptSSLCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.decryptSSLCheck.Location = new System.Drawing.Point(227, 174);
			this.decryptSSLCheck.Margin = new System.Windows.Forms.Padding(4);
			this.decryptSSLCheck.Name = "decryptSSLCheck";
			this.decryptSSLCheck.Size = new System.Drawing.Size(108, 23);
			this.decryptSSLCheck.TabIndex = 7;
			this.decryptSSLCheck.Text = "Decrypt SSL";
			this.decryptSSLCheck.UseVisualStyleBackColor = true;
			// 
			// makeLogCheck
			// 
			this.makeLogCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.makeLogCheck.AutoSize = true;
			this.makeLogCheck.Checked = true;
			this.makeLogCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.makeLogCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.makeLogCheck.Location = new System.Drawing.Point(452, 174);
			this.makeLogCheck.Margin = new System.Windows.Forms.Padding(4);
			this.makeLogCheck.Name = "makeLogCheck";
			this.makeLogCheck.Size = new System.Drawing.Size(98, 23);
			this.makeLogCheck.TabIndex = 8;
			this.makeLogCheck.Text = "Make Logs";
			this.makeLogCheck.UseVisualStyleBackColor = true;
			// 
			// majorLogsTxt
			// 
			this.majorLogsTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.majorLogsTxt.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.majorLogsTxt.Location = new System.Drawing.Point(16, 235);
			this.majorLogsTxt.Margin = new System.Windows.Forms.Padding(4);
			this.majorLogsTxt.Name = "majorLogsTxt";
			this.majorLogsTxt.ReadOnly = true;
			this.majorLogsTxt.Size = new System.Drawing.Size(515, 165);
			this.majorLogsTxt.TabIndex = 9;
			this.majorLogsTxt.Text = "";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 215);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 19);
			this.label2.TabIndex = 10;
			this.label2.Text = "Major Logs";
			// 
			// clearMajorLogsaBtn
			// 
			this.clearMajorLogsaBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.clearMajorLogsaBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearMajorLogsaBtn.Location = new System.Drawing.Point(540, 233);
			this.clearMajorLogsaBtn.Margin = new System.Windows.Forms.Padding(4);
			this.clearMajorLogsaBtn.Name = "clearMajorLogsaBtn";
			this.clearMajorLogsaBtn.Size = new System.Drawing.Size(28, 169);
			this.clearMajorLogsaBtn.TabIndex = 11;
			this.clearMajorLogsaBtn.Text = "C\r\nL\r\nE\r\nA\r\nR";
			this.clearMajorLogsaBtn.UseVisualStyleBackColor = true;
			this.clearMajorLogsaBtn.Click += new System.EventHandler(this.ClearMajorLogsaBtn_Click);
			// 
			// detailedLogsCheck
			// 
			this.detailedLogsCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.detailedLogsCheck.AutoSize = true;
			this.detailedLogsCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.detailedLogsCheck.Location = new System.Drawing.Point(452, 202);
			this.detailedLogsCheck.Margin = new System.Windows.Forms.Padding(4);
			this.detailedLogsCheck.Name = "detailedLogsCheck";
			this.detailedLogsCheck.Size = new System.Drawing.Size(116, 23);
			this.detailedLogsCheck.TabIndex = 12;
			this.detailedLogsCheck.Text = "Detailed Logs";
			this.detailedLogsCheck.UseVisualStyleBackColor = true;
			// 
			// portNum
			// 
			this.portNum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portNum.Location = new System.Drawing.Point(227, 50);
			this.portNum.Margin = new System.Windows.Forms.Padding(4);
			this.portNum.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			this.portNum.Name = "portNum";
			this.portNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.portNum.Size = new System.Drawing.Size(341, 34);
			this.portNum.TabIndex = 13;
			this.portNum.Value = new decimal(new int[] {
            18000,
            0,
            0,
            0});
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 406);
			this.Controls.Add(this.portNum);
			this.Controls.Add(this.detailedLogsCheck);
			this.Controls.Add(this.clearMajorLogsaBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.majorLogsTxt);
			this.Controls.Add(this.makeLogCheck);
			this.Controls.Add(this.decryptSSLCheck);
			this.Controls.Add(this.blockFileBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.stopBtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(599, 453);
			this.MinimumSize = new System.Drawing.Size(599, 453);
			this.Name = "Home";
			this.Text = "Web Proxy";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.portNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button blockFileBtn;
        private System.Windows.Forms.CheckBox decryptSSLCheck;
        private System.Windows.Forms.CheckBox makeLogCheck;
        private System.Windows.Forms.RichTextBox majorLogsTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearMajorLogsaBtn;
        private System.Windows.Forms.CheckBox detailedLogsCheck;
        private System.Windows.Forms.NumericUpDown portNum;
    }
}