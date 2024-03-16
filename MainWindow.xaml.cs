using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFCoreDB_HW.Models;

namespace EFCoreDB_HW;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DataContext _dataContext;
    public MainWindow()
    {
        InitializeComponent();
        
        var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(config.GetConnectionString("Default"))
            .Options;
        _dataContext = new DataContext(options);

        _dataContext.User.Add(new User()
        {
            Name = "TestName",
            Login = "UserLog1",
            Password = "UserPassword"
        });
        _dataContext.SaveChanges();

        dataGrid.ItemsSource = _dataContext.User.ToList();
    }
}