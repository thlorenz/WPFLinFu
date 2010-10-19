using System.Windows.Controls;
using CooperatingLibrary.ViewModels;

namespace CooperatingLibrary.Views
{
    /// <summary>
    /// Interaction logic for CoopView.xaml
    /// </summary>
    public partial class CoopView : UserControl
    {
        public CoopView()
        {
            InitializeComponent();
        }

        public CoopView(CoopViewModel coopViewModel)
            : this()
        {
            DataContext = coopViewModel;
        }
    }
}