using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Media;

namespace Shutdown_Timer_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (!GlobalVariables.timerActive)
            {
                Hours.Value = 0;
                Minutes.Value = 0;
                Seconds.Value = 0;
            }
        }

        private void ActionSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionSelection.SelectedItem.ToString().Equals("Notify"))
                ForceQuitCheckBox.Enabled = false;
            else if (ActionSelection.SelectedItem.ToString().Equals("Sound"))
                ForceQuitCheckBox.Enabled = false;
            else
                ForceQuitCheckBox.Enabled = true;
        }

        private void Form1_Resized(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (MinimizeToTrayCheckBox.Checked)
                {
                    if (GlobalVariables.timerActive)
                        NotifyIcon.BalloonTipText = string.Format("{0:00}:{1:00}:{2:00}", Hours.Value, Minutes.Value, Seconds.Value);
                    else
                        NotifyIcon.BalloonTipText = "Timer Not Started";
                    NotifyIcon.Visible = true;
                    NotifyIcon.ShowBalloonTip(500);
                    this.Visible = false;
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                NotifyIcon.Visible = false;
                this.Visible = true;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.timerActive)
                NotifyIcon.BalloonTipText = string.Format("{0:00}:{1:00}:{2:00}", Hours.Value, Minutes.Value, Seconds.Value);
            else
                NotifyIcon.BalloonTipText = "Timer Not Started";
            NotifyIcon.ShowBalloonTip(500);
        }

        private void NotifyIcon_DoubleClicked(object sender, EventArgs e)
        {
            NotifyIcon.Visible = false;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void SecondDecrement_Tick(object sender, EventArgs e)
        {
            if (Seconds.Value == 0)
            {
                if (Minutes.Value == 0)
                {
                    if(Hours.Value == 0)
                    {
                        StopTimer();
                        ExecuteAction();
                        return;
                    }
                    else
                    {
                        Hours.Value--;
                    }
                    Minutes.Value = 59;
                }
                else
                {
                    Minutes.Value--;
                }
                Seconds.Value = 59;
            }
            else
            {
                Seconds.Value--;
            }

            if ((Seconds.Value == 0) && (Minutes.Value == 0) && (Hours.Value == 0))
            {
                StopTimer();
                ExecuteAction();
            }
        }

        private void ExecuteAction()
        {
            switch (ActionSelection.SelectedItem.ToString())
            {
                case "Turn Off":
                    TurnOff();
                    Application.Exit();
                    break;

                case "Restart":
                    Restart();
                    Application.Exit();
                    break;

                case "Stand By":
                    StandBy();
                    break;

                case "Log Off":
                    LogOff();
                    Application.Exit();
                    break;

                case "Hibernte":
                    Hibernate();
                    break;

                case "Power Off":
                    PowerOff();
                    break;

                case "Notify":
                    Notify();
                    break;

                case "Sound":
                    Sound();
                    break;

                default:
                    break;
            }
        }

        private void TurnOff()
        {
        	ManagementBaseObject outParameters = null;
		    ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
		    sysOS.Get();
		    // enables required security privilege.
		    sysOS.Scope.Options.EnablePrivileges = true; 
		    // get our in parameters
		    ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
		    // pass the flag of 0 = System Shutdown
            if (ForceQuitCheckBox.Checked)
                inParameters["Flags"] = "5";
            else
                inParameters["Flags"] = "1";
		    inParameters["Reserved"] = "0";
		    foreach (ManagementObject manObj in sysOS.GetInstances())
		    {
	    		outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
		    }
        }

        private void Restart()
        {
            ManagementBaseObject outParameters = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            // enables required security privilege.
            sysOS.Scope.Options.EnablePrivileges = true;
            // get our in parameters
            ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
            // pass the flag of 0 = System Shutdown
            if (ForceQuitCheckBox.Checked)
                inParameters["Flags"] = "6";
            else
                inParameters["Flags"] = "2";
            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
            {
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
            }
        }

        private void StandBy()
        {
            if (ForceQuitCheckBox.Checked)
                Application.SetSuspendState(PowerState.Suspend, true, false);
            else
                Application.SetSuspendState(PowerState.Suspend, false, false);

        }

        private void LogOff()
        {
            ManagementBaseObject outParameters = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            // enables required security privilege.
            sysOS.Scope.Options.EnablePrivileges = true;
            // get our in parameters
            ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
            // pass the flag of 0 = System Shutdown
            if (ForceQuitCheckBox.Checked)
                inParameters["Flags"] = "4";
            else
                inParameters["Flags"] = "0";
            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
            {
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
            }
        }

        private void Hibernate()
        {
            if (ForceQuitCheckBox.Checked)
                Application.SetSuspendState(PowerState.Hibernate, true, false);
            else
                Application.SetSuspendState(PowerState.Hibernate, false, false);
        }

        private void PowerOff()
        {
            ManagementBaseObject outParameters = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            // enables required security privilege.
            sysOS.Scope.Options.EnablePrivileges = true;
            // get our in parameters
            ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
            // pass the flag of 0 = System Shutdown
            if (ForceQuitCheckBox.Checked)
                inParameters["Flags"] = "12";
            else
                inParameters["Flags"] = "8";
            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
            {
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
            }
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!GlobalVariables.timerActive)
                StartTimer();
            else
                StopTimer();
        }

        private void StartTimer()
        {
            StartStopButton.Text = "Stop";
            Hours.Enabled = false;
            Minutes.Enabled = false;
            Seconds.Enabled = false;
            ClearButton.Enabled = false;
            ActionSelection.Enabled = false;
            ForceQuitCheckBox.Enabled = false;
            GlobalVariables.timerActive = true;
            SecondDecrement.Start();
        }

        private void StopTimer()
        {
            StartStopButton.Text = "Start";
            Hours.Enabled = true;
            Minutes.Enabled = true;
            Seconds.Enabled = true;
            ClearButton.Enabled = true;
            ActionSelection.Enabled = true;
            ForceQuitCheckBox.Enabled = true;
            GlobalVariables.timerActive = false;
            SecondDecrement.Stop();
        }

        private void Notify( )
        {
            MessageBox.Show("Time is up", "Shutdown Timer 2.0");
        }

        private void Sound()
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream s = a.GetManifestResourceStream("Shutdown_Timer_2._0.Success.wav");
                SoundPlayer Sound = new SoundPlayer(s);
                Sound.Play();
            }
            catch
            {
                SystemSounds.Beep.Play();
            }

            //MessageBox.Show("Time is up", "Shutdown Timer 2.0");
        }
   }
}
