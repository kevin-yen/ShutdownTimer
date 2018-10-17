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

public interface Action
{
    public void Execute( );
}

public class TurnOffAction
{
	public void Execute( )
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
		foreach (ManagementObject manObj in sysOS.GetInstances())   {
	        outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}

public class RestartAction
{
    public void Execute()
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
        foreach (ManagementObject manObj in sysOS.GetInstances())   {
            outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}