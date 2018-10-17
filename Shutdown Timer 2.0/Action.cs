using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

public interface IAction
{
    void Execute( );
}

public class TurnOffAction : IAction
{
    private ManagementBaseObject outParameters;
	private ManagementClass sysOS;
	protected ManagementBaseObject inParameters;

    public TurnOffAction(){
        outParameters = null;
        sysOS = new ManagementClass("Win32_OperatingSystem");
        sysOS.Get();
		// enables required security privilege.
		sysOS.Scope.Options.EnablePrivileges = true; 
		// get our in parameters
        inParameters = sysOS.GetMethodParameters("Win32Shutdown");
    }

    protected virtual void SetShutdownFlag(){
        inParameters["Flags"] = "1";
    }

	public void Execute( ){
		// pass the flag of 0 = System Shutdown
        SetShutdownFlag( );
        inParameters["Reserved"] = "0";
		foreach (ManagementObject manObj in sysOS.GetInstances())   {
	        outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}

public class ForcedTurnOffAction : TurnOffAction
{
    protected override void SetShutdownFlag() {
        inParameters["Flags"] = "5";
    }
}

public class RestartAction : IAction
{
    private ManagementBaseObject outParameters;
    private ManagementClass sysOS;
    protected ManagementBaseObject inParameters;

    public RestartAction( ){
        outParameters = null;
        sysOS = new ManagementClass("Win32_OperatingSystem");
        sysOS.Get();
        // enables required security privilege.
        sysOS.Scope.Options.EnablePrivileges = true;
        // get our in parameters
        inParameters = sysOS.GetMethodParameters("Win32Shutdown");
    }

    protected virtual void SetRestartFlag() {
        inParameters["Flags"] = "2";
    }

    public void Execute()   {
        // pass the flag of 0 = System Shutdown
        SetRestartFlag();
        inParameters["Reserved"] = "0";
        foreach (ManagementObject manObj in sysOS.GetInstances())   {
            outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}

public class ForcedRestartAction : RestartAction
{
    protected override void SetRestartFlag() {
        inParameters["Flags"] = "6";
    }
}

public class StandByAction : IAction
{
    public virtual void Execute() {
        Application.SetSuspendState(PowerState.Suspend, false, false);
    }
}

public class ForcedStandByAction : StandByAction
{
    public override void Execute() {
        Application.SetSuspendState(PowerState.Suspend, true, false);
    }
}

public class LogOffAction : IAction
{
    private ManagementBaseObject outParameters;
    private ManagementClass sysOS;
    protected ManagementBaseObject inParameters;

    public LogOffAction() {
        outParameters = null;
        sysOS = new ManagementClass("Win32_OperatingSystem");
        sysOS.Get();
        // enables required security privilege.
        sysOS.Scope.Options.EnablePrivileges = true;
        // get our in parameters
        inParameters = sysOS.GetMethodParameters("Win32Shutdown");
    }

    protected virtual void SetLogOffFlag( ){
        inParameters["Flags"] = "4";
    }

    public void Execute() {
        // pass the flag of 0 = System Shutdown
        SetLogOffFlag( );
        inParameters["Reserved"] = "0";
        foreach (ManagementObject manObj in sysOS.GetInstances()) {
            outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}

public class ForcedLogOffAction : LogOffAction
{
    protected override void SetLogOffFlag( ){
        inParameters["Flags"] = "0";
    }
}

public class HibernateAction : IAction
{
    public virtual void Execute() {
        Application.SetSuspendState(PowerState.Hibernate, false, false);
    }
}

public class ForcedHibernateAction : HibernateAction
{
    public override void Execute() {
        Application.SetSuspendState(PowerState.Hibernate, true, false);
    }
}

public class PowerOffAction : IAction
{
    private ManagementBaseObject outParameters;
    private ManagementClass sysOS;
    protected ManagementBaseObject inParameters;

    public PowerOffAction() {
        outParameters = null;
        sysOS = new ManagementClass("Win32_OperatingSystem");
        sysOS.Get();
        // enables required security privilege.
        sysOS.Scope.Options.EnablePrivileges = true;
        // get our in parameters
        inParameters = sysOS.GetMethodParameters("Win32Shutdown");
    }

    protected virtual void SetPowerOffFlag() {
        inParameters["Flags"] = "12";
    }

    public void Execute( ){
        // pass the flag of 0 = System Shutdown
        inParameters["Reserved"] = "0";
        foreach (ManagementObject manObj in sysOS.GetInstances()){
            outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
        }
    }
}

public class ForcedPowerOffAction : PowerOffAction
{
    protected override void SetPowerOffFlag() {
        inParameters["Flags"] = "8";
    }
}

public class NotifyAction : IAction
{
    public void Execute() {
        MessageBox.Show("Time is up.", "Shutdown Timer 2.1");
    }
}

public class PlaySoundAction : IAction
{
    public void Execute() {
        try {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("Shutdown_Timer_2._0.Success.wav");
            SoundPlayer Sound = new SoundPlayer(s);
            Sound.Play();
        }
        catch {
            SystemSounds.Beep.Play();
        }
    }
}

public interface IActionHandle
{

}
