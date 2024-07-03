using System.Windows;
using System.Windows.Controls;

namespace AnimalHelp.WPF.Views.Volounteer.BlackList;

public partial class BlackListView : UserControl
{
    public BlackListView()
    {
        InitializeComponent();
        DataContextChanged += new DependencyPropertyChangedEventHandler(SubscribeToEvents);
    }
    
    public void SubscribeToEvents(object sender, DependencyPropertyChangedEventArgs e)
    {

    }
}