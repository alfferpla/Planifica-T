using Pro8Tasker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro8Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category>? Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

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

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Ir al gimnasio",
                    Completed = false,
                    CategoryId = 1,
                },
                new MyTask
                {
                    TaskName = "Partido de tenis",
                    Completed = false,
                    CategoryId = 1,
                },
                new MyTask
                {
                    TaskName = "Actualizar portfolio",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Responder emails",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Entregar proyecto",
                    Completed = true,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Descargar apuntes",
                    Completed = false,
                    CategoryId = 3
                },
                new MyTask
                {
                    TaskName = "Aprender probabilidad",
                    Completed = false,
                    CategoryId = 3
                },

            };
            UpdateData();
        }
        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }

    }
}
