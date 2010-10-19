using System.Windows.Input;
using WPFCoreTools;

namespace CooperatingLibrary.ViewModels
{
    public class CoopViewModel : NotifyPropertyChanged
    {
        int _counter;

        public CoopViewModel()
        {
            AddOneCommand = new SimpleCommand { ExecuteDelegate = _ => Counter++ };
        }

        public virtual int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
             //   RaisePropertyChanged(() => Counter);
            }
        }

        public ICommand AddOneCommand { get; private set; }
    }
}