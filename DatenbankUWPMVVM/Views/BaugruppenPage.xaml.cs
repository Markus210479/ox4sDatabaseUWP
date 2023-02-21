using System;

using DatenbankUWPMVVM.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DatenbankUWPMVVM.Views
{
    public sealed partial class BaugruppenPage : Page
    {
        public BaugruppenViewModel ViewModel { get; } = new BaugruppenViewModel();

        // TODO: Change the grid as appropriate to your app, adjust the column definitions on ReleasesPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public BaugruppenPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
