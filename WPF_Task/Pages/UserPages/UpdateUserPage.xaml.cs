using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WPF_Task.Models;
using WPF_Task.Repositories;

namespace WPF_Task.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateUserPage.xaml
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        UsersRepository usersRepository;
        public UpdateUserPage()
        {
            InitializeComponent();
            usersRepository = new UsersRepository();

            var roles = Connect.DbConnection.Roles.ToList();

            TextBoxName.Text = DataStorage.CurrentUser.Name;
            TextBoxSurname.Text = DataStorage.CurrentUser.Surname;
            TextBoxPhoneNumber.Text = DataStorage.CurrentUser.PhoneNumber;
            TextBoxPassword.Text = DataStorage.CurrentUser.Password;
            TextBoxEmail.Text = DataStorage.CurrentUser.Email;
            ComboBoxRole.ItemsSource = roles;
            ComboBoxRole.DisplayMemberPath = "Name";
            ComboBoxRole.SelectedIndex = roles.FindIndex(item => item.Id == DataStorage.CurrentUser.RoleId);
        }

        private void ButtonUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            usersRepository.UpdateUserInDb(DataStorage.CurrentUser.Id, 
                TextBoxName.Text, 
                TextBoxSurname.Text, 
                TextBoxPhoneNumber.Text, 
                TextBoxEmail.Text, 
                TextBoxPassword.Text, 
                ((Role)ComboBoxRole.SelectedItem).Id
                );
            
            EventPagesAggregator.NotifyDataUpdated();
            DataStorage.CurrentUser = null;
        }
    }
}
