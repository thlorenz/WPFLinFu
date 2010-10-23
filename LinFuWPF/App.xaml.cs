using System;
using System.ComponentModel;
using System.Windows;
using CooperatingLibrary.ViewModels;
using CooperatingLibrary.Views;
using LinFu.AOP.Interfaces;
using LinFu.Proxy;
using LinFu.Proxy.Interfaces;
using LinFuInterceptorTools;
using ModifiedLibrary.ViewModels;
using WPFCoreTools;

namespace LinFuWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PlayWithCooperatingLibrary();
        }

        void PlayWithCooperatingLibrary()
        {
          
            var coopViewModel = new CoopViewModel();

            var proxyFactory = new ProxyFactory();
            var proxy = proxyFactory.CreateProxy<CoopViewModel>(new ViewModelInvokeWrapper<CoopViewModel>(coopViewModel), typeof(IViewModel));

            // When using coopViewModel directly, the bindings are updated correctly, when using the proxy the binding update breaks
            var view = new CoopView(coopViewModel /* proxy */);
            var win = new Window { Topmost = true, Content = view, SizeToContent = SizeToContent.WidthAndHeight };
             win.Show();
        }
       
    }
}