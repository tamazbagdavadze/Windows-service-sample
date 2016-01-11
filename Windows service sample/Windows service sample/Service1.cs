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
        private readonly Timer _timer;
        private const string Path = @"d:\\1.txt";
        private const string Text = "some Text";

        public Service1()
        {
            InitializeComponent();
            _timer = new Timer(500);
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            File.AppendAllText(Path, Text);
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
        }

        protected override void OnPause()
        {
            OnStop();
        }

        protected override void OnContinue()
        {
            OnStart(null);
        }
    }
}
