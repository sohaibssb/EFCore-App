using System.Windows;
using EF_Test; // Reference your EF_Test project
using EF_Test.Models; // Reference your models

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext(); // Initialize your DbContext
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Load data from the Students table
            var students = _context.Students.ToList();
            StudentsDataGrid.ItemsSource = students; // Bind data to the DataGrid
        }
    }
}