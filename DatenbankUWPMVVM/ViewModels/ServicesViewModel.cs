using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using DatenbankUWPMVVM.Core.Models;
using DatenbankUWPMVVM.Core.Services;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DatenbankUWPMVVM.ViewModels
{
    public class ServicesViewModel : ObservableObject
    {
        public ObservableCollection<Service> Source { get; } = new ObservableCollection<Service>();

        public ServicesViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            //var data = await SqlServerDataService.AlleServices();
            var data = await SqlServerDataService<Service>.allSqlData("SERVICES");


            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
