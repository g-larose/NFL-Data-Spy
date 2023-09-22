using NFL_Data_Spy.ViewModels;
using System.Windows.Controls;

namespace NFL_Data_Spy.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}
