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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        UsersRepository usersRepository;
        public AddUserPage()
        {
            InitializeComponent();
            usersRepository = new UsersRepository();

            ComboBoxRole.ItemsSource = Connect.DbConnection.Roles.ToList();
            ComboBoxRole.DisplayMemberPath = "Name";
        }

        private void ButtonAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            usersRepository.AddNewUser
                (
                TextBoxName.Text, 
                TextBoxSurname.Text, 
                TextBoxPhoneNumber.Text, 
                TextBoxEmail.Text, 
                TextBoxPassword.Text, 
                ((Role)ComboBoxRole.SelectedItem).Id
                );
            
            EventPagesAggregator.NotifyDataUpdated();
        }
    }
}
