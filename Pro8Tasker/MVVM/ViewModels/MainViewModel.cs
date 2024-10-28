using Pro8Tasker.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro8Tasker.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Category>? Categories { get; set; }

        public MainViewModel()
        {
            FillData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Deporte",
                    Color = "#CF14DF"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Trabajo",
                    Color = "#df6f14"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Estudiar",
                    Color = "#14df80"
                }
            };
        }
    }
}
