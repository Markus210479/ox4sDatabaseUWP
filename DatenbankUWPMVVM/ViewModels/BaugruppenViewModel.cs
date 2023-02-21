using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DatenbankUWPMVVM.ViewModels
{
    public class BaugruppenViewModel : ObservableObject
    {
        public ObservableCollection<Baugruppen> Source { get; } = new ObservableCollection<Baugruppen>();

        public BaugruppenViewModel()
        {
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
