using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVM_HomeWork.OtherFIles;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;

namespace MVVM_HomeWork.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Коллекции объектов
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Provider> Providers { get; set; }

        // Объекты фильтрации
        public Category SelectedCategory { get; set; }
        public Provider SelectedProvider { get; set; }

        public MainWindowViewModel()
        {
            List<Category> categories = new List<Category> { new Category() { Id = 0, Title = "Все категории" } };
            categories.AddRange(DB.instance.Categories.ToList());
            Categories = categories.ToObservableCollection();

            List<Provider> providers = new List<Provider> { new Provider() { Id = 0, Title = "Все производители" } };
            providers.AddRange(DB.instance.Providers.ToList());
            Providers = providers.ToObservableCollection();

            Products = DB.instance.Products.ToObservableCollection();

            SelectedCategory = Categories[0];
            SelectedProvider = Providers[0];
        }

        // Метод фильтрации
        private void Search()
        {
            Products = DB.instance.Products.Include(s => s.IdCategoryNavigation).Include(s => s.IdProviderNavigation)
                                           .Where(s => (this.SelectedProvider.Id == 0 || s.IdProvider == this.SelectedProvider.Id)
                                                    && (this.SelectedCategory.Id == 0 || s.IdCategory == this.SelectedCategory.Id)).ToObservableCollection();
        }

        // Команда, запускающая фильтрацию
        public DelegateCommand SearchCommand { get
            {
                return new DelegateCommand(
                    () => Search()
                    ); 
            } }

        
    }
}
