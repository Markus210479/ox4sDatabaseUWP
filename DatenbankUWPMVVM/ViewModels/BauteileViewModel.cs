using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DatenbankUWPMVVM.ViewModels
{
    public class BauteileViewModel : ObservableObject
    {
        public ObservableCollection<Bauteil> Source { get; } = new ObservableCollection<Bauteil>();

        public BauteileViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await SqlServerDataService<Bauteil>.allSqlData("ARTIKEL");
            //var data = await SqlServerDataService.AlleBauteile();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
