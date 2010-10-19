using System;
using System.ComponentModel;
using System.Windows;
using CooperatingLibrary.ViewModels;
using CooperatingLibrary.Views;
using LinFu.AOP.Interfaces;
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
            var aroundInvokeProvider = new SimpleAroundInvokeProvider(new SimpleAroundInvoke { AfterInvokeDelegate = RaisePropertyChanged });
            AroundMethodBodyRegistry.AddProvider(aroundInvokeProvider);

            var view = new CoopView(new CoopViewModel());
            var win = new Window { Topmost = true, Content = view, SizeToContent = SizeToContent.WidthAndHeight };
            win.Show();
        }

        void RaisePropertyChanged(IInvocationInfo info, object returnValue)
        {
            var vm = info.Target as NotifyPropertyChanged;
            if (vm != null)
                vm.RaisePropertyChanged(info.TargetMethod.Name);
        }

        void PlayWithModifiedLibrary()
        {
            var vm = new MainViewModel();
            
            MethodBodyReplacementProviderRegistry.SetProvider(new MethodReplacementProvider<MainViewModel>());

            vm.CheckCount();
        }
    }
}