using System.Windows;
using System.Windows.Controls;

namespace AnimalHelp.WPF.Views.Admin
{
    /// <summary>
    /// Interaction logic for VolunteerRegistrationView.xaml
    /// </summary>
    public partial class VolunteerRegistrationView : UserControl
    {
        public VolunteerRegistrationView()
        {
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(SubscribeToEvents);
        }
        public void SubscribeToEvents(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

    }
}
