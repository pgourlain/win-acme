using PKISharp.WACS.Plugins.Base;
using PKISharp.WACS.Plugins.Interfaces;
using PKISharp.WACS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKISharp.WACS.Plugins.StorePlugins
{
    internal class AzureCertificateStoreFactory : BaseStorePluginFactory<AzureCertificateStore>
    {
        public AzureCertificateStoreFactory(ILogService log) : base(log, nameof(AzureCertificateStore), "Use Azure to store certificate") { }
    }

    internal class AzureCertificateStore : IStorePlugin
    {
        public void Delete(CertificateInfo certificateInfo)
        {
            throw new NotImplementedException();
        }

        public CertificateInfo FindByThumbprint(string thumbPrint)
        {
            throw new NotImplementedException();
        }

        public void Save(CertificateInfo certificateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
