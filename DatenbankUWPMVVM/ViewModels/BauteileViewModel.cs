using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DatenbankUWPMVVM.Controls;
using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace DatenbankUWPMVVM.ViewModels
{
    public class BauteileViewModel : ObservableObject
    {
        public ObservableCollection<Bauteil> Source { get; } = new ObservableCollection<Bauteil>();
        public ObservableCollection<int> DataRowsCollection { get; } = new ObservableCollection<int> { 100, 250, 500, 1000 };
        //private int _dataRowsCollIndex;
        public int DataRowsCollIndex { get; set; }
        //{
        //    get { return _dataRowsCollIndex; }
        //    set { SetProperty(ref _dataRowsCollIndex, value); }
        //}

        private ICommand _forwardClick;
        private ICommand _backwardClick;
        private ICommand _topClick;
        private ICommand _bottomClick;
        public BauteileViewModel()
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
            System.Diagnostics.Debug.WriteLine("bauteilWert:" + value.ToString());
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await SqlServerDataService.AlleBauteile();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
