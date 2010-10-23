using System;
using System.Windows.Input;
using LinFuInterceptorTools;
using WPFCoreTools;

namespace CooperatingLibrary.ViewModels
{
    public class CoopViewModel : ViewModelBase
    {
        int _counter;

        public void InitializeCommand()
        {
            AddOneCommand = new SimpleCommand { ExecuteDelegate = AddOne };
        }

        public void AddOne(object _)
        {
            Counter++;
        }

        public virtual int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                Console.WriteLine("Counter is now {0}", _counter);
                RaisePropertyChanged("Counter");
            }
        }

        public ICommand AddOneCommand { get; private set; }
    }
}