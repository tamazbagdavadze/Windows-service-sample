using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Windows_service_sample
{
    public partial class Service1 : ServiceBase
    {

        private readonly Timer timer;

        public Service1()
        {
            InitializeComponent();
            timer = new Timer(500);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var path = @"d:\\1.txt";
            var text = "some text";

            File.AppendAllText(path, text);
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        protected override void OnPause()
        {
            this.OnStop();
        }

        protected override void OnContinue()
        {
            this.OnStart(null);
        }
    }
}
