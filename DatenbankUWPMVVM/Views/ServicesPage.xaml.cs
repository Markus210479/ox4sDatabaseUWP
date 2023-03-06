using System;
using System.Windows.Input;
using DatenbankUWPMVVM.Controls;
using DatenbankUWPMVVM.ViewModels;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DatenbankUWPMVVM.Views
{
    public sealed partial class ServicesPage : Page
    {       
        public ServicesViewModel ViewModel { get; } = new ServicesViewModel();

        // TODO: Change the grid as appropriate to your app, adjust the column definitions on ReleasesPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public ServicesPage()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }

       


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }

       
    }
}
