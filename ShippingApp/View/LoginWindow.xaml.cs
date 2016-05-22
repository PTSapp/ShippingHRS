using ShippingApp.Utilites;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.View
{
    public partial class LoginWindow : MetroWindow
    {
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
        }

        private async void registerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!UserManager.Register())
            {
                await this.ShowMessageAsync("ГРЕШКА", "Невалидни въведени стойности!");
            }
        }
    }
}
