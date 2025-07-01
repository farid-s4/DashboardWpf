using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dashboard.Models;
using Dashboard.Services;
using Dashboard.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
namespace Dashboard.ViewModels
{
    public partial class TaskViewModels : ObservableObject
    {
        private ObservableCollection<TasksModel> _tasks = TaskModulServices.LoadTaskModulS();

        public ObservableCollection<TasksModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        private string _tittle;

        public string Title
        {
            get => _tittle; set {
                if (_tittle != value)
                {
                    _tittle = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _prority;

        public string Priority
        {
            get => _prority; set
            {
                if (_prority != value)
                {
                    _prority = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _deadline = DateTime.Now;
        public DateTime Deadline
        {
            get => _deadline;
            set {
                if (_deadline != value) 
                {
                    _deadline = value; OnPropertyChanged();
                }
            }
        }

        private bool _iscompleted;

        public bool IsCompleted
        {
            get => _iscompleted;
            set
            {
                if (_iscompleted != value)
                {
                    _iscompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public ICommand SaveTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand UpdateTaskCommand { get; }
        public ICommand ShowAllCommand { get; }
        public ICommand ShowIncompleteCommand { get; }
        public ICollectionView TasksView { get; }

        public ICommand ShowCompletedCommand { get; }
/*        public ICommand FilterByLowPriorityCommand { get; }
        public ICommand FilterByMiddlePriorityCommand { get; }
        public ICommand FilterByHighPriorityCommand { get; }
*/
        public ICommand FilterByPriorityCommand { get; }

        


        public TaskViewModels()
        {
            
            SaveTaskCommand = new RelayCommand(SaveTask);
            DeleteTaskCommand = new RelayCommand<TasksModel>(DeleteTask);
            UpdateTaskCommand = new RelayCommand<TasksModel>(UpdateTask);
            ShowAllCommand = new RelayCommand(ShowAllTasks);
            ShowCompletedCommand = new RelayCommand(ShowCompletedTasks);
            ShowIncompleteCommand = new RelayCommand(ShowUncompletedTasks);
            FilterByPriorityCommand = new RelayCommand<string>(FilterByPriority);
            TasksView = CollectionViewSource.GetDefaultView(Tasks);
        
        }

        private void FilterByPriority(string priority)
        {
            TasksView.Filter = task => (task as TasksModel)?.Priority == priority;
        }


        private void ShowAllTasks()
        {
            TasksView.Filter = null;
        }

        private void ShowCompletedTasks()
        {
            TasksView.Filter = task => (task as TasksModel)?.IsCompleted == true;
        }

        private void ShowUncompletedTasks()
        {
            TasksView.Filter = task => (task as TasksModel)?.IsCompleted == false;
        }

        private void DeleteTask(TasksModel task)
        {
            if (task != null)
            {
                Tasks.Remove(task);
                TaskModulServices.SaveTaskModuls(Tasks);
            }
        }

        private void UpdateTask(TasksModel task)
        {
            if (task != null)
            {
                if (task.IsCompleted)
                {            
                    task.IsCompleted = false;
                }
                else
                {
                    task.IsCompleted = true;
                }

                TaskModulServices.SaveTaskModuls(Tasks);
            }
        }

        private void SaveTask()
        {
            Tasks.Add(new TasksModel
            {
                Id = Guid.NewGuid(),
                Title = this.Title,
                Deadline = this.Deadline,
                Priority = this.Priority,
                IsCompleted = this.IsCompleted

            });
            TaskModulServices.SaveTaskModuls(Tasks);
            Title = string.Empty;
            Deadline = DateTime.Now;
            Priority = null;
            IsCompleted = false;

        }
    }
}
