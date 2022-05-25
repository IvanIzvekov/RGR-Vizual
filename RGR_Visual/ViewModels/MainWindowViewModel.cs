using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace RGR_Visual.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public NASCARContext Db { get; }
		public MainWindowViewModel()
		{
			Db = new NASCARContext();
			Db.Drivers.Load<Driver>();
			Drivers = Db.Drivers.Local.ToObservableCollection();
			Db.Owners.Load<Owner>();
			Owners = Db.Owners.Local.ToObservableCollection();
			Db.Races.Load<Race>();
			Races = Db.Races.Local.ToObservableCollection();
			Db.Results.Load<Result>();
			Results = Db.Results.Local.ToObservableCollection();
			Db.Tournaments.Load<Tournament>();
			Tournaments = Db.Tournaments.Local.ToObservableCollection();
		}

		string saveError = "";

		public string SaveError
		{
			get => saveError;
			set
			{
				this.RaiseAndSetIfChanged(ref saveError, value);
			}
		}

		public ObservableCollection<Driver> Drivers { get; }
		public ObservableCollection<Owner> Owners { get; }
		public ObservableCollection<Race> Races { get; }
		public ObservableCollection<Result> Results { get; }
		public ObservableCollection<Tournament> Tournaments { get; }


		public void AddRow(int index)
		{
			switch (index)
			{
				case 0:
					Db.Drivers.Add(new Driver(Drivers[Drivers.Count-1].Id+1));
					break;
				case 1:
					Db.Owners.Add(new Owner(Owners[Owners.Count - 1].Id + 1));
					break;
				case 2:
					Db.Races.Add(new Race(Races[Races.Count - 1].Id + 1));
					break;
				case 3:
					Db.Tournaments.Add(new Tournament(Tournaments[Tournaments.Count - 1].Id + 1));
					break;
				case 4:
					Db.Results.Add(new Result(Results[Results.Count - 1].Id + 1));
					break;
			}
		}
		public void Save()
		{
			try
			{
				Db.SaveChanges();
				SaveError = "";
			}
			catch (Exception)
			{
				SaveError = "Save Error";
			}
		}
	}
}
