using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.ViewModels.Volounteer;
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

namespace AnimalHelp.WPF.Views.Volounteer
{
    /// <summary>
    /// Interaction logic for VolounteerMenuWindow.xaml
    /// </summary>
    public partial class VolounteerMenuWindow : NavigableWindow
    {
        public VolounteerMenuWindow(VolounteerMenuViewModel volounteerMenuViewModel, IAnimalHelpWindowFactory windowFactory)
            : base(volounteerMenuViewModel, windowFactory)
        {
            InitializeComponent();
            DataContext = volounteerMenuViewModel;
        }
    }
}
