using System.ComponentModel;
using System.Windows;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.MVVM;

public abstract class NavigableWindow : Window
{
    private readonly IWindowFactory _windowFactory;
    private readonly INavigableDataContext _mainViewModel;

    private bool _isUserClosing = true; // indicates whether the window close is triggered on "X" button of via event

    protected NavigableWindow(INavigableDataContext mainViewModel, IWindowFactory windowFactory)
    {
        _mainViewModel = mainViewModel;
        _windowFactory = windowFactory;
        Subscribe();
    }

    private void OnNavigationChange()
    {
        Unsubscribe();
        var currentViewModel = _mainViewModel.NavigationStore.CurrentViewModel;
        if (currentViewModel != null)
        {
            Window w = _windowFactory.CreateWindow(currentViewModel);
            w.Show();
        }
        _isUserClosing = false;
        Close();
    }

    private void OnPopupOpen()
    {
        Unsubscribe();
        var currentViewModel = _mainViewModel.NavigationStore.CurrentPopupViewModel;
        if (currentViewModel != null)
            _windowFactory.CreateWindow(currentViewModel).ShowDialog();
        Subscribe();
    }

    private void OnPopupClose()
    {
        Unsubscribe();
        _isUserClosing = false;
        Close();
    }

    private void Subscribe()
    {
        _mainViewModel.NavigationStore.CurrentViewModelChanged += OnNavigationChange;
        _mainViewModel.NavigationStore.PopupOpened += OnPopupOpen;
        _mainViewModel.NavigationStore.PopupClosed += OnPopupClose;
    }

    private void Unsubscribe()
    {
        _mainViewModel.NavigationStore.CurrentViewModelChanged -= OnNavigationChange;
        _mainViewModel.NavigationStore.PopupOpened -= OnPopupOpen;
        _mainViewModel.NavigationStore.PopupClosed -= OnPopupClose;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (_isUserClosing && _mainViewModel.NavigationStore.CurrentPopupViewModel != null)
        {
            // user closing a popup window on "X" button
            Unsubscribe();
            _isUserClosing = false;
            _mainViewModel.NavigationStore.ClosePopup();
        }
        base.OnClosing(e);
    }
}