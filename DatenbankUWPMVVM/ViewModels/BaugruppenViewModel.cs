using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DatenbankUWPMVVM.Controls;
using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml.Controls;

namespace DatenbankUWPMVVM.ViewModels
{
    public class BaugruppenViewModel : ObservableObject
    {
        public ObservableCollection<Baugruppen> Source { get; } = new ObservableCollection<Baugruppen>();
        public ObservableCollection<int> DataRowsCollection { get; } = new ObservableCollection<int> { 100, 250, 500, 1000 };
        private int _dataRowsCollIndex;
        public int DataRowsCollIndex
        {
            get { return _dataRowsCollIndex; }
            set { SetProperty(ref _dataRowsCollIndex, value); }
        }

        private ICommand _forwardClick;
        private ICommand _backwardClick;
        private ICommand _topClick;
        private ICommand _bottomClick;
        public BaugruppenViewModel()
        {
            DataRowsCollIndex = 0;
            NavControl.viewModelObject = this;
        }

        public ICommand ForwardClick => _forwardClick ?? (_forwardClick = new RelayCommand(Forward));
        public ICommand BackwardClick => _backwardClick ?? (_backwardClick = new RelayCommand(Backward));
        public ICommand TopClick => _topClick ?? (_topClick = new RelayCommand(Top));
        public ICommand BottomClick => _bottomClick ?? (_bottomClick = new RelayCommand(Bottom));

        private void Backward()
        {
            System.Diagnostics.Debug.WriteLine("backward");
        }

        private void Top()
        {
            System.Diagnostics.Debug.WriteLine("top");
        }
        private void Bottom()
        {
            System.Diagnostics.Debug.WriteLine("bottom");
        }

        private void Forward()
        {
            System.Diagnostics.Debug.WriteLine("forward");
        }

        public static void SelectionChangeData(int value)
    {
        //return Anzahl[AnzahlSelIndex];
        System.Diagnostics.Debug.WriteLine("baugruppeWert:" + value.ToString());
    }

    public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await SqlServerDataService.AlleBaugruppen();


            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
