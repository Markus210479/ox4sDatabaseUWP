using System;

using DatenbankUWPMVVM.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DatenbankUWPMVVM.Views
{
    public sealed partial class BauteilePage : Page
    {
        public BauteileViewModel ViewModel { get; } = new BauteileViewModel();

        // TODO: Change the grid as appropriate to your app, adjust the column definitions on BauteilePage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public BauteilePage()
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
