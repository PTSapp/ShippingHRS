using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using ShippingApp.View;
using ShippingApp.Model;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.Utilites
{
    public static class UserManager
    {
        public static readonly string adminCode = "0x0";

        private static Random companyIdGenerator = new Random();

        private static User _currentlyLoggedUser;
        public static User CurrentlyLoggedUser {
            get
            {
                return _currentlyLoggedUser;
            }
        }

        private static List<User> userList;

        public static IReadOnlyList<User> GetUsers()
        {
            return userList.AsReadOnly();
        }

        public async static void LoadUsers()
        {
            string employeesFilePath = PathFinder.FetchPathForResource("Employees.txt");
            if (string.IsNullOrEmpty(employeesFilePath))
            {
                await (Application.Current.MainWindow as MetroWindow).ShowMessageAsync("ГРЕШКА", "Липсват данни за служителите!");
                Application.Current.MainWindow.Close();
                Environment.Exit(0);
            }
            
            string[] employeeRecords = File.ReadAllLines(employeesFilePath);

            userList = new List<User>(employeeRecords.Length);

            double salaryParsed = 0.0d;
            bool hasAdminPrivilegesParsed = false;
            foreach (string employeeRecord in employeeRecords)
            {
                string[] employeeData = employeeRecord.Split(',');
                User user = new User();
                user.CompanyCardUniqueId = employeeData[0];
                user.Password = employeeData[1];
                user.Names = employeeData[2];
                user.Position = employeeData[3];

                if(double.TryParse(employeeData[4], out salaryParsed))
                {
                    user.Salary = salaryParsed;
                }

                if (bool.TryParse(employeeData[5], out hasAdminPrivilegesParsed))
                {
                    user.HasAdminPrivileges = hasAdminPrivilegesParsed;
                }

                userList.Add(user);
            }
        }


        public static bool Login(string username, string password)
        {
            User foundUser = userList.Where(u => u.CompanyCardUniqueId.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
            if (foundUser == null)
            {
                return false;
            }

            _currentlyLoggedUser = foundUser;

            return true;
        }

        public static bool Register()
        {
            int usersBefore = userList.Count;
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();

            int usersAfter = userList.Count;
            if (usersAfter > usersBefore)
            {
                return true;
            }

            return false;
        }

        public static string GenerateCompanyId()
        {
            string generatedId = string.Empty;
            bool isDuplicate = false;

            do
            {
                generatedId = companyIdGenerator.Next(1000000, 9999999).ToString();
                isDuplicate = userList.Where(u => u.CompanyCardUniqueId.Equals(generatedId)).FirstOrDefault() != null;
            }
            while (isDuplicate);

            return generatedId;
        }
    }
}
