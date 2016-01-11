using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Windows_service_sample
{
    [RunInstaller(true)]
    public partial class MyInstaller : Installer
    {
        public MyInstaller()
        {
            InitializeComponent();

            Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });

            Installers.Add(new ServiceInstaller
            {
                ServiceName = "my service",
                Description = "my service!!!",
                StartType = ServiceStartMode.Automatic
            });
        }
    }
}
