using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using RGR_Visual.Models;

namespace RGR_Visual.ViewModels
{
	public class QueryManagerViewModel : ViewModelBase
	{
		MainWindowViewModel main;
		public ObservableCollection<string> Tables { get; }
		public ObservableCollection<string> ChosenTables { get; }
		public ObservableCollection<string> ChosenRows { get; }
		public ObservableCollection<string> Rows { get; }
		public Dictionary<string, object> DBTables { get; set; }
		public ObservableCollection<string> Operators { get; }

		string condition;
		string selectedTable;
		string selectedChosen;
		string selectedRow;
		string selectedRowChosen;
		string selectedOperator;
		string selectedRowForCondition;

		public string Condition
		{
			get => condition;
			set
			{
				this.RaiseAndSetIfChanged(ref condition, value);
			}
		}

		public string SelectedRowForCondition
		{
			get => selectedRowForCondition;
			set
			{
				this.RaiseAndSetIfChanged(ref selectedRowForCondition, value);
			}
		}
		public string SelectedOperator
		{
			get => selectedOperator;
			set
			{
				this.RaiseAndSetIfChanged(ref selectedOperator, value);
			}
		}
		public string SelectedTable
		{
			get => selectedTable;
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
		public QueryManagerViewModel(MainWindowViewModel main)
		{
			Tables = new ObservableCollection<string>(new List<string> { "Driver", "Owner", "Race","Tournament", "Result" });
			Rows = new ObservableCollection<string>();
			ChosenTables = new ObservableCollection<string>();
			ChosenRows = new ObservableCollection<string>();
			this.main = main;
			Operators = new ObservableCollection<string> { "", "<", "<=", ">", ">=", "=" };
		}
		public void Choose()
		{
			string item = SelectedTable;
			Tables.Remove(SelectedTable);
			ChosenTables.Add(item);
			switch (item)
			{
				case "Driver":
					string[] attrs = Driver.GetAttr();
					foreach (string attr in attrs)
					{
						Rows.Add(attr);
					}
					break;
				case "Owner":
					Rows.Add(Owner.GetAttr());
					break;
				case "Race":
					attrs = Race.GetAttr();
					foreach (string attr in attrs)
					{
						Rows.Add(attr);
					}
					break;
				case "Tournament":
					Rows.Add(Tournament.GetAttr());
					break;
				case "Result":
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
				case "Driver":
					string[] attrs = Driver.GetAttr();
					foreach (string attr in attrs)
					{
						if (Rows.Contains(attr)) Rows.Remove(attr);
						else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
					}
					break;
				case "Owner":
					if (Rows.Contains(Owner.GetAttr())) Rows.Remove(Owner.GetAttr());
					else if (ChosenRows.Contains(Owner.GetAttr())) ChosenRows.Remove(Owner.GetAttr());
					break;
				case "Race":
					attrs = Race.GetAttr();
					foreach (string attr in attrs)
					{
						if (Rows.Contains(attr)) Rows.Remove(attr);
						else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
					}
					break;
				case "Tournament":
					if (Rows.Contains(Tournament.GetAttr())) Rows.Remove(Tournament.GetAttr());
					else if (ChosenRows.Contains(Tournament.GetAttr())) ChosenRows.Remove(Tournament.GetAttr());
					Rows.Add(Tournament.GetAttr());
					break;
				case "Result":
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
		public void ExecuteQuery()
		{
			Select();
		}
		public string ExtractColumn(string str)
		{
			string[] str1 = str.Split(' ');
			string column = str1[1];
			return column;
		}



		public void Select()
		{
			List<List<object>> queryList = new();
			foreach (string str in ChosenRows)
			{
				string[] str1 = str.Split(' ');
				string table = str1[0];
				string column = str1[1];
				table = table.Remove(table.Length - 1);
				List<object> values = new List<object>();
				switch (table)
				{
					case "Driver":
						if (str == SelectedRowForCondition)
						{
							switch (SelectedOperator)
							{
								case "=":
									foreach (var driver in main.Drivers.Where(item => item[ExtractColumn(SelectedRowForCondition)].Equals(Condition)))
									{
										values.Add(driver[column]);
									}
									break;
								default:
									foreach (var driver in main.Drivers)
									{
										values.Add(driver[column]);
									}
									break;
							}
						}
						else
						{
							foreach (var driver in main.Drivers)
							{
								values.Add(driver[column]);
							}
						}
						break;
					case "Owner":
						if (str == SelectedRowForCondition)
						{
							switch (SelectedOperator)
							{
								case "":
									foreach (var owner in main.Owners)
									{
										values.Add(owner[column]);
									}
									break;
								case "=":
									foreach (var owner in main.Owners.Where(item => item[ExtractColumn(SelectedRowForCondition)].Equals(Condition)))
									{
										values.Add(owner[column]);
									}
									break;
							}
						}
						else
						{
							foreach (var owner in main.Owners)
							{
								values.Add(owner[column]);
							}
						}
						break;
					case "Race":
						if (str == SelectedRowForCondition)
						{
							switch (SelectedOperator)
							{
								case "<":
									foreach (var race in main.Races.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) < double.Parse(Condition)))
									{
										values.Add(race[column]);
									}
									break;
								case ">":
									foreach (var race in main.Races.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) > double.Parse(Condition)))
									{
										values.Add(race[column]);
									}
									break;
								case "<=":
									foreach (var race in main.Races.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) <= double.Parse(Condition)))
									{
										values.Add(race[column]);
									}
									break;
								case ">=":
									foreach (var race in main.Races.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) >= double.Parse(Condition)))
									{
										values.Add(race[column]);
									}
									break;
								case "":
									foreach (var race in main.Races)
									{
										values.Add(race[column]);
									}
									break;
								case "=":
									foreach (var race in main.Races.Where(item => item[ExtractColumn(SelectedRowForCondition)].Equals(Condition)))
									{
										values.Add(race[column]);
									}
									break;
							}
						}
						else
						{
							foreach (var race in main.Owners)
							{
								values.Add(race[column]);
							}
						}
						break;
					case "Result":
						if (str == SelectedRowForCondition)
						{
							switch (SelectedOperator)
							{
								case "<":
									foreach (var result in main.Results.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) < double.Parse(Condition)))
									{
										values.Add(result[column]);
									}
									break;
								case ">":
									foreach (var result in main.Results.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) > double.Parse(Condition)))
									{
										values.Add(result[column]);
									}
									break;
								case "<=":
									foreach (var result in main.Results.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) <= double.Parse(Condition)))
									{
										values.Add(result[column]);
									}
									break;
								case ">=":
									foreach (var result in main.Results.Where(item => double.Parse(item[ExtractColumn(SelectedRowForCondition)].ToString()) >= double.Parse(Condition)))
									{
										values.Add(result[column]);
									}
									break;
								case "":
									foreach (var result in main.Results)
									{
										values.Add(result[column]);
									}
									break;
								case "=":
									foreach (var result in main.Results.Where(item => item[ExtractColumn(SelectedRowForCondition)].Equals(Condition)))
									{
										values.Add(result[column]);
									}
									break;
							}
						}
						else
						{
							foreach (var result in main.Results)
							{
								values.Add(result[column]);
							}
						}
						break;
					case "Tournament":
						if (str == SelectedRowForCondition)
						{
							switch (SelectedOperator)
							{
								case "=":
									foreach (var tournament in main.Tournaments.Where(item => item[ExtractColumn(SelectedRowForCondition)].Equals(Condition)))
									{
										values.Add(tournament[column]);
									}
									break;
							}
						}
						else
						{
							foreach (var tournament in main.Tournaments)
							{
								values.Add(tournament[column]);
							}
						}
						break;
				   
				}
				queryList.Add(values);
			}
		}
	}
}
