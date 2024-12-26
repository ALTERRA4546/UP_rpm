using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ticket14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorMessages();

            bool isValid = ValidateForm();
            if (isValid)
            {
                SaveUserData();
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            if (!Regex.IsMatch(nameTextBox.Text, @"[a-zA-Z]"))
            {
                nameErrorTextBlock.Text = "Name should contain only letters.";
                isValid = false;
            }

            if (!Regex.IsMatch(emailTextBox.Text, @"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}"))
            {
                emailErrorTextBlock.Text = "Invalid email format.";
                isValid = false;
            }

            if (passwordTextBox.Text.Length < 8 || !Regex.IsMatch(passwordTextBox.Text, @"(?=.*[a-zA-Z])(?=.*\d).+$"))
            {
                passwordErrorTextBlock.Text = "Password should have minimum 8 characters and contain letters and numbers.";
                isValid = false;
            }

            return isValid;
        }

        private void ClearErrorMessages()
        {
            nameErrorTextBlock.Text = "";
            emailErrorTextBlock.Text = "";
            passwordErrorTextBlock.Text = "";
        }

        private void SaveUserData()
        {
            string fileName = "user_data.txt";
            string userData = $"Name: {nameTextBox.Text}, Email: {emailTextBox.Text}, Password: {passwordTextBox.Text}";

            try
            {
                File.AppendAllText(fileName, userData + Environment.NewLine);
                MessageBox.Show("Registration successful! Data saved to file.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
