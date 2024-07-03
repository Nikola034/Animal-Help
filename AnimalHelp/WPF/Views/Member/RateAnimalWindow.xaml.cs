using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.Views.Factories;
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
using System.Windows.Shapes;

namespace AnimalHelp.WPF.Views.Member
{
    /// <summary>
    /// Interaction logic for RateAnimalWindow.xaml
    /// </summary>
    public partial class RateAnimalWindow : NavigableWindow
    {
        public RateAnimalWindow(RateAnimalViewModel viewModel, IAnimalHelpWindowFactory window):
            base(viewModel, window)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
