using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace RGR_Visual.ViewModels
{
    public class QueryManagerViewModel : ViewModelBase
    {
        public ObservableCollection<string> Tables { get; }
        public ObservableCollection<string> ChosenTables { get; }
        public ObservableCollection<string> Rows { get; }
        string selectedTable, selectedChosen;

        public string SelectedTable
        {
            get=> selectedTable;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedTable, value);
            }
        }
        public string SelectedChosen 
        {
            get => selectedChosen;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedChosen, value);
            }
        }
        public QueryManagerViewModel()
        {
            Tables = new ObservableCollection<string>(new List<string> { "Водители", "Владельцы", "Заезды","Турниры", "Результаты" });
            Rows = new ObservableCollection<string>();
            ChosenTables = new ObservableCollection<string>();
        }
        public void Choose()
        {
            string item = selectedTable;
            Tables.Remove(SelectedTable);
            ChosenTables.Add(item);
        }
        public void Delete()
        {
            string item = SelectedChosen;
            ChosenTables.Remove(SelectedChosen);
            Tables.Add(item);
        }
    }
}
