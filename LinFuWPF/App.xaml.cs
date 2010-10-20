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

            IInvokeWrapper aroundInvokeWrapper = new SimpleAroundInvokeWrapper<CoopViewModel>(coopViewModel) { AfterInvokeDelegate = RaisePropertyChanged };
              var proxyFactory = new ProxyFactory();
            proxyFactory.CreateProxy(aroundInvokeWrapper);

            var view = new CoopView(coopViewModel);
            var win = new Window { Topmost = true, Content = view, SizeToContent = SizeToContent.WidthAndHeight };
            win.Show();
        }

        void PlayWithModifiedLibrary()
        {
            var vm = new MainViewModel();

            MethodBodyReplacementProviderRegistry.SetProvider(new MethodReplacementProvider<MainViewModel>());

            vm.CheckCount();
        }

        void RaisePropertyChanged(IInvocationInfo info, object returnValue)
        {
            var vm = info.Target as NotifyPropertyChanged;
            if (vm != null)
                vm.RaisePropertyChanged(info.TargetMethod.Name);
        }
    }
}