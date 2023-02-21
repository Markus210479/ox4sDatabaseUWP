using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DatenbankUWPMVVM.ViewModels
{
    public class ReleasesViewModel : ObservableObject
    {
        public ObservableCollection<Releases> Source { get; } = new ObservableCollection<Releases>();

        public ReleasesViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            //Source.Clear();

            //// Replace this with your actual data
            //var data = await SampleDataService.GetGridDataAsync();

            //foreach (var item in data)
            //{
            //    Source.Add(item);
            //}
        }
    }
}
