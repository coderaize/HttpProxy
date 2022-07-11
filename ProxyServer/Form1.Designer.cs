namespace ProxyServerApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.majorLogsTxt = new System.Windows.Forms.RichTextBox();
            this.startProxy = new System.Windows.Forms.Button();
            this.endProxy = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.doLogsCheck = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logs";
            // 
            // majorLogsTxt
            // 
            this.majorLogsTxt.Location = new System.Drawing.Point(32, 38);
            this.majorLogsTxt.Name = "majorLogsTxt";
            this.majorLogsTxt.Size = new System.Drawing.Size(622, 252);
            this.majorLogsTxt.TabIndex = 1;
            this.majorLogsTxt.Text = "";
            // 
            // startProxy
            // 
            this.startProxy.Location = new System.Drawing.Point(579, 309);
            this.startProxy.Name = "startProxy";
            this.startProxy.Size = new System.Drawing.Size(75, 23);
            this.startProxy.TabIndex = 2;
            this.startProxy.Text = "Start";
            this.startProxy.UseVisualStyleBackColor = true;
            this.startProxy.Click += new System.EventHandler(this.StartProxy_Click);
            // 
            // endProxy
            // 
            this.endProxy.Location = new System.Drawing.Point(33, 309);
            this.endProxy.Name = "endProxy";
            this.endProxy.Size = new System.Drawing.Size(75, 23);
            this.endProxy.TabIndex = 3;
            this.endProxy.Text = "End";
            this.endProxy.UseVisualStyleBackColor = true;
            this.endProxy.Click += new System.EventHandler(this.EndProxy_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(374, 309);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(525, 309);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 5;
            // 
            // doLogsCheck
            // 
            this.doLogsCheck.AutoSize = true;
            this.doLogsCheck.Location = new System.Drawing.Point(412, 335);
            this.doLogsCheck.Name = "doLogsCheck";
            this.doLogsCheck.Size = new System.Drawing.Size(66, 17);
            this.doLogsCheck.TabIndex = 6;
            this.doLogsCheck.Text = "Do Logs";
            this.doLogsCheck.UseVisualStyleBackColor = true;
            this.doLogsCheck.CheckedChanged += new System.EventHandler(this.DoLogsCheck_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(495, 335);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "exportLogs";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 383);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.doLogsCheck);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.endProxy);
            this.Controls.Add(this.startProxy);
            this.Controls.Add(this.majorLogsTxt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Proxy Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox majorLogsTxt;
        private System.Windows.Forms.Button startProxy;
        private System.Windows.Forms.Button endProxy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox doLogsCheck;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

