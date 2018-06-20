using PKISharp.WACS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKISharp.WACS.Plugins.ValidationPlugins.Http
{

	/// <summary>
	/// Self-host the validation files
	/// </summary>
	internal class ManualSelfHostingFactory : BaseHttpValidationFactory<ManualSelfHosting>
	{
		public ManualSelfHostingFactory(ILogService log) : base(log, nameof(ManualSelfHosting), "Manual hosting verification files") { }
		public override void Default(Target target, IOptionsService optionsService) { }
		public override void Aquire(Target target, IOptionsService optionsService, IInputService inputService, RunLevel runLevel) { }
	}
	internal class ManualSelfHosting : BaseHttpValidation
	{
		public ManualSelfHosting(ScheduledRenewal renewal, Target target, string identifier, ILogService log, IInputService input, ProxyService proxy) :
			base(log, input, proxy, renewal, target, identifier)
		{
		}

		protected override void DeleteFile(string path) { }
		protected override void DeleteFolder(string path) { }
		protected override bool IsEmpty(string path) => true;
		protected override void WriteFile(string path, string content) {}
		protected override string CombinePath(string root, string path) => PathSeparator + path;

		protected override void BeforeAuthorize()
		{
			if (_challenge != null)
			{
				/*
				 * Create a file containing just this data:

					9UYxFUabKg6w6HIwb2zLtytx4-5qVUCcutb2uUz0uBs.qJ79FHodmntPu5vcul9-NGrCiq1J_zvhFuvRhqODxsY

					And make it available on your web server at this URL:

					http://<YourDomainAndWebApp>/.well-known/acme-challenge/9UYxFUabKg6w6HIwb2zLtytx4-5qVUCcutb2uUz0uBs

				 * */
				var appSettingsKey = "acme-" + _challenge.Token;
				var appSettingsValue = _challenge.FileContent;
                this._input.Show("Create a file containing just this data", "\r\n\r\n "+ appSettingsValue, true);
                this._input.Show("And make it available on your web server at this URL", "\r\n\r\n" + _challenge.FileUrl, true);
				this._input.Wait();
			}
		}

	}
}
