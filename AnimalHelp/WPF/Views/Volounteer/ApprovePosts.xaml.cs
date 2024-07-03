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

namespace AnimalHelp.WPF.Views.Volounteer
{
    /// <summary>
    /// Interaction logic for ApprovePosts.xaml
    /// </summary>
    public partial class ApprovePosts : UserControl
    {
        public ApprovePosts()
        {
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(SubscribeToEvents);
        }
        public void SubscribeToEvents(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
