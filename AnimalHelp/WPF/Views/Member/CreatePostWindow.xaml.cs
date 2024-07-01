using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Common;
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
    /// Interaction logic for CreatePostWindow.xaml
    /// </summary>
    public partial class CreatePostWindow : NavigableWindow
    {
        public CreatePostWindow(CreatePostViewModel createPostViewModel, IAnimalHelpWindowFactory windowFactory)
            : base(createPostViewModel, windowFactory)
        {
            InitializeComponent();
            DataContext = createPostViewModel;
        }

        private void SavePostButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
