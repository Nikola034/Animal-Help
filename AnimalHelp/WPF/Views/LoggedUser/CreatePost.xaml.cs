using AnimalHelp.Domain.Model;
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

namespace AnimalHelp.WPF.Views.LoggedUser
{
    /// <summary>
    /// Interaction logic for CreatePost.xaml
    /// </summary>
    public partial class CreatePost : Window
    {
        public CreatePost()
        {
            InitializeComponent();
            PostStateComboBox.ItemsSource = Enum.GetValues(typeof(PostState));
            PostStatusComboBox.ItemsSource = Enum.GetValues(typeof(PostStatus));
        }

        private void SavePostButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
