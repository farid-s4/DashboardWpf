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
    public class FinanceRecordViewModels : ObservableObject
    {
        private ObservableCollection<FinanceRecordModel> _records = FinanceModulServices.LoadTaskModulS();

        public ObservableCollection<FinanceRecordModel> Records
        {
            get => _records;
            set => SetProperty(ref _records, value);
        }

        public Guid Id { get; set; }
        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }
        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                if (_note != value)
                {
                    _note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }
        private FinanceRecordModel _selectedRecord;
        public FinanceRecordModel SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                if (_selectedRecord != value)
                {
                    _selectedRecord = value;
                    OnPropertyChanged(nameof(SelectedRecord));
                    ((RelayCommand<FinanceRecordModel>)DeleteRecordCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand SaveFinanceRecordCommand { get; }
        public ICommand DeleteRecordCommand { get; set; }
        public ICollectionView FinanceRecords { get; }
        public ICommand ShowAllCommand { get; }
        public FinanceRecordViewModels()
        {
            SaveFinanceRecordCommand = new RelayCommand(SaveFinanceRecord);
            DeleteRecordCommand = new RelayCommand<FinanceRecordModel>(DeleteSelectedRecord);
            ShowAllCommand = new RelayCommand(ShowFinanceRecords);
            FinanceRecords = CollectionViewSource.GetDefaultView(Records);
        }

        private void ShowFinanceRecords()
        {
            FinanceRecords.Filter = null;
        }

        private void DeleteSelectedRecord(FinanceRecordModel record)
        {
            if (record != null)
            {
                _records.Remove(record);
                FinanceModulServices.SaveTaskModuls(_records);
            }
        }

        private void SaveFinanceRecord() {
            _records.Add(new FinanceRecordModel
            {
                Id = Guid.NewGuid(),
                Type = this.Type,
                Category = this.Category,
                Amount = this.Amount,
                Date = this.Date,
                Note = this.Note,
            });
            FinanceModulServices.SaveTaskModuls(_records);
            Type = string.Empty;
            Category = string.Empty;
            Amount = 0;
            Date = DateTime.Now;
            Note = string.Empty;
        }
    }
}