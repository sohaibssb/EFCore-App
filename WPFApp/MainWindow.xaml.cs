using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using EF_Test;
using EF_Test.Models;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadStudents();
        }

        // Load and display all students
        private void LoadStudents()
        {
            var students = _context.Students
                .Include(s => s.department) // Include the department
                .Include(s => s.grade) // Include the grade
                .ToList();

            StudentsDataGrid.ItemsSource = students;
        }

        // Add a new student
        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate input data
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid name.");
                    return;
                }

                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid email.");
                    return;
                }

                if (!int.TryParse(AgeTextBox.Text, out int age))
                {
                    MessageBox.Show("Please enter a valid age (e.g., 20).");
                    return;
                }

                if (!int.TryParse(GradeTextBox.Text, out int gradeLevel))
                {
                    MessageBox.Show("Please enter a valid grade (e.g., 1).");
                    return;
                }

                if (!int.TryParse(DepartmentIdTextBox.Text, out int departmentId))
                {
                    MessageBox.Show("Please enter a valid department ID (e.g., 1).");
                    return;
                }

                // Fetch the department from the database
                var department = _context.Departments.Find(departmentId);
                if (department == null)
                {
                    MessageBox.Show("Department not found!");
                    return;
                }

                // Create a new student
                var student = new Student
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Age = age,
                    Grade = gradeLevel,
                    departmentId = departmentId,
                    department = department, // Assign the fetched department
                    grade = new Grade // Initialize grade with default values
                    {
                        physics = 0,
                        chemistry = 0,
                        programming = 0,
                        studentId = 0, // Temporary value (will be updated after saving the student)
                        student = null // Temporary value (will be updated after saving the student)
                    }
                };

                // Add to the database
                _context.Students.Add(student);
                _context.SaveChanges();

                // Update the grade's studentId and student properties
                student.grade.studentId = student.Id; // Set the studentId to the newly generated student ID
                student.grade.student = student; // Set the student navigation property
                _context.SaveChanges();

                // Refresh the DataGrid
                LoadStudents();

                // Clear input fields
                NameTextBox.Clear();
                EmailTextBox.Clear();
                AgeTextBox.Clear();
                GradeTextBox.Clear();
                DepartmentIdTextBox.Clear();

                MessageBox.Show("Student added successfully!");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error saving to the database: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}");
            }
        }

        // Delete a student by ID
        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse the student ID
                var studentId = int.Parse(DeleteStudentIdTextBox.Text);

                // Find the student
                var student = _context.Students.Find(studentId);
                if (student == null)
                {
                    MessageBox.Show("Student not found!");
                    return;
                }

                // Remove from the database
                _context.Students.Remove(student);
                _context.SaveChanges();

                // Refresh the DataGrid
                LoadStudents();

                // Clear input field
                DeleteStudentIdTextBox.Clear();

                MessageBox.Show("Student deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}");
            }
        }
    }
}