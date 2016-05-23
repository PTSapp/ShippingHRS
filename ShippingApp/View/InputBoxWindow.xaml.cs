using ShippingApp.Utilites;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ShippingApp.View
{
    public partial class InputBoxWindow : MetroWindow
    {
        public string inputCode;

        public InputBoxWindow()
        {
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (adminCodeBox.Text.Equals(UserManager.adminCode))
            {
                inputCode = adminCodeBox.Text;
                this.Close();
                return;
            }
            await this.ShowMessageAsync("ГРЕШКА", "Невалиден код за достъп!");
        }
    }
}
