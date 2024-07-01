using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.ViewModels.Member;
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

namespace AnimalHelp.WPF.Views.Member
{
    /// <summary>
    /// Interaction logic for FeedView.xaml
    /// </summary>
    public partial class FeedView : UserControl
    {
        public FeedView(IAuthenticationStore authenticationStore, IMemberService memberService, IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            InitializeComponent();
            DataContext = new FeedViewModel(authenticationStore, memberService, postService, navigationService, navigationStore);
            DataContextChanged += new DependencyPropertyChangedEventHandler(SubscribeToEvents);
        }

        public void SubscribeToEvents(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
