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

namespace Lab_5_ITHS
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();

                deleteUserButton.IsEnabled = false;
                updateUserButton.IsEnabled = false;
                nameLabel.IsEnabled = false;
                emailLabel.IsEnabled = false;
                nameInputBox.Focus();
            }
            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                if (nameInputBox.Text != "")
                {
                    var userNameAndEmail = new User(nameInputBox.Text, emailInputBox.Text);
                    userList.Items.Add(userNameAndEmail);
                    userList.Items.Refresh();
                    nameInputBox.Clear();
                    emailInputBox.Clear();
                }
                nameInputBox.Focus();
            }

            private void PrintNameList(object sender, SelectionChangedEventArgs e)
            {
                var selectedNameUserList = (userList.SelectedItem as User);
                adminList.SelectedItem = null;
                if (selectedNameUserList == null)
                {
                    moveToAdminButton.IsEnabled = moveToUserButton.IsEnabled = deleteUserButton.IsEnabled = false;
                }
                deleteUserButton.IsEnabled = moveToAdminButton.IsEnabled = updateUserButton.IsEnabled = true;
                moveToUserButton.IsEnabled = false;
                if (selectedNameUserList != null)
                {
                    nameLabel.Content = selectedNameUserList.name;
                    emailLabel.Content = selectedNameUserList.email;
                }
            }
            private void PrintAdminList(object sender, SelectionChangedEventArgs s)
            {
                var selectedNameAdminList = (adminList.SelectedItem as User);
                userList.SelectedItem = null;
                if (selectedNameAdminList == null)
                {
                    moveToUserButton.IsEnabled = moveToAdminButton.IsEnabled = deleteUserButton.IsEnabled = false;
                }
                updateUserButton.IsEnabled = deleteUserButton.IsEnabled = moveToUserButton.IsEnabled = true;
                moveToAdminButton.IsEnabled = false;
                if (selectedNameAdminList != null)
                {
                    nameLabel.Content = selectedNameAdminList.name;
                    emailLabel.Content = selectedNameAdminList.email;
                }
            }
            private void DeleteName_Click(object sender, RoutedEventArgs e)
            {
                nameLabel.Content = "";
                emailLabel.Content = "";
                if (this.userList.SelectedIndex >= 0)
                {
                    this.userList.Items.RemoveAt(this.userList.SelectedIndex);
                    deleteUserButton.IsEnabled = false;
                    moveToAdminButton.IsEnabled = false;
                }
                else if (this.adminList.SelectedIndex >= 0)
                {
                    this.adminList.Items.RemoveAt(this.adminList.SelectedIndex);
                    deleteUserButton.IsEnabled = false;
                    moveToUserButton.IsEnabled = false;
                }
            }
            private void UpdateButton_Click(object sender, RoutedEventArgs e)
            {
                var user = (userList.SelectedItem as User);
                var admin = (adminList.SelectedItem as User);
                if (userList.SelectedIndex >= 0)
                {
                    if (nameInputBox.Text != "")
                    {
                        user.name = nameInputBox.Text;
                        nameLabel.Content = user.name;
                    }
                    if (emailInputBox.Text != "")
                    {
                        user.email = emailInputBox.Text;
                        emailLabel.Content = user.email;
                    }
                    userList.Items.Refresh();
                }
                if (adminList.SelectedIndex >= 0)
                {
                    if (nameInputBox.Text != "")
                    {
                        admin.name = nameInputBox.Text;
                        nameLabel.Content = admin.name;
                    }
                    if (emailInputBox.Text != "")
                    {
                        admin.email = emailInputBox.Text;
                        emailLabel.Content = admin.email;
                    }
                    adminList.Items.Refresh();
                }
                userList.SelectedItem = adminList.SelectedItem = null;
                updateUserButton.IsEnabled = moveToUserButton.IsEnabled = moveToAdminButton.IsEnabled = false;
                nameInputBox.Clear();
                emailInputBox.Clear();
            }
            private void ChangeBetweenUserAndAdmin(object sender, RoutedEventArgs e)
            {
                nameLabel.Content = "";
                emailLabel.Content = "";
                deleteUserButton.IsEnabled = false;
                switch ((sender as Button).Name)
                {
                    case "moveToAdminButton":
                        var user = (userList.SelectedItem as User);
                        adminList.Items.Add(user);
                        this.userList.Items.RemoveAt(this.userList.SelectedIndex);
                        moveToAdminButton.IsEnabled = false;
                        deleteUserButton.IsEnabled = false;
                        updateUserButton.IsEnabled = false;
                        break;
                    case "moveToUserButton":
                        var admin = (adminList.SelectedItem as User);
                        userList.Items.Add(admin);
                        this.adminList.Items.RemoveAt(this.adminList.SelectedIndex);
                        moveToUserButton.IsEnabled = false;
                        deleteUserButton.IsEnabled = false;
                        updateUserButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }
    }
} 