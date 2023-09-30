using NFL_Data_Spy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NFL_Data_Spy.Views
{
    /// <summary>
    /// Interaction logic for ScoreboardView.xaml
    /// </summary>
    public partial class ScoreboardView : UserControl
    {
        public ScoreboardView()
        {
            InitializeComponent();
            DataContext = new ScoreboardViewViewModel();
        }
    }
}
