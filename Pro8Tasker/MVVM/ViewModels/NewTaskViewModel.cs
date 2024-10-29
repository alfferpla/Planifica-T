using Pro8Tasker.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro8Tasker.MVVM.ViewModels
{
    public class NewTaskViewModel
    {
        public string? Task {  get; set; }
        public ObservableCollection<MyTask>? Tasks { get; set; }
        public ObservableCollection<Category>? Categories { get; set; }
        
    }
}
