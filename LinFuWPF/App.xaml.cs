using System.Windows;
using LinFu.AOP.Interfaces;
using LinFuInterceptorTools;
using ModifiedLibrary.ViewModels;

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

            var vm = new MainViewModel();
            
            MethodBodyReplacementProviderRegistry.SetProvider(new MethodReplacementProvider<MainViewModel>());

            vm.CheckCount();
        }
    }
}