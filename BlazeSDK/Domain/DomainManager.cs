using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazeSDK.Domain
{
    internal sealed class DomainManager : AppDomainManager, INetDomain
    {
        public DomainManager() { }
        public override void InitializeNewDomain(AppDomainSetup appDomainInfo) { InitializationFlags = AppDomainManagerInitializationOptions.RegisterWithHost; }

        public void Initialize() => Main.Init();
        public void OnApplicationStart() => Main.onStart();
    }
}
