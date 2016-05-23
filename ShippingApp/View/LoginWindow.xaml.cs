using System.Linq;
using ShippingApp.Utilites;
using ShippingApp.View.Interfaces;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.View
{
    public partial class LoginWindow : MetroWindow, IWindowState
    {
        public bool VisibleForAll
        {
            get { return true; }
        }

        public LoginWindow()
        {
            InitializeComponent();
            UserManager.LoadUsers();
        }

        private async void loginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(!UserManager.Login(usernameBox.Text, passwordBox.Password))
            {
                await this.ShowMessageAsync("ГРЕШКА", "Невалидни номер/парола!");
            }
            /*

            OPEN YOUR WINDOW HERE

            AnotherWindow anotherWindow = new AnotherWindow();

            // if you only want to display the window and you won`t return to this method
            anotherWindow.Show(); 

            // if you want to return to this method AFTER your window has been closed
            anotherWindow.ShowDialog(); 

            */
        }

        private async void registerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Ask for admin code
            InputBoxWindow inputBox = new InputBoxWindow();
            inputBox.ShowDialog();

            // Check if code passed
            if(string.IsNullOrEmpty(inputBox.inputCode))
            {
                return;
            }

            // Proceed to register window
            if (!UserManager.Register())
            {
                await this.ShowMessageAsync("ГРЕШКА", "Неуспешна регистрация!");
            }
            else
            {
                await this.ShowMessageAsync("ИНФО", "Yспешнo регистриран потребител: " + UserManager.GetUsers().Last() + "!");
            } 
        }
    }
}
