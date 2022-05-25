using Avalonia.Controls;
using RGR_Visual.ViewModels;

namespace RGR_Visual.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("DeleteBtn").Click += delegate
            {
                Delete();
            };
        }

        public void Delete()
        {
            var context = this.DataContext as MainWindowViewModel;
            var tables = this.FindControl<TabControl>("Tables");
            int index = tables.SelectedIndex;
            switch (index)
            {
                case 0:
                    context.Db.Drivers.Remove((Driver)this.FindControl<DataGrid>("Drivers").SelectedItem);
                    break;
                case 1:
                    context.Db.Owners.Remove((Owner)this.FindControl<DataGrid>("Owners").SelectedItem);
                    break;
                case 2:
                    context.Db.Races.Remove((Race)this.FindControl<DataGrid>("Races").SelectedItem);
                    break;
                case 3:
                    context.Db.Tournaments.Remove((Tournament)this.FindControl<DataGrid>("Tournaments").SelectedItem);
                    break;
                case 4:
                    context.Db.Results.Remove((Result)this.FindControl<DataGrid>("Results").SelectedItem);
                    break;
            }
        }
    }
}
