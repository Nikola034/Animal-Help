using System.Windows;
using System.Windows.Controls;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Common
{
    public partial class LoginWindow : NavigableWindow
    {
        public LoginWindow(LoginViewModel loginViewModel, IAnimalHelpWindowFactory windowFactory)
            : base(loginViewModel, windowFactory)
        {
            InitializeComponent();
            DataContext = loginViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox && DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = passwordBox.SecurePassword;
            }
        }

    }
}
