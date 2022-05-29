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
		public ObservableCollection<string> ChosenRows { get; }
		public ObservableCollection<string> Rows { get; }
		string selectedTable, selectedChosen, selectedRow, selectedRowChosen;

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
		public string SelectedRow
		{
			get => selectedRow;
			set
			{
				this.RaiseAndSetIfChanged(ref selectedRow, value);
			}
		}
		public string SelectedRowChosen
		{
			get => selectedRowChosen;
			set
			{
				this.RaiseAndSetIfChanged(ref selectedRowChosen, value);
			}
		}
		public QueryManagerViewModel()
		{
			Tables = new ObservableCollection<string>(new List<string> { "Водители", "Владельцы", "Заезды","Турниры", "Результаты" });
			Rows = new ObservableCollection<string>();
			ChosenTables = new ObservableCollection<string>();
			ChosenRows = new ObservableCollection<string>();
		}
		public void Choose()
		{
			string item = SelectedTable;
			Tables.Remove(SelectedTable);
			ChosenTables.Add(item);
			switch (item)
			{
				case "Водители":
					string[] attrs = Driver.GetAttr();
					foreach (string attr in attrs)
					{
						Rows.Add(attr);
					}
					break;
				case "Владельцы":
					Rows.Add(Owner.GetAttr());
					break;
				case "Заезды":
					attrs = Race.GetAttr();
					foreach (string attr in attrs)
					{
						Rows.Add(attr);
					}
					break;
				case "Турниры":
					Rows.Add(Tournament.GetAttr());
					break;
				case "Результаты":
					attrs = Result.GetAttr();
					foreach (string attr in attrs)
					{
						Rows.Add(attr);
					}
					break;
			}
		}
		public void Delete()
		{
			string item = SelectedChosen;
			ChosenTables.Remove(SelectedChosen);
			Tables.Add(item);
			switch (item)
			{
				case "Водители":
					string[] attrs = Driver.GetAttr();
					foreach (string attr in attrs)
					{
						if (Rows.Contains(attr)) Rows.Remove(attr);
						else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
					}
					break;
				case "Владельцы":
					if (Rows.Contains(Owner.GetAttr())) Rows.Remove(Owner.GetAttr());
					else if (ChosenRows.Contains(Owner.GetAttr())) ChosenRows.Remove(Owner.GetAttr());
					break;
				case "Заезды":
					attrs = Race.GetAttr();
					foreach (string attr in attrs)
					{
						if (Rows.Contains(attr)) Rows.Remove(attr);
						else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
					}
					break;
				case "Турниры":
					if (Rows.Contains(Tournament.GetAttr())) Rows.Remove(Tournament.GetAttr());
					else if (ChosenRows.Contains(Tournament.GetAttr())) ChosenRows.Remove(Tournament.GetAttr());
					Rows.Add(Tournament.GetAttr());
					break;
				case "Результаты":
					attrs = Result.GetAttr();
					foreach (string attr in attrs)
					{
						if (Rows.Contains(attr)) Rows.Remove(attr);
						else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
					}
					break;
			}
		}
		public void ChooseRow()
		{
			string item = SelectedRow;
			Rows.Remove(SelectedRow);
			ChosenRows.Add(item);
		}
		public void DeleteRow()
		{
			string item = SelectedRowChosen;
			ChosenRows.Remove(SelectedRowChosen);
			Rows.Add(item);
		}
	}
}
