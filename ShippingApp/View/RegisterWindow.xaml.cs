using System;
using System.IO;
using System.Text;
using ShippingApp.Model;
using ShippingApp.Utilites;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.View
{
    public partial class RegisterWindow : MetroWindow
    {
        public RegisterWindow()
        {
            InitializeComponent();
            companyIdBox.Text = UserManager.GenerateCompanyId();
        }

        private async void submitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StringBuilder userBuilder = new StringBuilder();
            userBuilder
                .Append('\n')
                .Append(companyIdBox.Text).Append(',')
                .Append(passwordBox.Password).Append(',')
                .Append(namesBox.Text).Append(',')
                .Append(positionBox.Text).Append(',')
                .Append(salaryBox.Text).Append(',')
                .Append(chkIsAdmin.IsChecked.Value ? bool.TrueString : bool.FalseString);

            if (userBuilder.ToString().Split(',').Length == typeof(User).GetProperties().Length)
            {
                string employeesFilePath = PathFinder.FetchPathForResource("Employees.txt");
                File.AppendAllText(employeesFilePath, userBuilder.ToString());

                UserManager.LoadUsers();
            }
            else
            {
                await this.ShowMessageAsync("ГРЕШКА", "Липсват въведени стойности!");
            }
        }
    }
}
