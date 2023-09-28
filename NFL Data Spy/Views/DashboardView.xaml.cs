using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using NFL_Data_Spy.ViewModels;
using System.Windows.Controls;

namespace NFL_Data_Spy.Views;

public partial class DashboardView : UserControl
{
    MatchupDataService _matchupService = new MatchupDataService();

    public DashboardView()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}
