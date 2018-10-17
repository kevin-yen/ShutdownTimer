namespace Shutdown_Timer_2._0
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Hours = new System.Windows.Forms.NumericUpDown();
            this.Minutes = new System.Windows.Forms.NumericUpDown();
            this.Seconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ActionSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.ForceQuitCheckBox = new System.Windows.Forms.CheckBox();
            this.SecondDecrement = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CommitCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(36, 12);
            this.Hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(32, 20);
            this.Hours.TabIndex = 0;
            // 
            // Minutes
            // 
            this.Minutes.Location = new System.Drawing.Point(104, 12);
            this.Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Minutes.Name = "Minutes";
            this.Minutes.Size = new System.Drawing.Size(32, 20);
            this.Minutes.TabIndex = 1;
            // 
            // Seconds
            // 
            this.Seconds.Location = new System.Drawing.Point(174, 12);
            this.Seconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Seconds.Name = "Seconds";
            this.Seconds.Size = new System.Drawing.Size(32, 20);
            this.Seconds.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sec";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(212, 9);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ActionSelector
            // 
            this.ActionSelector.FormattingEnabled = true;
            this.ActionSelector.Items.AddRange(new object[] {
            "Turn Off",
            "Restart",
            "Stand By",
            "Log Off",
            "Hibernate",
            "Power Off",
            "Notify",
            "Play Sound"});
            this.ActionSelector.Location = new System.Drawing.Point(58, 43);
            this.ActionSelector.Name = "ActionSelector";
            this.ActionSelector.Size = new System.Drawing.Size(148, 21);
            this.ActionSelector.TabIndex = 7;
            this.ActionSelector.Text = "Turn Off";
            this.ActionSelector.SelectedIndexChanged += new System.EventHandler(this.ActionSelection_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Action:";
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(212, 41);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 23);
            this.StartStopButton.TabIndex = 9;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CommitCheckBox);
            this.groupBox1.Controls.Add(this.MinimizeToTrayCheckBox);
            this.groupBox1.Controls.Add(this.ForceQuitCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 65);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // MinimizeToTrayCheckBox
            // 
            this.MinimizeToTrayCheckBox.AutoSize = true;
            this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(6, 42);
            this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
            this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(106, 17);
            this.MinimizeToTrayCheckBox.TabIndex = 1;
            this.MinimizeToTrayCheckBox.Text = "Minimize To Tray";
            this.MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // ForceQuitCheckBox
            // 
            this.ForceQuitCheckBox.AutoSize = true;
            this.ForceQuitCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ForceQuitCheckBox.Name = "ForceQuitCheckBox";
            this.ForceQuitCheckBox.Size = new System.Drawing.Size(75, 17);
            this.ForceQuitCheckBox.TabIndex = 0;
            this.ForceQuitCheckBox.Text = "Force Quit";
            this.ForceQuitCheckBox.UseVisualStyleBackColor = true;
            this.ForceQuitCheckBox.CheckedChanged += new System.EventHandler(this.ForceQuitCheckBox_CheckedChanged);
            // 
            // SecondDecrement
            // 
            this.SecondDecrement.Interval = 1000;
            this.SecondDecrement.Tick += new System.EventHandler(this.SecondDecrement_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "test";
            this.NotifyIcon.BalloonTipTitle = "Shutdown Timer 2.0";
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Timer not started";
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // CommitCheckBox
            // 
            this.CommitCheckBox.AutoSize = true;
            this.CommitCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.CommitCheckBox.Location = new System.Drawing.Point(133, 20);
            this.CommitCheckBox.Name = "CommitCheckBox";
            this.CommitCheckBox.Size = new System.Drawing.Size(60, 17);
            this.CommitCheckBox.TabIndex = 2;
            this.CommitCheckBox.Text = "Commit";
            this.CommitCheckBox.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 147);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.Seconds);
            this.Controls.Add(this.Minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ActionSelector);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Shutdown Timer 2.0";
            this.Resize += new System.EventHandler(this.Form1_Resized);
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Seconds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Hours;
        private System.Windows.Forms.NumericUpDown Minutes;
        private System.Windows.Forms.NumericUpDown Seconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ComboBox ActionSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ForceQuitCheckBox;
        private System.Windows.Forms.CheckBox MinimizeToTrayCheckBox;
        private System.Windows.Forms.Timer SecondDecrement;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.CheckBox CommitCheckBox;
    }
}

