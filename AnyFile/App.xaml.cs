using Asjc.SingletonApp;
using System.Windows;

namespace AnyFile
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!SingletonApp.IsNew)
                Shutdown();

            base.OnStartup(e);
        }
    }

}
