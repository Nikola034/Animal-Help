using System;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Common
{
    public partial class RegisterWindow : NavigableWindow
    {
        public RegisterWindow(RegisterViewModel registerViewModel, IAnimalHelpWindowFactory windowFactory)
            : base(registerViewModel, windowFactory)
        {
            InitializeComponent();
            DataContext = registerViewModel;

            //initialize datepicker
            datePicker.DisplayDateStart = new DateTime(1924, 1, 1);
            datePicker.DisplayDateEnd = DateTime.Today.AddYears(-16);   //minimum age of 16
            datePicker.SelectedDate = DateTime.Today.AddYears(-16);
        }
    }
}
