namespace AppleDailyReportTool
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtServerStatus = new System.Windows.Forms.TextBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStopTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AutoStartTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(12, 19);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(58, 41);
            this.btnServerStart.TabIndex = 1;
            this.btnServerStart.Text = "Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(89, 19);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(60, 41);
            this.btnServerStop.TabIndex = 4;
            this.btnServerStop.Text = "Stop";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status";
            // 
            // TxtServerStatus
            // 
            this.TxtServerStatus.BackColor = System.Drawing.SystemColors.Window;
            this.TxtServerStatus.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtServerStatus.ForeColor = System.Drawing.Color.Red;
            this.TxtServerStatus.Location = new System.Drawing.Point(231, 19);
            this.TxtServerStatus.Name = "TxtServerStatus";
            this.TxtServerStatus.ReadOnly = true;
            this.TxtServerStatus.Size = new System.Drawing.Size(99, 44);
            this.TxtServerStatus.TabIndex = 6;
            this.TxtServerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtServerStatus.TextChanged += new System.EventHandler(this.TxtServerStatus_TextChanged);
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "HH:mm";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(12, 130);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStartTime.TabIndex = 7;
            this.dateTimePickerStartTime.Value = new System.DateTime(2019, 5, 6, 7, 30, 0, 0);
            this.dateTimePickerStartTime.ValueChanged += new System.EventHandler(this.dateTimePickerStartTime_ValueChanged);
            // 
            // dateTimePickerStopTime
            // 
            this.dateTimePickerStopTime.CustomFormat = "HH:mm";
            this.dateTimePickerStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStopTime.Location = new System.Drawing.Point(173, 130);
            this.dateTimePickerStopTime.Name = "dateTimePickerStopTime";
            this.dateTimePickerStopTime.ShowUpDown = true;
            this.dateTimePickerStopTime.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStopTime.TabIndex = 8;
            this.dateTimePickerStopTime.Value = new System.DateTime(2019, 5, 6, 17, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "StartTime";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "StopTime";
            // 
            // AutoStartTimer
            // 
            this.AutoStartTimer.Enabled = true;
            this.AutoStartTimer.Interval = 6000;
            this.AutoStartTimer.Tick += new System.EventHandler(this.AutoStartTimer_Tick);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 328);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerStopTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.TxtServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.btnServerStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerForm";
            this.Text = "AppleReportTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtServerStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStopTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer AutoStartTimer;
    }
}