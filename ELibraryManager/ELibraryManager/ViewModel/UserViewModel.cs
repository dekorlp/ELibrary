using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ELibraryManager.Command;

namespace ELibraryManager.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        private User _user;
        public static List<User> Users;
        public ICommand CreateUserCommand { get; private set; }

        public Action CloseAction { get; set; }

        public UserViewModel()
        {
            _user = new User();
            _user.RentedBooks = new List<Book>();
            if(Users == null) Users = new List<User>();
            CreateUserCommand = new ActionCommand(OnCreateUserExecuted, OnCreateUserCanExecute );
        }

        public int Id
        {
            get { return _user.Id; }
        }

        public string Matrikelnumber
        {
            get { return _user.Matrikelnumber; }
            set
            {
                _user.Matrikelnumber = value;
                Changed("Matrikelnummer");
            }
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                Changed("Name");
            }
        }

        private bool OnCreateUserCanExecute(object arg)
        {
            if (String.IsNullOrEmpty(Matrikelnumber) || String.IsNullOrEmpty(Name)) return false;
            return true;
        }

        private void OnCreateUserExecuted(object obj)
        {
            if (String.IsNullOrEmpty(Matrikelnumber) || String.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Name or ISBN is missing", "Missing Arguments", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                _user.Id = UserViewModel.Users.Count;
                UserViewModel.Users.Add(_user);
                MainWindow.GetMainViewModel().refreshDataView();
                CloseAction();
            }
        }
    }
}
