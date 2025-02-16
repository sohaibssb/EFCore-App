using System;
using System.ComponentModel;
using System.Windows;

namespace EF_Test.Views
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _studentName = string.Empty;
        private string _studentEmail = string.Empty;

        public string StudentName
        {
            get => _studentName;
            set
            {
                _studentName = value;
                OnPropertyChanged(nameof(StudentName));
            }
        }

        public string StudentEmail
        {
            get => _studentEmail;
            set
            {
                _studentEmail = value;
                OnPropertyChanged(nameof(StudentEmail));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
