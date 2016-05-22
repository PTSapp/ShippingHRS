using ShippingApp.Model;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.Utilites
{
    public static class UserManager
    {
        private static List<User> userList;
        private static User currentlyLoggedUser;

        public static void LoadUsers()
        {
            string employeesFilePath = PathFinder.FetchPathForResource("Employees");
            string[] employeeRecords = File.ReadAllLines(employeesFilePath);

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
            if(foundUser == null)
            {
                return false;
            }

            currentlyLoggedUser = foundUser;

            return true;
        }

        public static bool Register()
        {
            // TODO: Finish this
            User user = new User();
            if (user == null)
            {
                return false;
            }

            return true;
        }

        private static void ShowRegisterForm()
        {
            // Open form here
        }

    }
}
