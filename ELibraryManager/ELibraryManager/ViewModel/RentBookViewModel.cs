using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ELibraryManager.Command;
using ELibraryManager.Dialogs;
using ELibraryManager.Model;

namespace ELibraryManager.ViewModel
{
    class RentBookViewModel : BaseViewModel
    {
        private List<User> _userList;

        private Book _book { get; set; }
        private User _user { get; set; }
        public int SelectedUserIndex { get; set; }

        public ICommand FilterBookCommand { get; private set; }
        public ICommand OkCommand { get; set; }
        public Action CloseAction { get; set; }

        public RentBookViewModel()
        {
            _userList = UserViewModel.Users;
            _book = new Book();
            FilterBookCommand = new ActionCommand(OnFilterBookExecuted, OnFilterBookCanExecute);
            OkCommand = new ActionCommand(OnOkExecuted, OnOkCanExecute);
        }
        
        private bool OnOkCanExecute(object arg)
        {
            if ((_userList == null || _userList.Count == 0) || String.IsNullOrEmpty(ISBN) &&
                String.IsNullOrEmpty(BookName)) return false;
            return true;
        }

        private void OnOkExecuted(object obj)
        {
            _book.RentToUser = _user;
            _user.RentedBooks.Add(_book);
            MainWindow.GetMainViewModel().refreshDataView();
            CloseAction();
        }

        private void OnFilterBookExecuted(object obj)
        {
            BookFilter BookFilter = new BookFilter();
            BookFilter.ShowDialog();
            if (((BookFilterViewModel)BookFilter.DataContext).SelectedBookItem != null)
            {
                _book = ((BookFilterViewModel)BookFilter.DataContext).SelectedBookItem;
                Changed("BookName");
                Changed("ISBN");
            }

        }

        private bool OnFilterBookCanExecute(object arg)
        {
            return true;
        }

        public string BookName
        {
            get
            {
                return _book.Name;
            }
            set
            {
                _book.Name = value;
                Changed("BookName");
            }
        }

        public string ISBN
        {
            get { return _book.Isbn; }
            set
            {
                _book.Isbn = value;
                Changed("ISBN");
            }
        }

        public User SelectedUser
        {
            get { return this._user; }
            set
            {
                _user = value;
                Changed("SelectedUser");
            }
        }

        public List<User> UserList
        {
            get { return this._userList; }
        }

    }
}
