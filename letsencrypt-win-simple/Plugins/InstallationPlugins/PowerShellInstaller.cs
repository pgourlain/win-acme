using PKISharp.WACS.Clients;
using PKISharp.WACS.Extensions;
using PKISharp.WACS.Plugins.Base;
using PKISharp.WACS.Plugins.Interfaces;
using PKISharp.WACS.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKISharp.WACS.Plugins.InstallationPlugins
{

    internal class PowerShellInstallerFactory : ScriptInstallerBaseFactory<PowerShellInstaller>
    {
        public PowerShellInstallerFactory(ILogService log) : base(log, "ManualPS", "Run a custom powershell script") { }

    }

    internal class PowerShellInstaller : ScriptInstaller, IInstallationPlugin
    {
        private ScheduledRenewal _renewal;

        public PowerShellInstaller(ScheduledRenewal renewal, ILogService logService) 
            : base(renewal, logService)
        {
            _renewal = renewal;
        }

        protected override void FillProcessStartInfo(ProcessStartInfo pSI)
        {
            pSI.Arguments = $"-File \"{pSI.FileName}\"";
            pSI.FileName = "powershell.exe";
        }

        protected override void FillProcessStartInfoArguments(ProcessStartInfo pSI, string parametersFormat)
        {
            pSI.Arguments += " " + parametersFormat;
        }
    }
}
