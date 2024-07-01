using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminMenuWindow.xaml
    /// </summary>
    public partial class AdminMenuWindow : NavigableWindow
    {
        public AdminMenuWindow(AdminMenuViewModel adminMenuViewModel, IAnimalHelpWindowFactory windowFactory)
            : base(adminMenuViewModel, windowFactory)
        {
            InitializeComponent();
            DataContext = adminMenuViewModel;
        }
    }
}
