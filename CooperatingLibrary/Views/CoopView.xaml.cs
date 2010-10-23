using System.Windows.Controls;
using CooperatingLibrary.ViewModels;

namespace CooperatingLibrary.Views
{
    /// <summary>
    /// Interaction logic for CoopView.xaml
    /// </summary>
    public partial class CoopView : UserControl
    {
        CoopViewModel _viewModel;

        public CoopView()
        {
            InitializeComponent();
        }

        public CoopView(CoopViewModel coopViewModel)
            : this()
        {
            DataContext = _viewModel = coopViewModel;
            _viewModel.InitializeCommand();
        }
    }
}